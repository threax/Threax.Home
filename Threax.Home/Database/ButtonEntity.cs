using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threax.Home.Models;

namespace Threax.Home.Database
{
    public partial class ButtonEntity : IButton, IButtonId
    {
        [Key]
        public Guid ButtonId { get; set; }

        public String Label { get; set; }

        public int Order { get; set; }

        public ButtonType ButtonType { get; set; }

        public List<ButtonStateEntity> ButtonStates { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}