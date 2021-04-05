using CommunicationStack.Net.Enumerations;
using LogUtils.Net;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public abstract class BinaryMsg<T> {

        #region Data

        private static ushort SIZE_HEADER = 0;
        private static ushort SIZE_FOOTER = 0;
        private ClassLog log = new ClassLog("BinaryMsg<T>");

        #endregion


        //------------------- Header ----------------------------------------
        public byte SOH { get { return BinaryMsgDefines.SOH; } }
        public byte STX { get { return BinaryMsgDefines.STX; } }
        public ushort Size { get; private set; }
        public BinaryMsgDataType DataType { get; private set; }
        public byte Id { get; set; }

        public T Value { get; set; }

        public byte[] Payload { get; private set; }

        //------------------- Footer ----------------------------------------
        public byte ETX { get { return BinaryMsgDefines.ETX; } }
        public byte EOT { get { return  BinaryMsgDefines.EOT; } }


        public BinaryMsg() {
            this.Payload = this.GetPayload();
            this.DataType = this.GetDataType();
            this.Size = this.CalculateSize();
        }


        public BinaryMsg(byte id, T value) : this() {
            this.Id = id;
            this.Value = value;
        }


        public byte[] ToByteArray() {
            byte[] packet = new byte[this.CalculateSize()];
            int pos = 0;
            this.SOH.WriteToBuffer(packet, ref pos);                // 0   - Start of Header
            this.STX.WriteToBuffer(packet, ref pos);                // 1   - Start of Text
            this.Size.WriteToBuffer(packet, ref pos);               // 2,3 - Size
            this.DataType.ToByte().WriteToBuffer(packet, ref pos);  // 4   - Data type
            this.Id.WriteToBuffer(packet, ref pos);                 // 5   - Id 
            //------------------- Header ----------------------------------------

            this.Payload.WriteToBuffer(packet, ref pos);            // Payload - variable length

            //------------------- Footer ----------------------------------------
            this.ETX.WriteToBuffer(packet, ref pos);                // Payload + 1 End of Text
            this.EOT.WriteToBuffer(packet, ref pos);                // Payload + 2 End of Transmission
            return packet;
        }


        protected abstract ushort GetVariableSize();
        protected abstract byte[] GetPayload();
        protected abstract BinaryMsgDataType GetDataType();


        private ushort CalculateSize() {
            ushort size = this.CalculateHeaderSize();
            size += (ushort)this.Payload.Length;
            size += this.CalculateFooterSize();
            return size;
        }


        private ushort CalculateHeaderSize() {
            if (SIZE_HEADER == 0) {
                this.SOH.AddSize(ref SIZE_HEADER);                 // 0
                this.STX.AddSize(ref SIZE_HEADER);                 // 1
                this.Size.AddSize(ref SIZE_HEADER);                // 2,3
                this.DataType.ToByte().AddSize(ref SIZE_HEADER);   // 4
                this.Id.AddSize(ref SIZE_HEADER);                  // 5 Id  -- Up to here always same
            }
            return SIZE_HEADER;
        }


        private ushort CalculateFooterSize() {
            if (SIZE_FOOTER == 0) {
                this.ETX.AddSize(ref SIZE_FOOTER); // payload + 1 -- From here down always same
                this.EOT.AddSize(ref SIZE_FOOTER); // payload + 2
            }
            return SIZE_FOOTER;
        }

    }


    public static class BinaryMsgExtensions {

        private static ClassLog log = new ClassLog("BinaryMsgExtensions");

        /// <summary>Use after popped from FIFO queue with valid start and end terminators</summary>
        /// <param name="packet">The raw data</param>
        /// <returns>true if valid, otherwise false</returns>
        public static bool IsValidMsg(this byte[] packet) {
            BinaryMsgDataType dataType = packet.GetDataType();
            if (dataType != BinaryMsgDataType.typeInvalid && dataType != BinaryMsgDataType.tyepUndefined) {
                ushort size = packet.GetSize();
                if (IsValidSizeForMessage(dataType, size)) {
                    return true;
                }
                else {
                    log.Error(9999, "", () => string.Format("Invalid size {0} for type {1}", size, dataType));
                }
            }
            return false;
        }


        public static bool IsValidSizeForMessage(BinaryMsgDataType dataType, ushort size) {
            switch (dataType) {
                case BinaryMsgDataType.typeBool:
                    return size == BinaryMsgDefines.SizeMsgBool;
                case BinaryMsgDataType.typeInt8:
                    return size == BinaryMsgDefines.SizeMsgInt8;
                case BinaryMsgDataType.typeUInt8:
                    return size == BinaryMsgDefines.SizeMsgUInt8;
                case BinaryMsgDataType.typeInt16:
                    return size == BinaryMsgDefines.SizeMsgInt16;
                case BinaryMsgDataType.typeUInt16:
                    return size == BinaryMsgDefines.SizeMsgUInt16;
                case BinaryMsgDataType.typeInt32:
                    return size == BinaryMsgDefines.SizeMsgInt32;
                case BinaryMsgDataType.typeUInt32:
                    return size == BinaryMsgDefines.SizeMsgUInt32;
                case BinaryMsgDataType.typeFloat32:
                    return size == BinaryMsgDefines.SizeMsgFloat;
                case BinaryMsgDataType.tyepUndefined:
                case BinaryMsgDataType.typeInvalid:
                default:
                    return false;
            }
        }


        public static BinaryMsgDataType GetDataType(this byte[] packet) {
            if (packet.Length > BinaryMsgDefines.DataTypePos) {
                byte value = packet[BinaryMsgDefines.DataTypePos];
                if (value > BinaryMsgDataType.tyepUndefined.ToByte() &&
                    value < BinaryMsgDataType.typeInvalid.ToByte()) {
                    return (BinaryMsgDataType)value;
                }
                else {
                    log.Error(9999, "GetDataType", () => string.Format("Invalid value for data type:{0}", value));
                    return BinaryMsgDataType.typeInvalid;
                }
            }
            return BinaryMsgDataType.tyepUndefined;
        }


        public static ushort GetPacketSize(this byte[] packet) {
            if (packet.Length > BinaryMsgDefines.SizePos) {
                return  packet.ToUint16(BinaryMsgDefines.DataTypePos);
            }
            return 0;
        }



        public static BinaryMsgUint16 ToUint16Msg(this byte[] packet) {

            // Get parsing in the 
            return new BinaryMsgUint16();
        }



        //public static BinaryMsg<T> FromArray( this byte[] array) {
        //    return new BinaryMsgUint16();

        //}



    }




}
