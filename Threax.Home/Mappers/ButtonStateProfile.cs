using System;
using System.Linq;
using Threax.Home.Database;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public ButtonStateEntity MapButtonState(ButtonStateInput src, ButtonStateEntity dest)
        {
            //dest.ButtonStateId ignored
            dest.Label = src.Label;
            dest.Icon = src.Icon;
            dest.Order = src.Order;
            dest.SwitchSettings = (src.SwitchSettings ?? Enumerable.Empty<SwitchSettingInput>()).Select(i => MapSwitchSetting(i, new SwitchSettingEntity())).ToList();
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public ButtonState MapButtonState(ButtonStateEntity src, ButtonState dest)
        {
            dest.ButtonStateId = src.ButtonStateId;
            dest.Label = src.Label;
            dest.Icon = src.Icon;
            dest.Order = src.Order;
            dest.SwitchSettings = (src.SwitchSettings ?? Enumerable.Empty<SwitchSettingEntity>()).Select(i => MapSwitchSetting(i, new SwitchSetting())).ToList();
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }
    }
}