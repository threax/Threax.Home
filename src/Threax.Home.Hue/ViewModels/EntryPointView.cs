﻿using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Hue.Controllers;

namespace Threax.Home.Hue.ViewModels
{
    [HalModel]
    [HalSelfActionLink(EntryPointController.Rels.Get, typeof(EntryPointController))]
    [HalActionLink(BridgeController.Rels.ListBridges, typeof(BridgeController))]
    public class EntryPointView
    {
    }
}
