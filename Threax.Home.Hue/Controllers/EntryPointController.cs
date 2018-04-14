using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Hue.ViewModels;

namespace Threax.Home.Hue.Controllers
{
    [Route("")]
    [ResponseCache(NoStore = true)]
    public class EntryPointController : Controller
    {
        public class Rels
        {
            public const string Get = "Get";
        }

        [HttpGet]
        [HalRel(Rels.Get)]
        public EntryPointView Get()
        {
            return new EntryPointView();
        }
    }
}
