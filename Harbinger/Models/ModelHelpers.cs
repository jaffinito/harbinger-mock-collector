using Newtonsoft.Json.Linq;

namespace Harbinger.Models
{
    internal static class ModelHelpers
    {
        public static void AddAttributesFromJToken(Dictionary<string, object> targetDictionary, JToken token)
        {
            foreach (JProperty item in token.Children())
            {
                targetDictionary.Add(item.Name, item.Value.ToObject<object>());
            }
        }

        public static Dictionary<string, object> AddAttributesFromJToken(JToken token)
        {
            var targetDictionary = new Dictionary<string, object>();
            foreach (JProperty item in token.Children())
            {
                targetDictionary.Add(item.Name, item.Value.ToObject<object>());
            }

            return targetDictionary;
        }
    }
}
