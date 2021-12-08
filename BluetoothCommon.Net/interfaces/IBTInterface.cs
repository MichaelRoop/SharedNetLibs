using CommunicationStack.Net.interfaces;

namespace BluetoothCommon.Net.interfaces {

    /// <summary>Interface for communication channels passed to the stack</summary>
    public interface IBTInterface : ICommStackChannel {

        /// <summary>Fired on every Bluetooth device discovered</summary>
        event EventHandler<BTDeviceInfo> DiscoveredBTDevice;

        /// <summary>Fired on extra info gathered from a Bluetooth device</summary>
        event EventHandler<BTDeviceInfo> BT_DeviceInfoGathered;

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
        /// <param name="paired">true if you want a list of paired devices, otherise non-paired</param>
        void DiscoverDevicesAsync(bool paired);

        /// <summary>Request the extra info from device with reponse of BT_DeviceInfoGathered event</summary>
        /// <param name="deviceDataModel">The device to query</param>
        void GetDeviceInfoAsync(BTDeviceInfo deviceDataModel);

        /// <summary>Asynchrnous connection</summary>
        /// <param name="device">The device to connect to</param>
        void ConnectAsync(BTDeviceInfo device);


        /// <summary>Disconnect if connected</summary>
        void Disconnect();


        /// <summary>Unpair the device asynchronously. Wait for event on completion</summary>
        /// <param name="info">The Bluetooth device to unpair</param>
        void UnPairAsync(BTDeviceInfo info);


        /// <summary>Pair the device asynchronously. Wait for event on completion</summary>
        /// <param name="info">The Bluetooth device to pair</param>
        void PairgAsync(BTDeviceInfo info);


    }
}
