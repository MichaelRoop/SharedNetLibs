
using BluetoothLE.Net.Enumerations;
using System;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// Value Trigger Settings
    /// (0x290A) Data type: 
    ///     Condition: uint8,
    ///     Values: uint16, or uint8, or uint32
    /// </summary>
    /// <remarks>
    /// See Git project: https://github.com/bluetoother/ble-packet/wiki/GATT-Descriptors
    /// Field: 1 Condition uint8 (byte)
    /// 
    /// Field: 2 Values (Multiple possiblities of value size)
    ///         If condition 1,2,3: (AnalogCrossedBoundry, AnalogReturnedToBoundry, AnalogStateChanged) 
    ///             The value is uint16 size
    ///         If condition 4 (Bitmask)
    ///             The value is uint8 (byte) size
    ///         If condition 5,6 (AnalogIntervalInsideOutsideBoundries, AnalogIntervalOnBoundry)
    ///             The Value field is uint32 size (2 uint 16 values to compare)
    ///         if Condition 1,7 (None, NoneNoValueTriggerEvenIfChanged)
    ///             Appears to have no value 
    ///         
    /// Note on Bitmask:
    ///     refered to the Digital Characteristic which defines 2 bits (of the byte?)
    ///     https://www.bluetooth.com/xml-viewer/?src=https://www.bluetooth.com/wp-content/uploads/Sitecore-Media-Library/Gatt/Xml/Characteristics/org.bluetooth.characteristic.digital.xml
    ///     Does not seem right
    ///     
    /// 
    /// </remarks>
    public class DescParser_ValueTriggerSetting : DescParser_Base {


        #region Properties

        public ValueTriggerCondition Condition { get; set; }

        #endregion

        #region Constructors

        public DescParser_ValueTriggerSetting() : base() { }
        public DescParser_ValueTriggerSetting(byte[] data) : base(data) { }

        #endregion


        protected override string DoDisplayString() {
            return "";
        }

        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, 1)) {
                byte condition = this.RawData[0];
                if (condition.IsValueTriggerEnum()) {
                    this.Condition = this.RawData[0].AsValueTriggerEnum();
                    switch (this.Condition) {
                    
                    
                    
                    
                    }


                }
            }
            return false;
        }

        protected override Type GetDerivedType() {
            return this.GetType();
        }

        protected override void ResetMembers() {
            throw new NotImplementedException();
        }







    }
}
