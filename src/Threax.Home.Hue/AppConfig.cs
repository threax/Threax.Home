using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Hue.Services;

namespace Threax.Home.Hue
{
    /// <summary>
    /// Configuration for the Hue Api.
    /// </summary>
    public class AppConfig
    {
        public string BaseUrl { get; set; } = "{{host}}";
    }
}
