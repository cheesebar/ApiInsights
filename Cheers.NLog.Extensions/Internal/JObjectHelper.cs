using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Cheers.NLog.Extensions.Internal
{
    public class JObjectHelper
    {
        public static string CreateSimpleJson(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            var obj = new JObject();
            foreach (var item in keyValuePairs)
            {
                if(int.TryParse(item.Value,out var intValue))
                {
                    obj.Add(item.Key, intValue);
                }
                else
                {
                    obj.Add(item.Key, item.Value);
                }
            }

            return obj.ToString();
        }
    }
}
