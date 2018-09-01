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
    public partial interface IButtonState 
    {
        String Label { get; set; }

    }

    public partial interface IButtonStateId
    {
        Guid ButtonStateId { get; set; }
    }    

    public partial interface IButtonStateQuery
    {
        Guid? ButtonStateId { get; set; }

    }
}