// libCecCoreNative.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "CecManager.h"
#include <string>;
#include <sstream>

using namespace CEC;

CecManager::CecManager(int hdmiPort, const char* port)
{
	g_config.Clear();
	g_callbacks.Clear();
	snprintf(g_config.strDeviceName, 13, "CECTester");
	g_config.clientVersion = LIBCEC_VERSION_CURRENT;
	g_config.bActivateSource = 0;
	if (hdmiPort > 0) {
		g_config.iHDMIPort = hdmiPort;
	}

	g_strPort = port;
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

	//This dead code looks for a device

	////if (!g_bSingleCommand)
	////	std::cout << "no serial port given. trying autodetect: ";
	//cec_adapter_descriptor devices[10];
	//uint8_t iDevicesFound = g_parser->DetectAdapters(devices, 10, NULL, true);
	//if (iDevicesFound <= 0)
	//{
	//	/*if (g_bSingleCommand)
	//		std::cout << "autodetect ";
	//	std::cout << "FAILED" << std::endl;
	//	UnloadLibCec(g_parser);
	//	return 1;*/
	//	//error
	//}
	//else
	//{
	//	/*if (!g_bSingleCommand)
	//	{
	//		std::cout << std::endl << " path:     " << devices[0].strComPath << std::endl <<
	//			" com port: " << devices[0].strComName << std::endl << std::endl;
	//	}*/
	//	g_strPort = devices[0].strComName;
	//}

	//End device search

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

void CecManager::Scan(ScanCallback cb)
{
	cec_logical_addresses addresses = g_parser->GetActiveDevices();
	cec_logical_address activeSource = g_parser->GetActiveSource();
	for (uint8_t iPtr = 0; iPtr < 16; iPtr++)
	{
		if (addresses[iPtr])
		{
			cb((cec_logical_address)iPtr);
			/*uint64_t iVendorId = parser->GetDeviceVendorId((cec_logical_address)iPtr);
			uint16_t iPhysicalAddress = parser->GetDevicePhysicalAddress((cec_logical_address)iPtr);
			bool     bActive = parser->IsActiveSource((cec_logical_address)iPtr);
			cec_version iCecVersion = parser->GetDeviceCecVersion((cec_logical_address)iPtr);
			cec_power_status power = parser->GetDevicePowerStatus((cec_logical_address)iPtr);
			std::string osdName = parser->GetDeviceOSDName((cec_logical_address)iPtr);
			std::string strAddr;
			strAddr = StringUtils::Format("%x.%x.%x.%x", (iPhysicalAddress >> 12) & 0xF, (iPhysicalAddress >> 8) & 0xF, (iPhysicalAddress >> 4) & 0xF, iPhysicalAddress & 0xF);
			std::string lang = parser->GetDeviceMenuLanguage((cec_logical_address)iPtr);

			strLog += StringUtils::Format("device #%X: %s\n", (int)iPtr, parser->ToString((cec_logical_address)iPtr));
			strLog += StringUtils::Format("address:       %s\n", strAddr.c_str());
			strLog += StringUtils::Format("active source: %s\n", (bActive ? "yes" : "no"));
			strLog += StringUtils::Format("vendor:        %s\n", parser->ToString((cec_vendor_id)iVendorId));
			strLog += StringUtils::Format("osd string:    %s\n", osdName.c_str());
			strLog += StringUtils::Format("CEC version:   %s\n", parser->ToString(iCecVersion));
			strLog += StringUtils::Format("power status:  %s\n", parser->ToString(power));
			strLog += StringUtils::Format("language:      %s\n", lang.c_str());
			strLog.append("\n\n");*/
		}
	}
}

void CecManager::SetOn(cec_logical_address address)
{
	g_parser->PowerOnDevices(address);
}

void CecManager::SetStandby(cec_logical_address address)
{
	g_parser->StandbyDevices(address);
}

cec_power_status CecManager::GetPower(cec_logical_address address)
{
	return g_parser->GetDevicePowerStatus(address);
}

void CecManager::SetHdmiPort(cec_logical_address device, uint8_t port)
{
	g_parser->SetHDMIPort(device, port);
}

void CecManager::SendHdmiPortChanged(uint8_t port)
{
	//Send the raw input changed command
	//Limit range from 0-15
	if (port > 0 && port < 16) {
		CEC::cec_command command;
		command.PushBack(0x4f);
		command.PushBack(0x82);
		switch (port) {
		default:
			command.PushBack(0x30);
			break;
			//return; //Break out of this function if not supported
		case 1:
			command.PushBack(0x10);
			break;
		case 2:
			command.PushBack(0x20);
			break;
		case 3:
			command.PushBack(0x30);
			break;
		case 4:
			command.PushBack(0x40);
			break;
		}
		command.PushBack(0x00);
		g_parser->Transmit(command);
	}
}

void CecManager::Reconnect()
{
	bool bReactivate = g_parser->IsLibCECActiveSource();

	//PrintToStdOut("closing the connection");
	g_parser->Close();

	//PrintToStdOut("opening a new connection");
	g_parser->Open(g_strPort.c_str());

}

void CecManager::GetName(StringRetrieverCallback cb, cec_logical_address address)
{
	std::string osdName = "not working"; //This works fine
	//std::string osdName = g_parser->GetDeviceOSDName(address).c_str(); calling this function seems to break it
	cb(osdName.c_str());
}

cec_vendor_id CecManager::GetVendor(cec_logical_address address)
{
	return (cec_vendor_id)g_parser->GetDeviceVendorId(address);
}

bool CecManager::SendKeypress(cec_logical_address iDestination, cec_user_control_code key, bool bWait)
{
	return g_parser->SendKeypress(iDestination, key, bWait);
}

/*!
 * @brief Send a key release to a device on the CEC bus.
 * @param iDestination The logical address of the device to send the message to.
 * @param bWait True to wait for a response, false otherwise.
 * @return True when the key release was acked, false otherwise.
 */
bool CecManager::SendKeyRelease(cec_logical_address iDestination, bool bWait)
{
	return g_parser->SendKeyRelease(iDestination, bWait);
}

// Interop

extern "C" _AnomalousExport CecManager* CecManager_Create(int hdmiPort, const char* port)
{
	return new CecManager(hdmiPort, port);
}

extern "C" _AnomalousExport void CecManager_Delete(CecManager* ptr)
{
	delete ptr;
}

extern "C" _AnomalousExport void CecManager_Start(CecManager* ptr)
{
	ptr->Start();
}

extern "C" _AnomalousExport void CecManager_Stop(CecManager* ptr)
{
	ptr->Stop();
}

/// <summary>
/// Scan the CEC bus and display device info.
/// </summary>
extern "C" _AnomalousExport void CecManager_Scan(CecManager* ptr, ScanCallback cb)
{
	ptr->Scan(cb);
}

extern "C" _AnomalousExport cec_power_status CecManager_GetPower(CecManager* ptr, cec_logical_address address)
{
	return ptr->GetPower(address);
}

extern "C" _AnomalousExport void CecManager_GetName(CecManager* ptr, StringRetrieverCallback cb, cec_logical_address address)
{
	return ptr->GetName(cb, address);
}

extern "C" _AnomalousExport void CecManager_SetOn(CecManager* ptr, cec_logical_address address)
{
	return ptr->SetOn(address);
}

extern "C" _AnomalousExport void CecManager_SetStandby(CecManager* ptr, cec_logical_address address)
{
	return ptr->SetStandby(address);
}

extern "C" _AnomalousExport void CecManager_SetHdmiPort(CecManager* ptr, cec_logical_address device, uint8_t port)
{
	return ptr->SetHdmiPort(device, port);
}

extern "C" _AnomalousExport void CecManager_SendHdmiPortChanged(CecManager * ptr, uint8_t port)
{
	return ptr->SendHdmiPortChanged(port);
}

extern "C" _AnomalousExport void CecManager_Reconnect(CecManager* ptr)
{
	return ptr->Reconnect();
}

extern "C" _AnomalousExport cec_vendor_id CecManager_GetVendor(CecManager* ptr, cec_logical_address address)
{
	return ptr->GetVendor(address);
}

extern "C" _AnomalousExport bool CecManager_SendKeypress(CecManager * ptr, cec_logical_address iDestination, cec_user_control_code key, bool bWait)
{
	return ptr->SendKeypress(iDestination, key, bWait);
}

extern "C" _AnomalousExport bool CecManager_SendKeyRelease(CecManager * ptr, cec_logical_address iDestination, bool bWait)
{
	return ptr->SendKeyRelease(iDestination, bWait);
}