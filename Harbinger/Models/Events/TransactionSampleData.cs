using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Harbinger.Models.Events
{
    internal class TransactionSampleData : IMergeableData
    {
        public string AgentRunId { get; set; }

        public List<TransactionSample> TransactionSamples { get; set; }

        public TransactionSampleData(string payload)
        {
            TransactionSamples = new();

            var transactionSampleData = JsonConvert.DeserializeObject<JArray>(payload);

            AgentRunId = transactionSampleData[0].ToString();

            var transactionSampleArray = (JArray)transactionSampleData[1];
            foreach (var transactionSample in transactionSampleArray.Children())
            {
                var startTimeMs = transactionSample[0].ToObject<long>();
                var durationToResponse = transactionSample[1].ToObject<double>();
                var transactionName = transactionSample[2].ToObject<string>();
                var requestURI = transactionSample[3].ToObject<string>();

                var traceDetails = GetTraceDetails(transactionSample[4]);

                var catGUID = transactionSample[5].ToObject<string>();
                // transactionSample[6] is always null
                // transactionSample[7] is always false
                // transactionSample[8] is always null
                var syntheticsResourceId = transactionSample[9].ToObject<string>();

                TransactionSamples.Add(
                    new TransactionSample
                    {
                        StartTimeMs = startTimeMs,
                        DurationToResponse = durationToResponse,
                        TransactionName = transactionName,
                        RequestURI = requestURI,
                        TraceDetails = traceDetails,
                        CatGUID = catGUID,
                        SyntheticsResourceId = syntheticsResourceId
                    }
                );
            }
        }

        private TraceDetails GetTraceDetails(JToken token)
        {
            var traceDetailsArray =(JArray)token;

            var startTimeMs = traceDetailsArray[0].ToObject<long>();

            // traceDetailsArray[1] unused
            // traceDetailsArray[2] unused

            var rootSegment = GetRootSegment(traceDetailsArray[3]);;

            var attributesArray = traceDetailsArray[4];
            var agentAttributes = ModelHelpers.AddAttributesFromJToken(attributesArray["agentAttributes"]);
            var userAttributes = ModelHelpers.AddAttributesFromJToken(attributesArray["userAttributes"]);
            var intrinsicAttributes = ModelHelpers.AddAttributesFromJToken(attributesArray["intrinsics"]); 
            var traceDetail = new TraceDetails
            {
                StartTimeMs = startTimeMs,
                RootSegment = rootSegment,
                AgentAttributes = agentAttributes,
                UserAttributes = userAttributes,
                IntrinsicAttributes = intrinsicAttributes,
            };

            return traceDetail;
        }

        private TraceDetailSegment GetRootSegment(JToken token)
        {
            var segmentsArray = (JArray)token; // root segment

            var rootSegment = new TraceDetailSegment
            {
                RelativeStartTime = segmentsArray[0].ToObject<double>(),
                RelativeStopTime = segmentsArray[1].ToObject<double>(),
                Name = segmentsArray[2].ToObject<string>(),
                Attributes = ModelHelpers.AddAttributesFromJToken(segmentsArray[3]),
                // Segments added post creation in BuildSegments
                ClassName = segmentsArray[5].ToObject<string>(),
                MethodName = segmentsArray[6].ToObject<string>()
            };

            BuildSegments(rootSegment, segmentsArray[4]);

            return rootSegment;
        }

        private void BuildSegments(TraceDetailSegment parentSegment, JToken childSegments)
        {
            var childSegmentsArray = (JArray)childSegments;
            foreach (var child in childSegmentsArray)
            {
                var segment = new TraceDetailSegment
                {
                    RelativeStartTime = child[0].ToObject<double>(),
                    RelativeStopTime = child[1].ToObject<double>(),
                    Name = child[2].ToObject<string>(),
                    Attributes = ModelHelpers.AddAttributesFromJToken(child[3]),
                    // Segments added post creation
                    ClassName = child[5].ToObject<string>(),
                    MethodName = child[6].ToObject<string>()
                };

                BuildSegments(segment, child[4]);
                parentSegment.Segments.Add(segment);
           }
        }

        public void Merge(IMergeableData dataCollection)
        {
            var transactionSampleData = dataCollection as TransactionSampleData;
            TransactionSamples.AddRange(transactionSampleData.TransactionSamples);
        }
    }

    internal class TransactionSample
    {
        public long StartTimeMs { get; set; }

        public double DurationToResponse { get; set; }

        public string TransactionName { get; set; }

        public string RequestURI { get; set; }

        public TraceDetails TraceDetails { get; set; }

        public string CatGUID { get; set; }

        public string SyntheticsResourceId { get; set; }
    }

    internal class TraceDetails
    {
        public long StartTimeMs { get; set; }

        public TraceDetailSegment RootSegment { get; set; }

        public Dictionary<string, object> AgentAttributes { get; set; }

        public Dictionary<string, object> UserAttributes { get; set; }

        public Dictionary<string, object> IntrinsicAttributes { get; set; }
    }
}
