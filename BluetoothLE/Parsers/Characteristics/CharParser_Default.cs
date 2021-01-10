using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>For Characteristics not yet implemented to return byte string</summary>
    public class CharParser_Default : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_Default");

 
        public CharParser_Default() : base() { }

        public CharParser_Default(byte[] data) : base(data) { }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, data.Length)) {
                this.strValue = this.RawData.ToFormatedByteString();
                this.log.Info("DoParse", () => string.Format("NOT IMPLEMENTED Display:{0}", this.DisplayString()));
                return true;
            }
            return false;
        }


        protected override Type GetDerivedType() {
            return this.GetType();
        }

    }
}
