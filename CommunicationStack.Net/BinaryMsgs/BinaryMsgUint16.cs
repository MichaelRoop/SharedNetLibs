﻿using CommunicationStack.Net.Enumerations;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public class BinaryMsgUInt16 : BinaryMsg<UInt16> {

        public override double ValueAsDouble { get { return (double)this.Value; } }

        public BinaryMsgUInt16() : base() {
        }


        public BinaryMsgUInt16(byte id, UInt16 value) 
            : base(id, value) {
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
