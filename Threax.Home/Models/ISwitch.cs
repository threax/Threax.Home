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
    public partial interface ISwitch : Threax.Home.Core.ICoreSwitch
    {
        //Customize main interface here, see Switch.Generated for generated code
    }  

    public partial interface ISwitchId
    {
        //Customize id interface here, see Switch.Generated for generated code
    }    

    public partial interface ISwitchQuery
    {
        //Customize query interface here, see Switch.Generated for generated code
    }
}