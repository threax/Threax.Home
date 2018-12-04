using System;
using System.Collections.Generic;
using System.Text;

namespace libCecCore
{
    public enum cec_logical_address
    {
        CECDEVICE_UNKNOWN = -1, //not a valid logical address
        CECDEVICE_TV = 0,
        CECDEVICE_RECORDINGDEVICE1 = 1,
        CECDEVICE_RECORDINGDEVICE2 = 2,
        CECDEVICE_TUNER1 = 3,
        CECDEVICE_PLAYBACKDEVICE1 = 4,
        CECDEVICE_AUDIOSYSTEM = 5,
        CECDEVICE_TUNER2 = 6,
        CECDEVICE_TUNER3 = 7,
        CECDEVICE_PLAYBACKDEVICE2 = 8,
        CECDEVICE_RECORDINGDEVICE3 = 9,
        CECDEVICE_TUNER4 = 10,
        CECDEVICE_PLAYBACKDEVICE3 = 11,
        CECDEVICE_RESERVED1 = 12,
        CECDEVICE_RESERVED2 = 13,
        CECDEVICE_FREEUSE = 14,
        CECDEVICE_UNREGISTERED = 15,
        CECDEVICE_BROADCAST = 15
    }
}
