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
    public partial interface IButtonSetting 
    {
        Guid SwitchId { get; set; }

        String Value { get; set; }

        int? Brightness { get; set; }

        String HexColor { get; set; }

    }

    public partial interface IButtonSettingId
    {
        Guid ButtonSettingId { get; set; }
    }    

    public partial interface IButtonSettingQuery
    {
        Guid? ButtonSettingId { get; set; }

    }
}