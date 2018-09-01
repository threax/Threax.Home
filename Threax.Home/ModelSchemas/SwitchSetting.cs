using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;
using Threax.Home.ValueProviders;

namespace Threax.Home.ModelSchemas
{
    [NoUi]
    [NoController]
    [NoRepository]
    [NoModelCollection]
    public class SwitchSetting
    {
        [DefineValueProvider(typeof(SwitchValueProvider))]
        public Guid SwitchId { get; set; }

        public String Value { get; set; }

        /// <summary>
        /// The brightness to set.
        /// </summary>
        public byte? Brightness { get; set; }

        /// <summary>
        /// The color to set.
        /// </summary>
        [MaxLength(450)]
        public string HexColor { get; set; }

        [NoInputModel]
        [NoViewModel]
        public ButtonState ButtonState { get; set; }
    }
}
