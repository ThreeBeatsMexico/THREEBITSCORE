using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.Common
{
    public class ChildVue
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string _name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string to { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string icon { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> _children { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string route { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ItemVue> items { get; set; }
    }
}
