using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Harbinger.Models.Events
{
    internal class ErrorTraceData : IMergeableData
    {
        public string AgentRunId { get; set; }

        public List<ErrorTrace> ErrorTraces { get; set; }

        public ErrorTraceData(string payload)
        {
            ErrorTraces = new();

            var errorTraceData = JsonConvert.DeserializeObject<JArray>(payload);

            AgentRunId = errorTraceData[0].ToString();

            var errorTraces = errorTraceData[1];
            foreach (JArray errorTraceArray in errorTraces)
            {
                var errorTraceObj = new ErrorTrace();

                errorTraceObj.Timestamp = errorTraceArray[0].ToObject<long>();
                errorTraceObj.TransactionName = errorTraceArray[1].ToString();
                errorTraceObj.Message = errorTraceArray[2].ToString();
                errorTraceObj.ErrorType = errorTraceArray[3].ToString();

                var errorTrace = errorTraceArray[4];
                errorTraceObj.Attributes.StackTrace = ((JArray)errorTrace["stack_trace"]).ToObject<List<string>>();
                errorTraceObj.Attributes.AgentAttributes = ModelHelpers.AddAttributesFromJToken(errorTrace["agentAttributes"]);
                errorTraceObj.Attributes.UserAttributes = ModelHelpers.AddAttributesFromJToken(errorTrace["userAttributes"]);
                errorTraceObj.Attributes.InstrinsicAttributes = ModelHelpers.AddAttributesFromJToken(errorTrace["intrinsics"]);

                ErrorTraces.Add(errorTraceObj);
            }
        }

        public void Merge(IMergeableData dataCollection)
        {
            var errorTraceData = dataCollection as ErrorTraceData;
            ErrorTraces.AddRange(errorTraceData.ErrorTraces);
        }
    }
}
