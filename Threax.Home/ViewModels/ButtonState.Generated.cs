using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.Models;
using Threax.Home.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.ViewModels 
{
       public partial class ButtonState : IButtonState, IButtonStateId, ICreatedModified
       {
        public Guid ButtonStateId { get; set; }

        [UiOrder(0, 15)]
        public String Label { get; set; }

        [UiOrder(0, 18)]
        public int Order { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
