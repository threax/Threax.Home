using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;
using Threax.Home.Models;

namespace Threax.Home.ModelSchemas
{
    public class Button
    {
        [UiOrder]
        public String Label { get; set; }

        [UiOrder]
        public int Order { get; set; }

        [UiOrder]
        public ButtonType ButtonType { get; set; }

        [UiOrder]
        [NoInputModel]
        [NoViewModel]
        public List<ButtonState> ButtonStates { get; set; }
    }
}
