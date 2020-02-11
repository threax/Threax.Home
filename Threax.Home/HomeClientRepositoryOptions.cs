using AppTemplateClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client.OpenIdConnect;

namespace Threax.Home
{
    public class HomeClientRepositoryOptions : HomeClientConfig
    {
        /// <summary>
        /// The options when using ClientCredentials, otherwise ignored.
        /// </summary>
        public ClientCredentailsAccessTokenFactoryOptions ClientCredentials { get; set; } = new ClientCredentailsAccessTokenFactoryOptions();
    }

    public class HomeClientOptions
    {
        public Dictionary<String, HomeClientRepositoryOptions> Clients { get; set; }
    }
}
