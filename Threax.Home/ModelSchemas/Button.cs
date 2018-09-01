using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Threax.Home.ModelSchemas
{
    public class Button
    {
        public String Label { get; set; }

        [NoInputModel]
        [NoViewModel]
        public List<ButtonSetting> ButtonSettings { get; set; }
    }
}
