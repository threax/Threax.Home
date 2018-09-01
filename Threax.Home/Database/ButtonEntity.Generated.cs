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

namespace Threax.Home.Database 
{
    public partial class ButtonEntity : IButton, IButtonId, ICreatedModified
    {
        [Key]
        public Guid ButtonId { get; set; }

        public String Label { get; set; }

        public List<ButtonStateEntity> ButtonStates { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
