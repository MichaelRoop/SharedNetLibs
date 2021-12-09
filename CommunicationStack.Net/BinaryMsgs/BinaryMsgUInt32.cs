using CommunicationStack.Net.Enumerations;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {
    public class BinaryMsgUInt32 : BinaryMsg<UInt32> {

        public override double ValueAsDouble { get { return (double)this.Value; } }

        public BinaryMsgUInt32() : base() {
        }


        public BinaryMsgUInt32(byte id, UInt32 value) : base(id, value) {
        }


        protected override BinaryMsgDataType GetDataType() {
            return BinaryMsgDataType.typeUInt32;
        }


        protected override byte[] GetPayload() {
            return this.Value.ToByteArray();
        }


        protected override ushort GetVariableSize() {
            return this.Value.GetSize();
        }

    }
}
