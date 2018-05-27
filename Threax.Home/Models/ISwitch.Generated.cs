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
        String Subsystem { get; set; }

        String Bridge { get; set; }

        String Name { get; set; }

        String PrettyName { get; set; }

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