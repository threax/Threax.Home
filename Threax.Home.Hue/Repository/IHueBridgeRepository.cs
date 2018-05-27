﻿using System.Collections.Generic;
using Threax.Home.Hue.ViewModels;

namespace Threax.Home.Hue.Repository
{
    public interface IHueBridgeRepository
    {
        IEnumerable<BridgeView> List();
    }
}