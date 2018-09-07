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
    public partial interface IButton 
    {
        String Label { get; set; }

        int Order { get; set; }

    }

    public partial interface IButtonId
    {
        Guid ButtonId { get; set; }
    }    

    public partial interface IButtonQuery
    {
        Guid? ButtonId { get; set; }

    }
}