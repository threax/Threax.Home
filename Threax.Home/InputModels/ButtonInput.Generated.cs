using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.InputModels 
{
    [HalModel]
    public partial class ButtonInput : IButton
    {
        [UiOrder(0, 12)]
        public String Label { get; set; }

        [UiOrder(0, 15)]
        public int Order { get; set; }

        [UiOrder(0, 18)]
        public ButtonType ButtonType { get; set; }

    }
}
