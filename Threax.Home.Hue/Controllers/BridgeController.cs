using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Hue.Services;
using Threax.Home.Hue.ViewModels;

namespace Threax.Home.Hue.Controllers
{
    [Route("api/hue/[controller]")]
    [ResponseCache(NoStore = true)]
    public class BridgeController : Controller
    {
        public class Rels
        {
            public const string ListBridges = "ListBridges";
        }

        private IHueClientManager clientManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientManager"></param>
        public BridgeController(IHueClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        [HttpGet]
        [HalRel(Rels.ListBridges)]
        public BridgeCollection Get()
        {
            var query = clientManager.GetClientNames().Select(i => new BridgeView()
            {
                Bridge = i
            });
            return new BridgeCollection(query);
        }
    }
}
