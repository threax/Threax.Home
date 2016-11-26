using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Threax.Home.Core;

//This is just an example implementation, disable async warnings
#pragma warning disable CS1998

namespace Threax.Home.Api.Controllers
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    [Route("[controller]/[action]")]
    public class SwitchController : Controller, ISwitchController<SwitchPosition<String>, String>
    {
        /// <summary>
        /// Get the position of a named switch.
        /// </summary>
        /// <param name="ids">The ids of the switches to lookup.</param>
        /// <returns>The position of the switch.</returns>
        [HttpGet]
        public async Task<IEnumerable<SwitchPosition<String>>> GetPosition([FromQuery] IEnumerable<String> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the position of a named switch.
        /// </summary>
        /// <param name="positions">The position of the switch.</param>
        [HttpPut]
        public async Task SetPosition([FromBody] IEnumerable<SwitchPosition<String>> positions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all the switches.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SwitchInfo<String>>> List()
        {
            throw new NotImplementedException();
        }
    }
}
