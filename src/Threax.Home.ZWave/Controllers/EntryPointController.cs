using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.ZWave.Models;

namespace Threax.Home.ZWave.Controllers
{
    [Route("/")]
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
