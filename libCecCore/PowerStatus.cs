using System;
using System.Collections.Generic;
using System.Text;

namespace libCecCore
{
    public enum cec_power_status
    {
        CEC_POWER_STATUS_ON = 0x00,
        CEC_POWER_STATUS_STANDBY = 0x01,
        CEC_POWER_STATUS_IN_TRANSITION_STANDBY_TO_ON = 0x02,
        CEC_POWER_STATUS_IN_TRANSITION_ON_TO_STANDBY = 0x03,
        CEC_POWER_STATUS_UNKNOWN = 0x99
    }
}
