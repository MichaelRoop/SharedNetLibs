using BluetoothLE.Net.Enumerations;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Humidity: Uint16 exponent -2 resolution 0.01</summary>
    public class CharParser_Humidity : CharParser_Base {

        public double Value { get; private set; }

        public override int RequiredBytes { get; protected set; } =  UINT16_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_16bit;


        protected override void DoParse(byte[] data) {
            this.Value = data.ToInt16(0).Calculate(-2, 2);
            // Cannot put the % in the ToString. Malfunction
            this.DisplayString = string.Format("{0}%", this.Value.ToStr(-2));
        }
    }

}
