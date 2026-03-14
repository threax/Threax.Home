using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threax.Home.Models;

namespace Threax.Home.Database
{
    public partial class ButtonStateEntity : IButtonState, IButtonStateId
    {
        [Key]
        public Guid ButtonStateId { get; set; }

        public String Label { get; set; }

        public ButtonStateIcon Icon { get; set; }

        public int Order { get; set; }

        public List<SwitchSettingEntity> SwitchSettings { get; set; }

        public Guid ButtonId { get; set; }

        public ButtonEntity Button { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}