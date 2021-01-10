using LogUtils.Net;
using System;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_String : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_String");

        public CharParser_String() : base() { }


        public CharParser_String(byte[] data) : base(data) { }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, data.Length)) {
                this.strValue = Encoding.UTF8.GetString(this.RawData);
                return true;
            }
            return false;
        }


        protected override Type GetDerivedType() {
            return this.GetType();
        }


    }

}
