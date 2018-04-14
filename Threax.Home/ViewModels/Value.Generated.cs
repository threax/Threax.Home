using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Tracking;
using Threax.Home.Models;
using Threax.Home.Controllers.Api;
using Threax.AspNetCore.Models;

namespace Threax.Home.ViewModels 
{
    public partial class Value : IValue, IValueId , ICreatedModified
    {
        [UiOrder]
        public Guid ValueId { get; set; }

        [UiOrder]
        public String Name { get; set; }

        [UiOrder]
        public DateTime Created { get; set; }

        [UiOrder]
        public DateTime Modified { get; set; }

    }
}
