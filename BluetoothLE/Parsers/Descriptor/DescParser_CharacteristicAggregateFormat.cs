using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>List of attribute handles (0x2905) Data type: List<uint16></uint16>
    /// </summary>
    public class DescParser_CharacteristicAggregateFormat :DescParser_Base {

        private ClassLog log = new ClassLog("DescParser_CharacteristicAggregateFormat");


        /// <summary>List of attribute handles</summary>
        public List<ushort> AttributeHandles { get; set; } = new List<ushort>();

        protected override bool IsDataVariableLength { get; set; } = true;


        /// <summary>
        /// Reset with values parsed from the bytes retrieved from the Descriptor
        /// </summary>
        /// <param name="data">The bytes of data returned from the OS descriptor</param>
        protected override void DoParse(byte[] data) {
            int count = data.Length / UINT16_LEN;
            for (int i = 0; i < count; i++) {
                this.AttributeHandles.Add(BitConverter.ToUInt16(data, i * UINT16_LEN));
            }

            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (ushort val in this.AttributeHandles) {
                if (first) {
                    sb.Append(",");
                    first = false;
                }
                sb.Append(val);
            }
            this.DisplayString = sb.ToString();
        }


        protected override void ResetMembers() {
            this.AttributeHandles = new List<ushort>();
        }

    }

}
