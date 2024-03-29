﻿using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Appearance : CharParser_Base {

        private readonly ClassLog log = new ("CharParser_Appearance");

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_16bit;

        public uint Raw { get; set; } = 0;

        public uint Category { get; set; } = 0;
        public uint SubCategory { get; set; } = 0;


        protected override void DoParse(byte[] data) {
            //https://specificationrefs.bluetooth.com/assigned-values/Appearance%20Values.pdf
            //  6 bits = sub category - bits 0-5  - Mask 0000 0000 0011 1111 (63)
            // 10 bits = category     - bits 6-15 - Mask 1111 1111 1100 0000 (65,472)
            this.Raw = (uint)BitConverter.ToUInt16(data);
            uint catMask = 65472;
            uint subMask = 63;
            this.Category = this.Raw & catMask;
            this.SubCategory = this.Raw & subMask;

            StringBuilder sb = new ();
            sb.Append(this.Category).Append(',').Append(this.SubCategory);
            this.DisplayString = sb.ToString();
            this.log.Info("DoParse", () =>
                string.Format("{0} from {1} ({2})", this.DisplayString, this.Raw, data.ToFormatedByteString()));
        }

    }
}
