using BluetoothLE.Net.DataModels;
using BluetoothLE.Net.Enumerations;
using Common.Net.Network;
using CommunicationStack.Net.interfaces;
using System;

namespace BluetoothLE.Net.interfaces {

    /// <summary>Interface for Bluetooth LE devices</summary>
    public interface IBLETInterface : ICommStackChannel {

        /// <summary>Event raised when a device is dropped from OS</summary>
        event EventHandler<string> DeviceRemoved;

        /// <summary>Event raised when a device is discovered</summary>
        event EventHandler<BluetoothLEDeviceInfo> DeviceDiscovered;

        /// <summary>Will post this at end of enumeration since early adds are not necessarly complete</summary>
        event EventHandler<bool> DeviceDiscoveryCompleted;

        /// <summary>Raised when BLE updates a device properties</summary>
        event EventHandler<NetPropertiesUpdateDataModel> DeviceUpdated;

        /// <summary>Raised when BLE gets all the info from a device which requires connection</summary>
        event EventHandler<BLEGetInfoStatus> DeviceInfoAssembled;

        /// <summary>Raised on BLE connection attempt</summary>
        event EventHandler<BLEGetInfoStatus> DeviceConnectResult;


        /// <summary>Raised when a characteristic read value changes</summary>
        event EventHandler<BLE_CharacteristicReadResult> CharacteristicReadValueChanged;


        /// <summary>Start or restart the device discovery</summary>
        void DiscoverDevices();

        /// <summary>Cancel any ongoing discovery</summary>
        void CancelDiscoverDevices();

        void Connect(BluetoothLEDeviceInfo deviceInfo);


        void GetInfo(BluetoothLEDeviceInfo deviceInfo);


        void Disconnect();

    }
}
