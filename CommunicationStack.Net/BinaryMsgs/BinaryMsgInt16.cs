using CommunicationStack.Net.Enumerations;
using System;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public class BinaryMsgInt16 :BinaryMsg<Int16> {

        public BinaryMsgInt16() : base() {
        }

        public BinaryMsgInt16(byte id, Int16 value) : base(id, value) {
        }

        protected override BinaryMsgDataType GetDataType() {
            return BinaryMsgDataType.typeInt16;
        }

        protected override byte[] GetPayload() {
            return this.Value.ToByteArray();
        }

        protected override ushort GetVariableSize() {
            return this.Value.GetSize();
        }

    }
}
