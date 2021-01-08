﻿using BluetoothLE.Net.Enumerations;
using System;
using System.Collections.Generic;

namespace BluetoothLE.Net.DataModels {

    /// <summary>Cross platform holder of BLE Characteristic information</summary>
    public class BLE_CharacteristicDataModel {

        // TODO need event to get the value read at the OS level Characteristic
        // TODO need to expose something so we can write to the OS level Characteristic
        // UWP characteristic has a ValueChangedEvent - reads bytes. Need to translate to string? or data type?

        #region Events

        /// <summary>Raised from OS level when a read value changes</summary>
        public event EventHandler<BLE_CharacteristicReadResult> OnReadValueChanged;

        /// <summary>Raised from OS level when read write error detected on the Characteristic</summary>
        public event EventHandler<BLE_CommunicationError> OnCommunicationsError; 
        
        /// <summary>Raised from User to request a read of characteristic</summary>
        public event EventHandler ReadRequestEvent;

        /// <summary>Raised from User to request a data write to the characteristic</summary>
        public event EventHandler<byte[]> WriteRequestEvent;

        #endregion

        /// <summary>Unique identifier given by device</summary>
        public ushort AttributeHandle { get; set; }

        /// <summary>Determines what this characteristic can do</summary>
        public CharacteristicProperties PropertiesFlags { get; set; } = CharacteristicProperties.None; 

        /// <summary>Unique identifier</summary>
        public Guid Uuid { get; set; }

        public BLE_ProtectionLevel ProtectionLevel { get; set; }

        public string CharName { get; set; } = "xxxx";

        /// <summary>User friendly description or empty</summary>
        public string UserDescription { get; set; }

        public Dictionary<string, BLE_DescriptorDataModel> Descriptors { get; set; } = new Dictionary<string, BLE_DescriptorDataModel>();

        // TODO - why a list? Can characteristic data have multiple formats?
        public List<BLE_PresentationFormat> PresentationFormats { get; set; } = new List<BLE_PresentationFormat>();


        /// <summary>The service that holds this characteristic</summary>
        public BLE_ServiceDataModel Service { get; set; }


        public bool IsReadable {
            get {
                return this.PropertiesFlags.HasFlag(CharacteristicProperties.Read);
            }
        }


        public bool IsWritable {
            get {
                return this.PropertiesFlags.HasFlag(CharacteristicProperties.Write);
            }
        }


        public BLE_CharacteristicDataModel() {
            //this.Descriptors = new Dictionary<string, BLE_DescriptorDataModel>();
            //this.Descriptors.Add("44", new BLE_DescriptorDataModel() {
            //    DisplayName = "blipo descriptor in characteristic",
            //});
        }


        /// <summary>Used by the OS to push up characteristic read data</summary>
        /// <param name="data">The data read</param>
        public void PushReadDataEvent(byte[] data) {
            this.OnReadValueChanged?.Invoke(this, new BLE_CharacteristicReadResult() {
                Status = BLE_CharacteristicCommunicationStatus.Success,
                Data = data,
                DataModel = this,
            }); 


            // TODO - we could just write the data to a Data field in string format 
            // and inform user to update to refresh display
            // User could also grab the data to push it somewhere else

        }


        /// <summary>Used by the OS to push up an error during read or write</summary>
        /// <param name="status"></param>
        public void PushCommunicationError(BLE_CharacteristicCommunicationStatus status) {
            this.OnCommunicationsError?.Invoke(this, new BLE_CommunicationError() {
                Status = status,
                DataModel = this,
            });
        }

    }
}
