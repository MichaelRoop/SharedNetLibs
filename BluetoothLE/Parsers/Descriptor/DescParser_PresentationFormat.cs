using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// 
    /// Field 1: Name:Format. uint8 values 0-27. Enumeration  Others reserved
    /// Field 2: Name:Exponent. signed int8
    /// Field 3: Name:Unit. uint16 (Guid)
    /// Field 4: Name: Namespace. uint8. 0-1 Enumeration (0 not set, 1 Bluetooth SIG Assigned Numbers)
    /// Field 5: Name: Description. uint16. Enumeration
    ///             https://www.bluetooth.com/specifications/assigned-numbers/gatt-namespace-descriptors/
    ///             // Way to many to put in an enum
    /// (0x2904)
    /// </summary>
    public class DescParser_PresentationFormat : DescParser_Base {

        #region Data

        private ClassLog log = new ClassLog("DescParser_PresentationFormat");

        #endregion

        #region Properties

        /// <summary>
        /// The data format as enumeration:
        /// https://www.bluetooth.com/specifications/assigned-numbers/format-types/
        /// </summary>
        public DataFormatEnum Format { get; set; }

        /// <summary>The exponent</summary>
        public sbyte Exponent { get; set; }

        /// <summary>
        /// International units of measurement in a BLE SIG enumeration:
        /// https://www.bluetooth.com/specifications/assigned-numbers/units/
        /// </summary>
        public ushort MeasurementUnitUShort { get; set; }


        /// <summary>
        /// The units of measurement rendered by an enum
        /// https://www.bluetooth.com/specifications/assigned-numbers/units/
        /// </summary>
        public UnitsOfMeasurement MeasurementUnitsEnum { get; set; }

        /// <summary>
        /// Currently only 1 namespace which is Bluetooth SIG
        /// https://www.bluetooth.com/specifications/assigned-numbers/gatt-namespace-descriptors/
        /// </summary>
        public byte Namespace { get; set; }

        /// <summary>
        /// The BLE SIG description enumeration. Value from the orginization
        /// https://www.bluetooth.com/specifications/assigned-numbers/gatt-namespace-descriptors/
        /// </summary>
        public ushort Description { get; set; }


        public override int RequiredBytes { get; set; } = 7;

        #endregion

        #region DescParser_Base overrides

        protected override void DoParse(byte[] data) {
            int pos = 0;
            this.Format = this.GetFormat(ByteHelpers.ToByte(data, ref pos));
            this.Exponent = data.ToSByte(ref pos);
            this.MeasurementUnitUShort = data.ToUint16(ref pos);
            this.MeasurementUnitsEnum = this.GetUnitOfMeasurement(this.MeasurementUnitUShort);
            this.Namespace = data.ToByte(ref pos);
            this.Description = data.ToUint16(ref pos);

            this.DisplayString = 
                string.Format(
                    "Format:{0} Exponent:{1} Unit:{2} (0x{3:X4}) Namespace:{4} Description Enum:{5}",
                    this.Format,
                    this.Exponent,
                    this.MeasurementUnitsEnum.ToString().CamelCaseToSpaces(),
                    this.MeasurementUnitUShort,
                    this.Namespace == 1 ? "Bluetooth SIG (1)" : this.Namespace.ToString(),
                    this.Description);
        }


        protected override Type GetDerivedType() {
            return this.GetType();
        }


        protected override void ResetMembers() {
            this.Format = DataFormatEnum.Reserved;
            this.Exponent = 0;
            this.MeasurementUnitUShort = 0;
            this.Namespace = 0;
            this.Description = 0;
        }

        #endregion

        #region Private

        private DataFormatEnum GetFormat(byte value) {
            if (value > (byte)DataFormatEnum.OpaqueStructure) {
                this.log.Error(13340, "GetFormat", () => string.Format("Format:{0} not handled", value));
                return DataFormatEnum.Unhandled;
            }
            return (DataFormatEnum)value;
        }


        private UnitsOfMeasurement GetUnitOfMeasurement(ushort value) {
            foreach (var m in EnumHelpers.GetEnumList<UnitsOfMeasurement>()) {
                if (((ushort)m) == value) {
                    return m;
                }
            }
            this.log.Error(13341, "GetUnitOfMeasurement", () => string.Format("value 0x{0:X4} not found in enums", value));
            return UnitsOfMeasurement.NOT_HANDLED;
        }

        #endregion

    }

}
