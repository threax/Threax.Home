using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.Models;
using Threax.Home.InputModels;
using Threax.Home.Database;
using Threax.Home.ViewModels;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public SwitchSettingEntity MapSwitchSetting(SwitchSettingInput src, SwitchSettingEntity dest)
        {
            //dest.SwitchSettingId ignored
            dest.SwitchId = src.SwitchId;
            dest.Value = src.Value;
            dest.Brightness = src.Brightness;
            dest.HexColor = src.HexColor;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public SwitchSetting MapSwitchSetting(SwitchSettingEntity src, SwitchSetting dest)
        {
            dest.SwitchSettingId = src.SwitchId;
            dest.SwitchId = src.SwitchId;
            dest.Switch = src.Switch != null ? MapSwitch(src.Switch, new Switch()) : null;
            dest.Value = src.Value;
            dest.Brightness = src.Brightness;
            dest.HexColor = src.HexColor;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }
    }
}