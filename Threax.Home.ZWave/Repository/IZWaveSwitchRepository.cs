﻿using System;
using System.Collections.Generic;
using System.Text;
using Threax.Home.Core;

namespace Threax.Home.ZWave.Repository
{
    public interface IZWaveSwitchRepository<TIn, TOut> : ISwitchRepository<TIn, TOut>
       where TIn : ICoreSwitch, new()
       where TOut : ICoreSwitch, new()
    {

    }
}
