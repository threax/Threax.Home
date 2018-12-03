// libCecCoreNative.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

using namespace CEC;

void ListDevices(ICECAdapter *parser)
{
	cec_adapter_descriptor devices[10];
	//std::string strMessage = StringUtils::Format("libCEC version: %s, %s",
	//	parser->VersionToString(g_config.serverVersion).c_str(),
	//	parser->GetLibInfo());
	//PrintToStdOut(strMessage.c_str());

	int8_t iDevicesFound = parser->DetectAdapters(devices, 10, NULL);
	if (iDevicesFound <= 0)
	{
		//PrintToStdOut("Found devices: NONE");
	}
	else
	{
		//PrintToStdOut("Found devices: %d\n", iDevicesFound);

		for (int8_t iDevicePtr = 0; iDevicePtr < iDevicesFound; iDevicePtr++)
		{
			//PrintToStdOut("device:              %d", iDevicePtr + 1);
			//PrintToStdOut("com port:            %s", devices[iDevicePtr].strComName);
			//PrintToStdOut("vendor id:           %04x", devices[iDevicePtr].iVendorId);
			//PrintToStdOut("product id:          %04x", devices[iDevicePtr].iProductId);
			//PrintToStdOut("firmware version:    %d", devices[iDevicePtr].iFirmwareVersion);

			//if (devices[iDevicePtr].iFirmwareBuildDate != CEC_FW_BUILD_UNKNOWN)
			//{
			//	time_t buildTime = (time_t)devices[iDevicePtr].iFirmwareBuildDate;
			//	std::string strDeviceInfo;
			//	strDeviceInfo = StringUtils::Format("firmware build date: %s", asctime(gmtime(&buildTime)));
			//	strDeviceInfo = StringUtils::Left(strDeviceInfo, strDeviceInfo.length() > 1 ? (unsigned)(strDeviceInfo.length() - 1) : 0); // strip \n added by asctime
			//	strDeviceInfo.append(" +0000");
			//	PrintToStdOut(strDeviceInfo.c_str());
			//}

			//if (devices[iDevicePtr].adapterType != ADAPTERTYPE_UNKNOWN)
			//{
			//	PrintToStdOut("type:                %s", parser->ToString(devices[iDevicePtr].adapterType));
			//}

			//PrintToStdOut("");
		}
	}
}