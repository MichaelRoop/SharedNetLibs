using LogUtils.Net;
using System;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_String : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_String");
        private string byteString = "";


        public CharParser_String() : base() { }


        public CharParser_String(byte[] data) : base(data) { }


        protected override string DoDisplayString() {
            return this.byteString;
        }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, data.Length)) {
                this.byteString = Encoding.UTF8.GetString(this.RawData);
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

    }

}
