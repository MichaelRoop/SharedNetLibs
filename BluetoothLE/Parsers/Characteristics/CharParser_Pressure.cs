using BluetoothLE.Net.Enumerations;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Temperature: Uint16 exponent -1 resolution 0.1 pascal</summary>
    public class CharParser_Pressure : CharParser_Base {

        public double Value { get; private set; }

        public override int RequiredBytes { get; protected set; } = UINT32_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_32bit;

        protected override void DoParse(byte[] data) {
            this.Value = data.ToUint32(0).Calculate(-1, 1);
            this.DisplayString = this.Value.ToStr(1);
        }

    }

}
