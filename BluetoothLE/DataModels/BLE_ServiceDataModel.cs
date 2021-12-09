using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers;

namespace BluetoothLE.Net.DataModels {

    /// <summary>Cross platform data model for essential BLE Service info</summary>
    public class BLE_ServiceDataModel : IUniquelyIdentifiable {

        public ushort AttributeHandle { get; set; } = 0;

        /// <summary>
        /// TODO Follow up: Gatt service instance path used to instantiate
        /// the GattDeviceService
        /// see: https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile.gattdeviceservice?view=winrt-18362
        /// </summary>
        public string DeviceId { get; set; } = "";

        public string DisplayHeader { get; set; } = "Service";

        public GattNativeServiceUuid ServiceTypeEnum { get; set; } = GattNativeServiceUuid.None;

        /// <summary>Get from the Uuid through the enumeration helpers</summary>
        public string DisplayName { get; set; } = "";

        /// <summary>List of Gatt characteristics which include read/write sources</summary>
        public List<BLE_CharacteristicDataModel> Characteristics { get; set; } = new List<BLE_CharacteristicDataModel>();

        public BLE_DeviceAccessStatus DeviceAccess { get; set; } = BLE_DeviceAccessStatus.Unspecified;

        public BLE_SharingMode SharingMode { get; set; } = BLE_SharingMode.Unspecified;

        public BLE_GattSession Session { get; set; } = new BLE_GattSession();

        /// <summary>Gatt Service UUID</summary>
        public Guid Uuid { get; set; } = Guid.Empty;

        // Other info from MS GattSession
        // BluetoothLEDevice - the parent object which has the services
        // Parent services (List)
        // DeviceAccessInformation
        //    DeviceAccessStatus unspecified (Unspecified, Allowed, DeniedByUser, DeniedBySystem)
        // GattSession
        // GattSharingMode (Unspecified, Exclusive, SharedReadOnly, SharedReadAndWrite)


        public BLE_ServiceDataModel() {
            this.Characteristics = new List<BLE_CharacteristicDataModel>();
        }

    }
}
