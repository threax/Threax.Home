#pragma once
#include "stdafx.h"

using namespace CEC;

class DeviceInfo
{
public:
	String Address;
	bool ActiveSource;
	String Vendor;
	String OsdString;
	String CecVersion;
	bool PowerStatus;
	String Language;
};

class CecManager
{
public:
	CecManager();

	~CecManager();

	void Start();

	void Stop();

	/// <summary>
	/// Scan the CEC bus and display device info.
	/// </summary>
	//void Scan();

	/// <summary>
	/// Get the power status of the specified device.
	/// </summary>
	/// <param name="address"></param>
	/// <returns></returns>
	cec_power_status GetPower(int address);

	//String GetName(int address);

	/// <summary>
	/// Set the device with the given address to on.
	/// </summary>
	void SetOn(int address);

	/// <summary>
	/// Set the device with the given address to standby or off.
	/// </summary>
	void SetStandby(int address);

	/// <summary>
	/// Set the hdmi port number of the cec adapter.
	/// </summary>
	/// <param name="port"></param>
	void SetHdmiPort(int device, uint8_t port);

	/// <summary>
	/// Reconnect to the CEC adapter.
	/// </summary>
	void Reconnect();

private:
	ICECAdapter* g_parser;
	ICECCallbacks         g_callbacks;
	libcec_configuration  g_config;
	std::string g_strPort;
};