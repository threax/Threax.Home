// libCecCoreNative.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "CecManager.h"
#include <string>;
#include <sstream>

using namespace CEC;

CecManager::CecManager()
{
	g_config.Clear();
	g_callbacks.Clear();
	snprintf(g_config.strDeviceName, 13, "CECTester");
	g_config.clientVersion = LIBCEC_VERSION_CURRENT;
	g_config.bActivateSource = 0;
	/*g_callbacks.logMessage = &CecLogMessage;
	g_callbacks.keyPress = &CecKeyPress;
	g_callbacks.commandReceived = &CecCommand;
	g_callbacks.alert = &CecAlert;
	g_config.callbacks = &g_callbacks;*/

	
}

CecManager::~CecManager()
{

}

void CecManager::Start()
{
	if (g_config.deviceTypes.IsEmpty())
	{
		//if (!g_bSingleCommand)
		//	std::cout << "No device type given. Using 'recording device'" << std::endl;
		g_config.deviceTypes.Add(CEC_DEVICE_TYPE_RECORDING_DEVICE);
	}

	g_parser = CECInitialise(&g_config);

	// init video on targets that need this
	g_parser->InitVideoStandalone();

	

	//if (!g_bSingleCommand)
	//	std::cout << "no serial port given. trying autodetect: ";
	cec_adapter_descriptor devices[10];
	uint8_t iDevicesFound = g_parser->DetectAdapters(devices, 10, NULL, true);
	if (iDevicesFound <= 0)
	{
		/*if (g_bSingleCommand)
			std::cout << "autodetect ";
		std::cout << "FAILED" << std::endl;
		UnloadLibCec(g_parser);
		return 1;*/
		//error
	}
	else
	{
		/*if (!g_bSingleCommand)
		{
			std::cout << std::endl << " path:     " << devices[0].strComPath << std::endl <<
				" com port: " << devices[0].strComName << std::endl << std::endl;
		}*/
		g_strPort = devices[0].strComName;
	}

	//PrintToStdOut("opening a connection to the CEC adapter...");

	if (!g_parser->Open(g_strPort.c_str()))
	{
		/*PrintToStdOut("unable to open the device on port %s", g_strPort.c_str());
		UnloadLibCec(g_parser);
		return 1;*/
	}
}

void CecManager::Stop()
{

	g_parser->Close();
	//UnloadLibCec(g_parser);
}

//void CecManager::Scan()
//{
//	cec_adapter_descriptor devices[10];
//	//std::string strMessage = StringUtils::Format("libCEC version: %s, %s",
//	//	parser->VersionToString(g_config.serverVersion).c_str(),
//	//	parser->GetLibInfo());
//	//PrintToStdOut(strMessage.c_str());
//
//	int8_t iDevicesFound = g_parser->DetectAdapters(devices, 10, NULL);
//	if (iDevicesFound <= 0)
//	{
//		//PrintToStdOut("Found devices: NONE");
//	}
//	else
//	{
//		//PrintToStdOut("Found devices: %d\n", iDevicesFound);
//
//		for (int8_t iDevicePtr = 0; iDevicePtr < iDevicesFound; iDevicePtr++)
//		{
//			//PrintToStdOut("device:              %d", iDevicePtr + 1);
//			//PrintToStdOut("com port:            %s", devices[iDevicePtr].strComName);
//			//PrintToStdOut("vendor id:           %04x", devices[iDevicePtr].iVendorId);
//			//PrintToStdOut("product id:          %04x", devices[iDevicePtr].iProductId);
//			//PrintToStdOut("firmware version:    %d", devices[iDevicePtr].iFirmwareVersion);
//
//			//if (devices[iDevicePtr].iFirmwareBuildDate != CEC_FW_BUILD_UNKNOWN)
//			//{
//			//	time_t buildTime = (time_t)devices[iDevicePtr].iFirmwareBuildDate;
//			//	std::string strDeviceInfo;
//			//	strDeviceInfo = StringUtils::Format("firmware build date: %s", asctime(gmtime(&buildTime)));
//			//	strDeviceInfo = StringUtils::Left(strDeviceInfo, strDeviceInfo.length() > 1 ? (unsigned)(strDeviceInfo.length() - 1) : 0); // strip \n added by asctime
//			//	strDeviceInfo.append(" +0000");
//			//	PrintToStdOut(strDeviceInfo.c_str());
//			//}
//
//			//if (devices[iDevicePtr].adapterType != ADAPTERTYPE_UNKNOWN)
//			//{
//			//	PrintToStdOut("type:                %s", parser->ToString(devices[iDevicePtr].adapterType));
//			//}
//
//			//PrintToStdOut("");
//		}
//	}
//}

void CecManager::SetOn(int address)
{
	g_parser->PowerOnDevices((cec_logical_address)address);
}

void CecManager::SetStandby(int address)
{
	g_parser->StandbyDevices((cec_logical_address)address);
}

cec_power_status CecManager::GetPower(int address)
{
	return g_parser->GetDevicePowerStatus((cec_logical_address)address);
}

void CecManager::SetHdmiPort(int device, uint8_t port)
{
	g_parser->SetHDMIPort((cec_logical_address)device, port);
}

void CecManager::Reconnect()
{
	bool bReactivate = g_parser->IsLibCECActiveSource();

	//PrintToStdOut("closing the connection");
	g_parser->Close();

	//PrintToStdOut("opening a new connection");
	g_parser->Open(g_strPort.c_str());

}

// Interop

CecManager* CecManager_Create() 
{
	return new CecManager();
}

void CecManager_Delete(CecManager* ptr)
{
	delete ptr;
}

void CecManager_Start(CecManager* ptr)
{
	ptr->Start();
}

void CecManager_Stop(CecManager* ptr)
{
	ptr->Stop();
}

/// <summary>
/// Scan the CEC bus and display device info.
/// </summary>
//void CecManager_Scan();

cec_power_status CecManager_GetPower(CecManager* ptr, int address)
{
	return ptr->GetPower(address);
}

//String CecManager_GetName(CecManager* ptr, int address)
//{
//	return ptr->GetName(address);
//}

void CecManager_SetOn(CecManager* ptr, int address)
{
	return ptr->SetOn(address);
}

void CecManager_SetStandby(CecManager* ptr, int address)
{
	return ptr->SetStandby(address);
}

void CecManager_SetHdmiPort(CecManager* ptr, int device, uint8_t port)
{
	return ptr->SetHdmiPort(device, port);
}

void CecManager_Reconnect(CecManager* ptr)
{
	return ptr->Reconnect();
}