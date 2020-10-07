using CommunicationStack.Net.interfaces;
using System;

namespace BluetoothCommon.Net.interfaces {

    /// <summary>Interface for communication channels passed to the stack</summary>
    public interface IBTInterface : ICommStackChannel {

        /// <summary>Fired on every Bluetooth device discovered</summary>
        event EventHandler<BTDeviceInfo> DiscoveredBTDevice;

        /// <summary>Fired when async discovery completed of Bluetooth devices</summary>
        event EventHandler<bool> DiscoveryComplete;

        /// <summary>Raised when the async connection is completed</summary>
        event EventHandler<bool> ConnectionCompleted;

        /// <summary>Raised when pairing with BT</summary>
        event EventHandler<BT_PairInfoRequest> BT_PairInfoRequested;

        /// <summary>Raised on completion of pair operation</summary>
        event EventHandler<BTPairOperationStatus> BT_PairStatus;

        /// <summary>Raised on completion of unpair operation</summary>
        event EventHandler<BTUnPairOperationStatus> BT_UnPairStatus;

        /// <summary>Async retrieval of Bluetooth devices</summary>
        void DiscoverDevicesAsync();


        /// <summary>Asynchrnous connection</summary>
        /// <param name="device">The device to connect to</param>
        void ConnectAsync(BTDeviceInfo device);


        /// <summary>Synchronous connection</summary>
        /// <param name="device">The device information for connection</param>
        /// <returns>true on success, otherwise false</returns>
        bool Connect(BTDeviceInfo device);


        /// <summary>Disconnect if connected</summary>
        void Disconnect();

    }
}
