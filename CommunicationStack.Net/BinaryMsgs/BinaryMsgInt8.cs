using CommunicationStack.Net.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;


namespace CommunicationStack.Net.BinaryMsgs {

    public class BinaryMsgInt8 : BinaryMsg<sbyte> {

        public BinaryMsgInt8() : base() {
        }


        public BinaryMsgInt8(byte id, sbyte value) : base(id, value) {
        }


        protected override BinaryMsgDataType GetDataType() {
            return BinaryMsgDataType.typeInt8;
        }


        protected override byte[] GetPayload() {
            return this.Value.ToByteArray();
        }


        protected override ushort GetVariableSize() {
            return this.Value.GetSize();
        }

    }
}
