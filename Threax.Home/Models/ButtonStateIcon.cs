using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Models
{
    public enum ButtonStateIcon
    {
        Unknown = 0,
        [Display(Name = "Bulb Off")]
        BulbOff = 1,
        [Display(Name = "Bulb On")]
        BulbOn = 2,
        [Display(Name = "Fan Off")]
        FanOff = 3,
        [Display(Name = "Fan Low")]
        FanLow = 4,
        [Display(Name = "Fan Medium")]
        FanMedium = 5,
        [Display(Name = "Fan High")]
        FanHigh = 6,
    }
}
