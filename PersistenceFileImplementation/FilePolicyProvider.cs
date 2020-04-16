using DataConstract.Models;
using DataConstract.Providers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace PersistenceFileImplementation
{
    public class FilePolicyProvider : PolicyProvider
    {
        public Policy GetPolicy(string policyPath)
        {
            var policyJson = File.ReadAllText(policyPath);

            return JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());
        }
    }
}
