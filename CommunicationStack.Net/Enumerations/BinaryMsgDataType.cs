using System;
using VariousUtils.Net;

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


        public static int DataSize(this BinaryMsgDataType dataType) {
            switch (dataType) {
                case BinaryMsgDataType.typeBool:
                    return ((byte)0).GetSize();
                case BinaryMsgDataType.typeInt8:
                    return ((sbyte)0).GetSize();
                case BinaryMsgDataType.typeUInt8:
                    return ((byte)0).GetSize();
                case BinaryMsgDataType.typeInt16:
                    return ((Int16)0).GetSize();
                case BinaryMsgDataType.typeUInt16:
                    return ((UInt16)0).GetSize();
                case BinaryMsgDataType.typeInt32:
                    return ((Int32)0).GetSize();
                case BinaryMsgDataType.typeUInt32:
                    return ((UInt32)0).GetSize();
                case BinaryMsgDataType.typeFloat32:
                    return ((Single)0).GetSize();
                case BinaryMsgDataType.tyepUndefined:
                case BinaryMsgDataType.typeInvalid:
                default:
                    return 0; ;
            }
        }


        public static string ToStr(this BinaryMsgDataType dataType) {
            switch (dataType) {
                case BinaryMsgDataType.typeBool:
                    return "Bool";
                case BinaryMsgDataType.typeInt8:
                    return "Int8";
                case BinaryMsgDataType.typeUInt8:
                    return "UInt8";
                case BinaryMsgDataType.typeInt16:
                    return "Int16";
                case BinaryMsgDataType.typeUInt16:
                    return "UInt16";
                case BinaryMsgDataType.typeInt32:
                    return "Int32";
                case BinaryMsgDataType.typeUInt32:
                    return "UInt32";
                case BinaryMsgDataType.typeFloat32:
                    return "Float32";
                case BinaryMsgDataType.tyepUndefined:
                    return "Undefined";
                case BinaryMsgDataType.typeInvalid:
                    return "Invalid";
                default:
                    return "Unhandled";
            }
        }


        public static NumericRange Range(this BinaryMsgDataType dataType) {
            switch (dataType) {
                case BinaryMsgDataType.typeBool:
                    return true.GetRange();
                case BinaryMsgDataType.typeInt8:
                    return sbyte.MinValue.GetRange();
                case BinaryMsgDataType.typeUInt8:
                    return byte.MinValue.GetRange();
                case BinaryMsgDataType.typeInt16:
                    return Int16.MinValue.GetRange();
                case BinaryMsgDataType.typeUInt16:
                    return UInt16.MinValue.GetRange();
                case BinaryMsgDataType.typeInt32:
                    return Int32.MinValue.GetRange();
                case BinaryMsgDataType.typeUInt32:
                    return UInt32.MinValue.GetRange();
                case BinaryMsgDataType.typeFloat32:
                    return Single.MinValue.GetRange();
                case BinaryMsgDataType.tyepUndefined:
                case BinaryMsgDataType.typeInvalid:
                default:
                    return new NumericRange(0, 0);
            }
        }


        public static void Validate(this BinaryMsgDataType dataType, string value, Action onSuccess, Action<NumericRange> onError) {
            switch (dataType) {
                case BinaryMsgDataType.typeBool:
                    value.IsBool(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeInt8:
                    value.IsSByte(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeUInt8:
                    value.IsByte(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeInt16:
                    value.IsInt16(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeUInt16:
                    value.IsUInt16(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeInt32:
                    value.IsInt32(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeUInt32:
                    value.IsUInt32(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeFloat32:
                    value.IsFloat32(onSuccess, onError);
                    break;
                case BinaryMsgDataType.typeInvalid:
                case BinaryMsgDataType.tyepUndefined:
                default:
                    // TODO - should have exception
                    onError(new NumericRange(0,0));
                    break;
            }
        }


        public static byte ToByte(this string value) {
            return byte.Parse(value);
        }

        public static sbyte ToInt8(this string value) {
            return sbyte.Parse(value);
        }

        public static Int16 ToInt16(this string value) {
            return Int16.Parse(value);
        }

        public static Int32 ToInt32(this string value) {
            return Int32.Parse(value);
        }

        public static byte ToUInt8(this string value) {
            return byte.Parse(value);
        }

        public static UInt16 ToUInt16(this string value) {
            return UInt16.Parse(value);
        }

        public static UInt32 ToUInt32(this string value) {
            return UInt32.Parse(value);
        }

        public static Single ToFloat32(this string value) {
            return Single.Parse(value);
        }


        public static double Min(this BinaryMsgDataType dataType) {
            switch (dataType) {
                case BinaryMsgDataType.typeBool:
                    return 0;
                case BinaryMsgDataType.typeInt8:
                    return sbyte.MinValue;
                case BinaryMsgDataType.typeUInt8:
                    return byte.MinValue;
                case BinaryMsgDataType.typeInt16:
                    return Int16.MinValue;
                case BinaryMsgDataType.typeUInt16:
                    return UInt16.MinValue;
                case BinaryMsgDataType.typeInt32:
                    return Int32.MinValue;
                case BinaryMsgDataType.typeUInt32:
                    return UInt32.MinValue;
                case BinaryMsgDataType.typeFloat32:
                    return Single.MinValue;
                case BinaryMsgDataType.tyepUndefined:
                case BinaryMsgDataType.typeInvalid:
                default:
                    return 0;
            }
        }


        public static double Max(this BinaryMsgDataType dataType) {
            switch (dataType) {
                case BinaryMsgDataType.typeBool:
                    return 1;
                case BinaryMsgDataType.typeInt8:
                    return sbyte.MaxValue;
                case BinaryMsgDataType.typeUInt8:
                    return byte.MaxValue;
                case BinaryMsgDataType.typeInt16:
                    return Int16.MaxValue;
                case BinaryMsgDataType.typeUInt16:
                    return UInt16.MaxValue;
                case BinaryMsgDataType.typeInt32:
                    return Int32.MaxValue;
                case BinaryMsgDataType.typeUInt32:
                    return UInt32.MaxValue;
                case BinaryMsgDataType.typeFloat32:
                    return Single.MaxValue;
                case BinaryMsgDataType.tyepUndefined:
                case BinaryMsgDataType.typeInvalid:
                default:
                    return 0;
            }
        }



    }
}
