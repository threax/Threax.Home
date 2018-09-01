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
    public partial interface ISwitchSetting 
    {
        Guid SwitchId { get; set; }

        String Value { get; set; }

        int? Brightness { get; set; }

        String HexColor { get; set; }

    }

    public partial interface ISwitchSettingId
    {
        Guid SwitchSettingId { get; set; }
    }    

    public partial interface ISwitchSettingQuery
    {
        Guid? SwitchSettingId { get; set; }

    }
}