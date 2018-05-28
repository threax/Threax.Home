using MfiSharp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.MFi.Services;

namespace Threax.Home.MFi.Repository
{
    public interface IMfiSwitchRepository<TIn, TOut> : ISwitchRepository<TIn, TOut>
       where TIn : ISwitch, new()
       where TOut : ISwitch, new()
    {
        
    }
}
