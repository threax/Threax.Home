using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Threax.Home.ModelSchemas
{
    [NoUi]
    [NoController]
    [NoRepository]
    public class ButtonState
    {
        [UiOrder]
        public String Label { get; set; }

        [UiOrder]
        [NoInputModel]
        [NoViewModel]
        public List<SwitchSetting> SwitchSettings { get; set; }

        [NoInputModel]
        [NoViewModel]
        public Button Button { get; set; }
    }
}
