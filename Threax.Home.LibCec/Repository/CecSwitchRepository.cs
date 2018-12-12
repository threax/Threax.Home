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
            foreach (var address in await manager.Scan())
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
            bool on = setting.Value == "on";
            var address = ParseId(setting.Id);
            if (setting.Value == "toggle")
            {
                var power = await this.manager.GetPower(address);
                switch (power)
                {
                    case CecPowerStatus.On | CecPowerStatus.TransitionStandbyToOn:
                        on = false;
                        break;
                    default:
                        on = true;
                        break;
                }
            }
            if (on)
            {
                await manager.SetStandby(address);
            }
            else
            {
                await manager.SetOn(address);
            }
        }

        private CecLogicalAddress ParseId(String id)
        {
            return (CecLogicalAddress)(Enum.Parse(typeof(CecLogicalAddress), id));
        }

        public String SubsystemName => "libCec";
    }
}
