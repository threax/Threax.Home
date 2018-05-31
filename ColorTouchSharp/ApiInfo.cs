using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ColorTouchSharp
{
    public class ApiInfo
    {
        [JsonProperty("api_ver")]
        public String Version { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }
    }
}
