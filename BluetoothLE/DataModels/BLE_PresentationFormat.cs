using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.DataModels {

    /// <summary>Portable class to for Gatt Presentation Format</summary>
    public class BLE_PresentationFormat {

        /// <summary>
        /// The BLE SIG description enumeration. Value from the orginization
        /// https://www.bluetooth.com/specifications/assigned-numbers/gatt-namespace-descriptors/
        /// </summary>
        public ushort Description { get; set; }

        /// <summary>The exponent</summary>
        public int Exponent { get; set; }

        /// <summary>
        /// The data format as enumeration: Cast for original byte
        /// https://www.bluetooth.com/specifications/assigned-numbers/format-types/
        /// </summary>
        public DataFormatEnum Format { get; set; }


        /// <summary>
        /// The BLE SIG description ushort enumeration
        /// https://www.bluetooth.com/specifications/assigned-numbers/gatt-namespace-descriptors/
        /// </summary>
        public ushort Namespace { get; set; }


        /// <summary>
        /// Units of measurement rendered to enum. Cast for original ushort
        /// https://www.bluetooth.com/specifications/assigned-numbers/units/
        /// </summary>
        public UnitsOfMeasurement Units { get; set; }


        /*
        //
        // Summary:
        //     Gets the Description of the GattPresentationFormat object.
        //
        // Returns:
        //     The Description of the GattPresentationFormat object.
        public ushort Description { get; }
        //
        // Summary:
        //     Gets the Exponent of the GattPresentationFormat object.
        //
        // Returns:
        //     The Exponent of the GattPresentationFormat object.
        public int Exponent { get; }
        //
        // Summary:
        //     Gets the Format Type of the GattPresentationFormat object.
        //
        // Returns:
        //     The Format Type of the GattPresentationFormat object.
        public byte FormatType { get; }
        //
        // Summary:
        //     Gets the Namespace of the GattPresentationFormat object.
        //
        // Returns:
        //     The Namespace of the GattPresentationFormat object.
        public byte Namespace { get; }
        //
        // Summary:
        //     Gets the Unit of the GattPresentationFormat object.
        //
        // Returns:
        //     The Unit of the GattPresentationFormat object.
        public ushort Unit { get; }
        //
        // Summary:
        //     Gets the value of the Bluetooth SIG Assigned Numbers Namespace.
        //
        // Returns:
        //     The value of the Bluetooth SIG Assigned Numbers Namespace.
        public static byte BluetoothSigAssignedNumbers { get; }
        */
    }
}
