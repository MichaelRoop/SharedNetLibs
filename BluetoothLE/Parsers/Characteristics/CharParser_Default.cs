using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>For Characteristics not yet implemented to return byte string</summary>
    public class CharParser_Default : CharParser_Base {

        #region Data

        private readonly ClassLog log = new ClassLog("CharParser_Default");
        private string byteString = "";

        #endregion

        #region Constructors

        public CharParser_Default() : base() { }

        public CharParser_Default(byte[] data) : base(data) { }

        #endregion

        #region CharParser_Base overrides

        protected override string DoDisplayString() {
            return string.Format("NOT IMPLEMENTED:{0}", this.byteString);
        }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, data.Length)) {
                this.byteString = this.RawData.ToFormatedByteString();
                this.log.Info("DoParse", () => string.Format("Display:{0}", this.DisplayString()));
                return true;
            }
            return false;
        }


        protected override Type GetDerivedType() {
            return this.GetType();
        }


        protected override void ResetMembers() {
            this.byteString = "";
        }

        #endregion

    }
}
