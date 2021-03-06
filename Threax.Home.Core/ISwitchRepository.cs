﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public interface ISwitchRepository
    {
        String SubsystemName { get; }
    }

    public interface ISwitchRepository<TIn, TOut> : ISwitchRepository
       where TIn : ICoreSwitch, new()
       where TOut : ICoreSwitch, new()
    {
        Task<TOut> Get(string bridge, string id);
        Task<IEnumerable<TOut>> List();
        Task Set(TIn setting);
    }
}
