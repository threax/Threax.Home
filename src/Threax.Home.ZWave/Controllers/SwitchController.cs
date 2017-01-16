using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.ExceptionToJson;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.ZWave.Models;
using ZWave;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Controllers
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    [Route("[controller]")]
    public class SwitchController : Controller
    {
        public static class Rels
        {
            public const String List = "listSwitches";
            public const String SetSwitches = "setSwitches";
            public const String SetSwitch = "set";
            public const String GetSwitch = "get";
        }

        private ZWaveController zwave;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        public SwitchController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        /// <summary>
        /// Get the position of a named switch.
        /// </summary>
        /// <param name="ids">The ids of the switches to lookup.</param>
        /// <returns>The position of the switch.</returns>
        [HttpGet]
        [HalRel(Rels.List)]
        public async Task<ZWaveSwitchPositionCollectionView> Get([FromQuery] List<int> ids)
        {
            if(ids.Count == 0)
            {
                ids.AddRange(GetSwitches());
            }

            var positions = new List<ZWaveSwitchPosition>();
            foreach (var id in ids)
            {
                positions.Add(await Get(id));
            }
            return new ZWaveSwitchPositionCollectionView(positions);
        }

        /// <summary>
        /// Set multiple switch positions.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="settings">The position to apply.</param>
        /// <returns>void</returns>
        [HttpPut]
        [HalRel(Rels.SetSwitches)]
        public async Task Set([FromBody] IEnumerable<ZWaveSwitchPosition> positions)
        {
            foreach (var position in positions)
            {
                await Set(position.Id, position);
            }
        }

        /// <summary>
        /// Get the position of a named switch.
        /// </summary>
        /// <param name="ids">The ids of the switches to lookup.</param>
        /// <returns>The position of the switch.</returns>
        [HttpGet("{Id}")]
        [HalRel(Rels.GetSwitch)]
        public async Task<ZWaveSwitchPosition> Get(int id)
        {
            //Hardcoded, for now
            Basic com;
            switch (id)
            {
                case 2:
                    com = await GetBasicCommand(2);
                    break;
                default:
                    throw new FileNotFoundException();
            }

            var b = (await com.Get()).Value;
            Switch3SwitchPosition value = Switch3SwitchPosition.Off;
            if (b == 0)
            {
                value = Switch3SwitchPosition.Off;
            }
            else if (b < 10)
            {
                value = Switch3SwitchPosition.Low;
            }
            else if (b < 60)
            {
                value = Switch3SwitchPosition.Medium;
            }
            else if (b < 100)
            {
                value = Switch3SwitchPosition.High;
            }
            return new ZWaveSwitchPosition()
            {
                Id = id,
                Value = value
            };
        }

        /// <summary>
        /// Set multiple switch positions.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="settings">The position to apply.</param>
        /// <returns>void</returns>
        [HttpPut("{Id}")]
        [HalRel(Rels.SetSwitch)]
        public async Task Set(int id, [FromBody] ZWaveSwitchPosition position)
        {
            position.Id = id;
            //Hardcoded, for now
            Basic com;
            switch (position.Id)
            {
                case 2:
                    com = await GetBasicCommand(2);
                    break;
                default:
                    throw new FileNotFoundException();
            }

            switch (position.Value)
            {
                case Switch3SwitchPosition.Off:
                    await com.Set(0);
                    break;
                case Switch3SwitchPosition.Low:
                    await com.Set(1);
                    break;
                case Switch3SwitchPosition.Medium:
                    await com.Set(50);
                    break;
                case Switch3SwitchPosition.High:
                    await com.Set(99);
                    break;
                default:
                    throw new ErrorResultException($"{position.Value} is not a valid position for {position.Id}");
            }
        }

        ///// <summary>
        ///// List all the switches.
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[HalRel(Rels.List)]
        //public async Task<IEnumerable<SwitchInfo<int>>> List()
        //{
        //    return await Task.FromResult(GetSwitches());
        //}

        private IEnumerable<int> GetSwitches()
        {
            //Hardcoded
            yield return 2;
        }

        private async Task<Basic> GetBasicCommand(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId).GetCommandClass<Basic>();
        }
    }
}
