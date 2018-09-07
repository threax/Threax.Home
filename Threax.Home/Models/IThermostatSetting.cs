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
    public partial interface IThermostatSetting
    {
        //Customize main interface here, see ThermostatSetting.Generated for generated code
    }  

    public partial interface IThermostatSettingId
    {
        //Customize id interface here, see ThermostatSetting.Generated for generated code
    }    

    public partial interface IThermostatSettingQuery
    {
        //Customize query interface here, see ThermostatSetting.Generated for generated code
    }
}