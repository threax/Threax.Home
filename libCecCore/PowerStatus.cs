using System;
using System.Collections.Generic;
using System.Text;

namespace libCecCore
{
    public enum CecPowerStatus
    {
        On = 0x00,
        Standby = 0x01,
        TransitionStandbyToOn = 0x02,
        TransistionOnToStandby = 0x03,
        Unknown = 0x99
    }
}
