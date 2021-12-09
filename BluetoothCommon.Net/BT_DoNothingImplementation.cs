using BluetoothCommon.Net.Enumerations;
using BluetoothCommon.Net.interfaces;

namespace BluetoothCommon.Net {

    /// <summary>
    /// Do nothing implementation for item not OS implemented for common NET Wrappper
    /// </summary>
    public class BT_DoNothingImplementation : IBTInterface {

        public event EventHandler<BTDeviceInfo>? DiscoveredBTDevice;
        public event EventHandler<BTDeviceInfo>? BT_DeviceInfoGathered;
        public event EventHandler<bool>? DiscoveryComplete;
        public event EventHandler<bool>? ConnectionCompleted;
        public event EventHandler<BT_PairInfoRequest>? BT_PairInfoRequested;
        public event EventHandler<BTPairOperationStatus>? BT_PairStatus;
        public event EventHandler<BTUnPairOperationStatus>? BT_UnPairStatus;
        public event EventHandler<byte[]>? MsgReceivedEvent;


        public void ConnectAsync(BTDeviceInfo device) {
            this.ConnectionCompleted?.Invoke(this, false);
        }


        public void Disconnect() {
            // Do nothing
        }


        /// <summary>Returns one dummy BTDeviceInfo</summary>
        /// <param name="paired">Look for paired or unpaired. Ignored</param>
        public void DiscoverDevicesAsync(bool paired) {
            this.DiscoveredBTDevice?.Invoke(this, new BTDeviceInfo() {
                Name = "NOT IMPLEMENTED",
                RemoteHostName = "NOT IMPLEMENTED",
                RemoteServiceName = "0",
            });
            this.DiscoveryComplete?.Invoke(this, false);
        }


        public void GetDeviceInfoAsync(BTDeviceInfo deviceDataModel) {
            this.BT_DeviceInfoGathered?.Invoke(this, new BTDeviceInfo() {
                Name = "NOT IMPLEMENTED",
                RemoteHostName = "NOT IMPLEMENTED",
                RemoteServiceName = "0",
            });

        }


        public void PairgAsync(BTDeviceInfo info) {
            this.BT_PairStatus?.Invoke(this, new BTPairOperationStatus() {
                IsSuccessful = false,
                PairStatus = BT_PairingStatus.NoParingObject,
                Name = "NOT IMPLEMENTED"
            });
        }


        public bool SendOutMsg(byte[] msg) {
            return false;
        }


        public void UnPairAsync(BTDeviceInfo info) {
            this.BT_UnPairStatus?.Invoke(this, new BTUnPairOperationStatus() {
                IsSuccessful = false,
                UnpairStatus = BT_UnpairingStatus.AccessDenied,
                Name = "NOT IMPLEMENTED"
            });
        }



#pragma warning disable IDE0051 // Remove unused private members
        private void ToEliminateCompilerWarnings(byte[] msg) {
#pragma warning restore IDE0051 // Remove unused private members
            this.MsgReceivedEvent?.Invoke(this, msg);
            this.BT_PairInfoRequested?.Invoke(this, new BT_PairInfoRequest() {
                DeviceName = "NOT IMPLEMENTED"
            });
        }

    }

}
