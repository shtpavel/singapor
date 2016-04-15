using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Singapor.Resources
{
    public class CulturesProvider
    {
        public IEnumerable<Culture> Cultures { get; private set; }

        public CulturesProvider()
        {
            var json = File.ReadAllText(AppResources.CulturesPath);
            Cultures = JsonConvert.DeserializeObject<IEnumerable<Culture>>(json);
        }
    }

    [JsonObject]
    public class Culture
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Code { get; set; }
    }
}
