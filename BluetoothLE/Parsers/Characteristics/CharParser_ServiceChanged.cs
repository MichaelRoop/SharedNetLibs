using BluetoothLE.Net.Enumerations;
using LogUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_ServiceChanged : CharParser_Base {

        private readonly ClassLog log = new ("CharParser_ServiceChanged");

        public UInt16 StartHandle { get; private set; } = 0;
        public UInt16 EndHandle { get; private set; } = 0;

        public override int RequiredBytes { get; protected set; } = UINT32_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_32bit;

        protected override void DoParse(byte[] data) {
            // two 16 bit uints
            this.StartHandle = BitConverter.ToUInt16(data, 0);
            this.EndHandle = BitConverter.ToUInt16(data, 2);
            this.DisplayString = string.Format("Start Handle:{0} End Handle:{1}", this.StartHandle, this.EndHandle);
            this.log.Info("DoParse", this.DisplayString);
        }

    }


}
