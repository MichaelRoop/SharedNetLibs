using CommunicationStack.Net.Enumerations;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public class BinaryMsgBool : BinaryMsg<byte> {

        public BinaryMsgBool() : base() {
        }


        public BinaryMsgBool(byte id, byte value) : base(id, value) { 
        }


        public BinaryMsgBool(byte id, bool value) 
            : base(id, value == true ? (byte)0x1: (byte)0x0) { 
        }


        protected override BinaryMsgDataType GetDataType() {
            return BinaryMsgDataType.typeBool;
        }

        protected override byte[] GetPayload() {
            return this.Value.ToByteArray();
        }

        protected override ushort GetVariableSize() {
            return this.Value.GetSize();
        }

    }
}
