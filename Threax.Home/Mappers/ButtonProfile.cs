using System;
using System.Linq;
using Threax.Home.Database;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public ButtonEntity MapButton(ButtonInput src, ButtonEntity dest)
        {
            //dest.ButtonId ignored
            dest.Label = src.Label;
            dest.Order = src.Order;
            dest.ButtonType = src.ButtonType;
            dest.ButtonStates = (src.ButtonStates ?? Enumerable.Empty<ButtonStateInput>()).Select(i => MapButtonState(i, new ButtonStateEntity())).ToList();
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public Button MapButton(ButtonEntity src, Button dest)
        {
            dest.ButtonId = src.ButtonId;
            dest.Label = src.Label;
            dest.Order = src.Order;
            dest.ButtonType = src.ButtonType;
            dest.ButtonStates = (src.ButtonStates ?? Enumerable.Empty<ButtonStateEntity>()).Select(i => MapButtonState(i, new ButtonState())).ToList();
            dest.Created = src.Created;
            dest.Modified = src.Modified;
            dest.ButtonStates?.Sort((i, j) => i.Order - j.Order);
            SetCurrentIcon(dest, GetSwitchValue(dest));

            return dest;
        }

        public Button MapButton(ButtonEntity src, SwitchEntity liveSwitch, Button dest)
        {
            var mapped = MapButton(src, dest);
            SetCurrentIcon(mapped, liveSwitch?.Value ?? GetSwitchValue(mapped));
            return mapped;
        }

        private static string GetSwitchValue(Button mapped)
        {
            return mapped.ButtonStates.FirstOrDefault()?.SwitchSettings.FirstOrDefault()?.Switch?.Value;
        }

        public void SetCurrentIcon(Button dest, String currentValue)
        {
            if (dest.ButtonStates == null)
            {
                return;
            }

            foreach (var state in dest.ButtonStates)
            {
                var switchSettings = state.SwitchSettings.FirstOrDefault();
                if (switchSettings == null)
                {
                    continue;
                }

                if (switchSettings.Value == currentValue)
                {
                    dest.CurrentIcon = state.Icon;
                    return;
                }
            }
        }
    }
}