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
                Value = IsOn(power) ? "on" : "off",
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
                    Value = IsOn(power) ? "on" : "off",
                    Subsystem = SubsystemName,
                    Bridge = "cec",
                    Name = name
                });
            }
            return results;
        }

        public async Task Set(TIn setting)
        {
            var address = ParseId(setting.Id);
            switch (setting.Value?.ToLowerInvariant())
            {
                case "on":
                    await manager.SendKeypress(address, CecControlCode.CEC_USER_CONTROL_CODE_POWER_ON_FUNCTION, true);
                    break;
                case "toggle":
                    var power = await this.manager.GetPower(address);
                    switch (power)
                    {
                        case CecPowerStatus.TransitionStandbyToOn:
                        case CecPowerStatus.On:
                            await manager.SendKeypress(address, CecControlCode.CEC_USER_CONTROL_CODE_POWER_OFF_FUNCTION, true);
                            break;
                        default:
                            await manager.SendKeypress(address, CecControlCode.CEC_USER_CONTROL_CODE_POWER_ON_FUNCTION, true);
                            break;
                    }
                    break;
                case "off":
                case "standby":
                    await manager.SendKeypress(address, CecControlCode.CEC_USER_CONTROL_CODE_POWER_OFF_FUNCTION, true);
                    break;
                case "input":
                    await manager.SendKeypress(address, CecControlCode.CEC_USER_CONTROL_CODE_SELECT_AV_INPUT_FUNCTION, true);
                    break;
            }
        }

        private CecLogicalAddress ParseId(String id)
        {
            return (CecLogicalAddress)(Enum.Parse(typeof(CecLogicalAddress), id));
        }

        private bool IsOn(CecPowerStatus status)
        {
            return status == CecPowerStatus.On || status == CecPowerStatus.TransitionStandbyToOn;
        }

        public String SubsystemName => "libCec";
    }
}
