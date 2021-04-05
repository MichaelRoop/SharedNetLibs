using CommunicationStack.Net.Enumerations;
using System;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public class BinaryMsgUint16 : BinaryMsg<UInt16> {

        public BinaryMsgUint16() : base() {
        }

        public BinaryMsgUint16(byte id, UInt16 value) : base(id, value) {
        }

        protected override BinaryMsgDataType GetDataType() {
            return BinaryMsgDataType.typeUInt16;
        }

        protected override byte[] GetPayload() {
            return this.Value.ToByteArray();
        }

        protected override ushort GetVariableSize() {
            return this.Value.GetSize();
        }

    }
}
