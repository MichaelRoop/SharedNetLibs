﻿using CommunicationStack.Net.Enumerations;
using VariousUtils.Net;


namespace CommunicationStack.Net.BinaryMsgs {

    public class BinaryMsgInt32 : BinaryMsg<Int32> {

        public override double ValueAsDouble { get { return (double)this.Value; } }

        public BinaryMsgInt32() : base() {
        }


        public BinaryMsgInt32(byte id, Int32 value) : base(id, value) {
        }


        protected override BinaryMsgDataType GetDataType() {
            return BinaryMsgDataType.typeInt32;
        }


        protected override byte[] GetPayload() {
            return this.Value.ToByteArray();
        }


        protected override ushort GetVariableSize() {
            return this.Value.GetSize();
        }
    }
}
