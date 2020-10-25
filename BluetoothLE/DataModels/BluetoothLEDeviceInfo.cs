using BluetoothLE.Net.Enumerations;
using ChkUtils.Net;
using Common.Net.Enumerations;
using Common.Net.Network;
using Common.Net.Network.interfaces;
using Common.Net.Properties;
using LogUtils.Net;
using System;
using System.Collections.Generic;

namespace BluetoothLE.Net.DataModels {


    /// <summary>Information particular to Bluetooth LE devices</summary>
    public class BluetoothLEDeviceInfo {

        private ClassLog log = new ClassLog("BluetoothLEDeviceInfo");
        private INetPropertyKeys propertyKeys = null;

        public event EventHandler<StringProperyUpdate> OnStringPropertyChanged;
        public event EventHandler<BoolProperyUpdate> OnBoolPropertyChanged;
        public event EventHandler<GuidProperyUpdate> OnGuidPropertyChanged;

        /// <summary>So that we do not try multiple times to connect to gather info if connect failed</summary>
        public bool InfoAttempted { get; set; } = false;

        /// <summary>Name</summary>
        public string Name { get; set; }

        /// <summary>Id which as info and BT Address</summary>
        /// <example>BluetoothLE#BluetoothLE10:08:b1:8a:b0:02-84:0d:8e:1e:d3:d6</example>
        public string Id { get; set; }

        /// <summary>Get the Bluetooth type info only on connection</summary>
        public BluetoothType TypeBluetooth { get; set; } = BluetoothType.Unknown;

        public BLE_AddressType AddressType { get; set; } = BLE_AddressType.Unspecified;

        public ulong AddressAsULong { get; set; } = 0;

        public bool IsDefault { get; set; } // not in Ms example

        public bool IsEnabled { get; set; } // not in Ms example

        public bool CanPair { get; set; } // not in Ms example

        public bool IsPaired { get; set; } = false;

        public BLE_DeviceInfoKind DeviceKind { get; set; } = BLE_DeviceInfoKind.Unknown;

        public bool IsConnected { get; set; } = false;

        public BLE_ProtectionLevel ProtectionLevel { get; set; } = BLE_ProtectionLevel.DefaultPlain;

        public BLE_EnclosureLocation EnclosureLocation { get; set; } = new BLE_EnclosureLocation();

        public BLE_DeviceAccessStatus AccessStatus { get; set; } = BLE_DeviceAccessStatus.Unspecified;

        public Dictionary<string, NetPropertyDataModel> ServiceProperties { get; set; } = new Dictionary<string, NetPropertyDataModel>();

        public Dictionary<string, BLE_ServiceDataModel> Services { get; set; } = new Dictionary<string, BLE_ServiceDataModel>();

        public bool WasPairedUsingSecureConnection { get; set; } = false;


        #region MS extra stuff - OS specific

        // MS example
        //Windows.Devices.Enumeration.DeviceInformation d = null;
        //public IReadOnlyDictionary<string, object> Properties => DeviceInformation.Properties;
        //public BitmapImage GlyphBitmapImage { get; private set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void Update(DeviceInformationUpdate deviceInfoUpdate) {
        //    DeviceInformation.Update(deviceInfoUpdate);

        //    OnPropertyChanged("Id");
        //    OnPropertyChanged("Name");
        //    OnPropertyChanged("DeviceInformation");
        //    OnPropertyChanged("IsPaired");
        //    OnPropertyChanged("IsConnected");
        //    OnPropertyChanged("Properties");
        //    OnPropertyChanged("IsConnectable");

        //    UpdateGlyphBitmapImage();
        //}

        //private async void UpdateGlyphBitmapImage() {
        //    DeviceThumbnail deviceThumbnail = await DeviceInformation.GetGlyphThumbnailAsync();
        //    var glyphBitmapImage = new BitmapImage();
        //    await glyphBitmapImage.SetSourceAsync(deviceThumbnail);
        //    GlyphBitmapImage = glyphBitmapImage;
        //    OnPropertyChanged("GlyphBitmapImage");
        //}

        //protected void OnPropertyChanged(string name) {
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
        #endregion

        /// <summary>OS 
        /// specific implementations require a specific object 
        /// returned from discovery to make a connection
        /// </summary>
        public object OSSpecificObj { get; set; }  


        /// <summary>To satisfy XAML</summary>
        public BluetoothLEDeviceInfo() {

        }

        public BluetoothLEDeviceInfo(INetPropertyKeys propertyKeys) {
            this.propertyKeys = propertyKeys;
        }


        public void Update(Dictionary<string, NetPropertyDataModel> properties) {
            // Need some kind of event that something has changed
            foreach (var property in properties) {
                if (this.ServiceProperties.ContainsKey(property.Key)) {
                    WrapErr.ToErrReport(9999, 
                        () => string.Format("Failed on update of '{0}'", property.Key), 
                        () => {
                            this.ServiceProperties[property.Key].Value = property.Value.Value;
                            this.ChangeValueOnUpdate(this.ServiceProperties[property.Key]);
                            this.RaiseChangedEvent(this.ServiceProperties[property.Key]);
                        });
                }
                else {
                    this.log.Error(9999, "Update", () => string.Format("Property key '{0}' does not exist", property.Key));
                }
            }
        }


        /// <summary>Change class values based on updated property</summary>
        /// <param name="dm">The property data model</param>
        private void ChangeValueOnUpdate(NetPropertyDataModel dm) {
            if (dm.Key == this.propertyKeys.ItemNameDisplay) {
                this.Name = dm.Value as string;
            }
            else if (dm.Key == this.propertyKeys.CanPair) {
                this.CanPair = (bool)dm.Value;
            }
            else if (dm.Key == this.propertyKeys.IsPaired) {
                this.IsPaired = (bool)dm.Value;
            }
            else if (dm.Key == this.propertyKeys.IsConnected) {
                this.IsConnected = (bool)dm.Value;
            }
            else if (dm.Key == this.propertyKeys.IsConnectable) {
                // Have never seen this property so remove from variables. Can still see in properties
                //this.IsConnectable = (bool)dm.Value;
            }

            // These are in the properties only 
            //this.propertyKeys.ContainerId
            //this.propertyKeys.IconPath
            //this.propertyKeys.GlyphIconPath

        }

        private void RaiseChangedEvent(NetPropertyDataModel dm) {
            this.log.Info("++++++++++++", 
                () => string.Format("Updating {0} : {1} : {2}",
                dm.Key, dm.DataType, dm.Value.ToString()));

            switch (dm.DataType) {
                case PropertyDataType.TypeBool:
                    this.OnBoolPropertyChanged?.Invoke(this, new BoolProperyUpdate(dm.Key, (bool)dm.Value));
                    break;
                case PropertyDataType.TypeString:
                    this.OnStringPropertyChanged?.Invoke(this, new StringProperyUpdate(dm.Key, dm.Value as string));
                    break;
                case PropertyDataType.TypeGuid:
                    this.OnGuidPropertyChanged?.Invoke(this, new GuidProperyUpdate(dm.Key, (Guid)dm.Value));
                    break;
                case PropertyDataType.TypeUnknown:
                    this.OnStringPropertyChanged?.Invoke(this, new StringProperyUpdate(dm.Key, dm.Value.ToString()));
                    break;

                    // TODO add events for other types
            }
        }



    }
}
