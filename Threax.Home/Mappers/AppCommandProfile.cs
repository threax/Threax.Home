using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.InputModels;
using Threax.Home.Database;
using Threax.Home.ViewModels;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public AppCommand MapButtonState(ButtonStateEntity src, AppCommand dest)
        {
            dest.Name = src.Button.Label + " - " + src.Label;
            dest.ButtonStateId = src.ButtonStateId;

            return dest;
        }
    }
}