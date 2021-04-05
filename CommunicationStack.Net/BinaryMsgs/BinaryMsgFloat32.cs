using CommunicationStack.Net.Enumerations;
using System;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public class BinaryMsgFloat32 : BinaryMsg<Single> {

        public BinaryMsgFloat32() : base() {
        }


        public BinaryMsgFloat32(byte id, Single value):base(id, value) {
        }


        protected override BinaryMsgDataType GetDataType() {
            return BinaryMsgDataType.typeFloat32;
        }


        protected override byte[] GetPayload() {
            return this.Value.ToByteArray();
        }


        protected override ushort GetVariableSize() {
            return this.Value.GetSize();
        }

    }
}
