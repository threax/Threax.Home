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
       public partial class Button : IButton, IButtonId, ICreatedModified
       {
        public Guid ButtonId { get; set; }

        public String Label { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
