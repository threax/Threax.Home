using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZWave;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Controllers
{
    [Route("[controller]/[action]")]
    public class BasicController : Controller
    {
        private ZWaveController zwave;

        public BasicController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        [HttpGet]
        public async Task<byte> Get([FromQuery]byte nodeId)
        {
            var com = await GetBasicCommand(nodeId);
            var value = await com.Get();
            return value.Value;
        }

        [HttpGet]
        public async Task Set([FromQuery] byte nodeId, [FromQuery] byte value)
        {
            var com = await GetBasicCommand(nodeId);
            await com.Set(value);
        }

        private async Task<Basic> GetBasicCommand(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId).GetCommandClass<Basic>();
        }

    }
}
