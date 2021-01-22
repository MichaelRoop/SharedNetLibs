using LogUtils.Net;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>For Characteristics not yet implemented to return byte string</summary>
    public class CharParser_Default : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_Default");

        // This is variable. Set on parse
        public override int RequiredBytes { get; protected set; } = 0;


        protected override bool DoParse(byte[] data) {
            this.RequiredBytes = data.Length;
            if (this.CopyToRawData(data)) {
                this.DisplayString = this.RawData.ToFormatedByteString();
                this.log.Info("DoParse", () => string.Format("NOT IMPLEMENTED Display:{0}", this.DisplayString));
                return true;
            }
            return false;
        }

    }

}
