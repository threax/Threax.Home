using System;
using System.Collections.Generic;
using System.Text;
using Threax.Home.Core;

namespace Threax.Home.Colortouch.Repository
{
    public interface IColorTouchThermostatRepository<TIn, TOut> : IThermostatRepository<TIn, TOut>
        where TIn : ICoreThermostatSetting, new()
        where TOut : ICoreThermostat, new()
    {
    }
}
