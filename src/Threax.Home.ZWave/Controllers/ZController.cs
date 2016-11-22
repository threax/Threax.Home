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
    public class ZController : Controller
    {
        private ZWaveController zwave;

        public ZController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        [HttpGet]
        public async Task<String> Version()
        {
            return await zwave.GetVersion();
        }

        [HttpGet]
        public async Task<List<byte>> Nodes()
        {
            var list = new List<byte>();
            foreach(var node in await zwave.GetNodes())
            {
                list.Add(node.NodeID);
            }
            return list;
        }

        [HttpGet]
        public async Task<IEnumerable<VersionCommandClassReport>> SupportedCommandClasses([FromQuery]byte nodeId)
        {
            var node = await GetNode(nodeId);
            return await node.GetSupportedCommandClasses();
        }

        [HttpGet]
        public async Task<NodeProtocolInfo> ProtocolInfo([FromQuery]byte nodeId)
        {
            var node = await GetNode(nodeId);
            return await node.GetProtocolInfo();
        }

        [HttpGet]
        public async Task<IEnumerable<byte>> Neighbours([FromQuery]byte nodeId)
        {
            var node = await GetNode(nodeId);
            return (await node.GetNeighbours()).Select(n => n.NodeID);
        }

        private async Task<Node> GetNode(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId);
        }
    }
}
