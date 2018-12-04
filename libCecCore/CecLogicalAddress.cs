using System;
using System.Collections.Generic;
using System.Text;

namespace libCecCore
{
    public enum CecLogicalAddress
    {
        Unknown = -1, //not a valid logical address
        TV = 0,
        RecordingDevice1 = 1,
        RecordingDevice2 = 2,
        Tuner1 = 3,
        PlaybackDevice1 = 4,
        AudioSystem = 5,
        Tuner2 = 6,
        Tuner3 = 7,
        PlaybackDevice2 = 8,
        RecordingDevice3 = 9,
        Tuner4 = 10,
        PlaybackDevice3 = 11,
        Reserved1 = 12,
        Reserved2 = 13,
        FreeUse = 14,
        Unregistered = 15,
        Broadcast = 15
    }
}
