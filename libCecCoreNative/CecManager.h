#pragma once
#include "stdafx.h"

using namespace CEC;

typedef void(*ScanCallback)(cec_logical_address address);

typedef void(*StringRetrieverCallback)(String value);

class CecManager
{
public:
	CecManager(const char* port);

	~CecManager();

	void Start();

	void Stop();

	/// <summary>
	/// Scan the CEC bus and display device info.
	/// </summary>
	void Scan(ScanCallback cb);

	/// <summary>
	/// Get the power status of the specified device.
	/// </summary>
	/// <param name="address"></param>
	/// <returns></returns>
	cec_power_status GetPower(cec_logical_address address);

	void GetName(StringRetrieverCallback cb, cec_logical_address address);

	/// <summary>
	/// Set the device with the given address to on.
	/// </summary>
	void SetOn(cec_logical_address address);

	/// <summary>
	/// Set the device with the given address to standby or off.
	/// </summary>
	void SetStandby(cec_logical_address address);

	/// <summary>
	/// Set the hdmi port number of the cec adapter.
	/// </summary>
	/// <param name="port"></param>
	void SetHdmiPort(cec_logical_address device, uint8_t port);

	/// <summary>
	/// Reconnect to the CEC adapter.
	/// </summary>
	void Reconnect();

	/*!
	 * @brief Send a keypress to a device on the CEC bus.
	 * @param iDestination The logical address of the device to send the message to.
	 * @param key The key to send.
	 * @param bWait True to wait for a response, false otherwise.
	 * @return True when the keypress was acked, false otherwise.
	 */
	bool SendKeypress(cec_logical_address iDestination, cec_user_control_code key, bool bWait);

	/*!
	 * @brief Send a key release to a device on the CEC bus.
	 * @param iDestination The logical address of the device to send the message to.
	 * @param bWait True to wait for a response, false otherwise.
	 * @return True when the key release was acked, false otherwise.
	 */
	bool SendKeyRelease(cec_logical_address iDestination, bool bWait);

	cec_vendor_id GetVendor(cec_logical_address address);

private:
	ICECAdapter* g_parser;
	ICECCallbacks         g_callbacks;
	libcec_configuration  g_config;
	std::string g_strPort;
};