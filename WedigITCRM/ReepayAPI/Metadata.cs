using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ReepayAPI
{
    public class Metadata
    {
        [JsonProperty("key1")]
        public string Key1 { get; set; }

        [JsonProperty("key2")]
        public string Key2 { get; set; }
    }
}
