using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZWave;
using ZWave.Channel;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Controllers
{
    [Route("[controller]/[action]")]
    public class NodeController : Controller
    {
        private ZWaveController zwave;

        public NodeController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        [HttpGet]
        public async Task<String> Version()
        {
            return await zwave.GetVersion();
        }

        [HttpGet]
        public async Task<IEnumerable<byte>> List()
        {
            return (await zwave.GetNodes()).Select(n => n.NodeID);
        }

        [HttpGet]
        public async Task<IEnumerable<CommandClass>> SupportedCommandClasses([FromQuery]byte nodeId)
        {
            var node = await GetNode(nodeId);
            return (await node.GetSupportedCommandClasses()).Select(n => n.Class);
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
