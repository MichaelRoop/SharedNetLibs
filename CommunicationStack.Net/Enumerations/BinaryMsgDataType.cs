using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.Enumerations {

    /// <summary>Part of contract for binary messages with single type payload</summary>
    public enum BinaryMsgDataType : byte {
        tyepUndefined = 0,
        typeBool = 1,
        typeInt8 = 2,
        typeUInt8 = 3,
        typeInt16 = 4,
        typeUInt16 = 5,
        typeInt32 = 6,
        typeUInt32 = 7,
        typeFloat32 = 8,
        //typeString = 9,
        typeInvalid = 9
    }

    public static class BinaryMsgDataTypeExtensions {

        public static byte ToByte(this BinaryMsgDataType dataType) {
            return (byte)dataType;            
        }


    }



}
