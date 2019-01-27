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
    public partial class SwitchSettingEntity : ISwitchSetting, ISwitchSettingId, ICreatedModified
    {
        [Key]
        public Guid SwitchSettingId { get; set; }

        public Guid SwitchId { get; set; }

        public String Value { get; set; }

        public int? Brightness { get; set; }

        [MaxLength(450, ErrorMessage = "Hex Color must be less than 450 characters.")]
        public String HexColor { get; set; }

        public Guid ButtonStateId { get; set; }

        public ButtonStateEntity ButtonState { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public SwitchEntity Switch { get; set; }
    }
}