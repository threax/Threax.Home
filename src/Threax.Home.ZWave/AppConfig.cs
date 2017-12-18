using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.ZWave
{
    /// <summary>
    /// Configuration for zwave api.
    /// </summary>
    public class AppConfig
    {
        public string BaseUrl { get; set; } = "{{host}}";

        /// <summary>
        /// The com port of your z-wave device.
        /// </summary>
        public String ComPort { get; set; }

        public ExceptionFilterOptions ExceptionOptions { get; set; } = new ExceptionFilterOptions();
    }
}
