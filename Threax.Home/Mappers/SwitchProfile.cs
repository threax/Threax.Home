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
        public SwitchEntity MapSwitch(SwitchInput src, SwitchEntity dest)
        {
            //dest.SwitchId ignored
            dest.Name = src.Name;
            //dest.Subsystem ignored
            //dest.Bridge ignored
            //dest.Id ignored
            dest.Value = src.Value;
            dest.HexColor = src.HexColor;
            dest.Brightness = src.Brightness;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public Switch MapSwitch(SwitchEntity src, Switch dest)
        {
            dest.SwitchId = src.SwitchId;
            dest.Name = src.Name;
            dest.Value = src.Value;
            dest.HexColor = src.HexColor;
            dest.Brightness = src.Brightness;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }

        public SwitchEntity MapSwitch(SwitchEntity src, SwitchEntity dest)
        {
            //dest.SwitchId ignored
            //dest.Name ignored
            //dest.Subsystem ignored
            //dest.Bridge ignored
            //dest.Id ignored
            dest.Value = src.Value;
            dest.HexColor = src.HexColor;
            dest.Brightness = src.Brightness;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }

        public SwitchEntity MapSwitch(SetSwitchInput src, SwitchEntity dest)
        {
            //dest.SwitchId ignored
            //dest.Name ignored
            //dest.Subsystem ignored
            //dest.Bridge ignored
            //dest.Id ignored
            dest.Value = src.Value;
            dest.HexColor = src.HexColor;
            dest.Brightness = src.Brightness;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }
    }
}