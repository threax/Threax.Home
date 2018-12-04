using libCecCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.LibCec.Services;

namespace Threax.Home.LibCec.Repository
{
    public class CecSwitchRepository<TIn, TOut> : ICecSwitchRepository<TIn, TOut> where TIn : ICoreSwitch, new()
        where TOut : ICoreSwitch, new()
    {
        private ICecManagerService manager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">The ICecManager to use.</param>
        public CecSwitchRepository(ICecManagerService manager)
        {
            this.manager = manager;
        }

        public async Task<TOut> Get(string bridge, string id)
        { 
            var address = ParseId(id);
            var power = await this.manager.GetPower(address);
            var name = $"{await this.manager.GetVendor(address)} {address}";
            return new TOut()
            {
                Id = id,
                Value = power == CecPowerStatus.On ? "on" : "off",
                Subsystem = SubsystemName,
                Bridge = bridge,
                Name = name
            };
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var results = new List<TOut>();
            foreach(var address in await manager.Scan())
            {
                var power = await this.manager.GetPower(address);
                var name = $"{await this.manager.GetVendor(address)} {address}";
                results.Add(new TOut()
                {
                    Id = address.ToString(),
                    Value = power == CecPowerStatus.On ? "on" : "off",
                    Subsystem = SubsystemName,
                    Bridge = "cec",
                    Name = name
                });
            }
            return results;
        }

        public async Task Set(TIn setting)
        {
            var id = ParseId(setting.Id);
            switch (setting.Value)
            {
                case "on":
                    await manager.SetOn(id);
                    break;
                case "off":
                    await manager.SetStandby(id);
                    break;
            }
        }

        private CecLogicalAddress ParseId(String id)
        {
            return (CecLogicalAddress)(Enum.Parse(typeof(CecLogicalAddress), id));
        }

        public String SubsystemName => "libCec";
    }
}
