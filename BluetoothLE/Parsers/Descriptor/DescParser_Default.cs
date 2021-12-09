using LogUtils.Net;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>For descriptors not yet specifically implemented to return byte string</summary>
    public class DescParser_Default : DescParser_Base {

        private readonly ClassLog log = new ("DescParser_Default");

        #region Properties

        public string ByteString { get; set; } = "";

        protected override bool IsDataVariableLength { get; set; } = true;

        #endregion

        #region DescParser_Base overrides

        protected override void DoParse(byte[] data) {
            this.ByteString = data.ToFormatedByteString();
            this.DisplayString = this.ByteString;
            this.log.Info("DoParse", () => string.Format("Display:{0}", this.DisplayString));
        }


        protected override void ResetMembers() {
            this.ByteString = "";
            base.ResetMembers();
        }

        #endregion

    }
}
