using System;
using System.Collections.Generic;
using System.Text;

namespace libCecCore
{
    public class DeviceInfo
    {
        public String Address { get; set; }

        public bool ActiveSource { get; set; }

        public String Vendor { get; set; }

        public String OsdString { get; set; }

        public String CecVersion { get; set; }

        public bool PowerStatus { get; set; }

        public String Language { get; set; }
    }
}
