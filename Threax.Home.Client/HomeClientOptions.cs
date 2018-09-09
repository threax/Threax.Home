using System;
using System.Collections.Generic;
using Threax.AspNetCore.Halcyon.Client;

namespace AppTemplateClient
{
    public class HomeClientConfig
    {
        /// <summary>
        /// The url of the service.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// The options when using ClientCredentials, otherwise ignored.
        /// </summary>
        public ClientCredentailsAccessTokenFactoryOptions ClientCredentials { get; set; } = new ClientCredentailsAccessTokenFactoryOptions();
    }

    public class HomeClientOptions
    {
        public Dictionary<String, HomeClientConfig> Clients { get; set; }
    }
}
