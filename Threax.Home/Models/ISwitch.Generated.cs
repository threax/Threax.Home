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

        String Subsystem { get; set; }

        String Bridge { get; set; }

        String Id { get; set; }

        String Value { get; set; }

        int? Brightness { get; set; }

        String HexColor { get; set; }

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