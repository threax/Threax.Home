using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Threax.Home.Models
{
    public partial interface ISwitch
    {
        String Name { get; set; }

        String Value { get; set; }

        String HexColor { get; set; }

    }

    public partial interface ISwitch_Subsystem
    {
        String Subsystem { get; set; }

    }

    public partial interface ISwitch_Bridge
    {
        String Bridge { get; set; }

    }

    public partial interface ISwitch_Id
    {
        String Id { get; set; }

    }

    public partial interface ISwitch_Brightness
    {
        int? Brightness { get; set; }

    }

    public partial interface ISwitchId
    {
        Guid SwitchId { get; set; }
    }

    public partial interface ISwitchQuery
    {
        Guid? SwitchId { get; set; }

    }
}