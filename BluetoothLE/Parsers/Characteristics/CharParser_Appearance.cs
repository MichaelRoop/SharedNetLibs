using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Appearance : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_Appearance");

        public CharParser_Appearance() : base() { }
        public CharParser_Appearance(byte[] data) : base(data) { }

        protected override bool DoParse(byte[] data) {
            //https://specificationrefs.bluetooth.com/assigned-values/Appearance%20Values.pdf
            //  6 bits = sub category - bits 0-5
            // 10 bits = category     - bits 6-15
            // bitmask (0-5)  1111 1100 0000 0000 (64,512)
            // bitmask (6-15) 0000 0011 1111 1111 (1,023)
            if (this.CopyToRawData(data, data.Length)) {
                // TODO - for now just put out the bytes
                uint raw = (uint)BitConverter.ToUInt16(this.RawData);
                uint catMask = 1023;
                uint subMask = 64512;
                StringBuilder sb = new StringBuilder();
                sb.Append((raw & catMask)).Append(",").Append((raw & subMask));
                this.strValue = sb.ToString();
                this.log.Info("", () => string.Format(
                    "{0} from bytes {1}", 
                    this.strValue, this.RawData.ToFormatedByteString()));
                return true;
            }
            return false;
        }

        protected override Type GetDerivedType() {
            return this.GetType();
        }
    }
}
