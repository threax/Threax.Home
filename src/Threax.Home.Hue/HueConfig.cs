using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Hue
{
    public class HueClientConfig
    {
        /// <summary>
        /// The host ip address.
        /// </summary>
        public String HostIp { get; set; }

        /// <summary>
        /// The app key to access the api.
        /// </summary>
        public String AppKey { get; set; }
    }

    /// <summary>
    /// Configuration for the Hue Api.
    /// </summary>
    public class HueConfig
    {
        public string BaseUrl { get; set; } = "{{host}}";

        public Dictionary<String, HueClientConfig> Clients { get; set; }
    }
}
