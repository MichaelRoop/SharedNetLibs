﻿using CommunicationStack.Net.Enumerations;
using LogUtils.Net;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public abstract class BinaryMsg<T> {

        #region Data

        private static ushort SIZE_HEADER = 0;
        private static ushort SIZE_FOOTER = 0;
        //private static ClassLog log = new ("BinaryMsg<T>");

        #endregion


        //------------------- Header ----------------------------------------
        public byte SOH { get { return BinaryMsgDefines.SOH; } }
        public byte STX { get { return BinaryMsgDefines.STX; } }
        public ushort Size { get; private set; }
        public BinaryMsgDataType DataType { get; private set; }
        public byte Id { get; set; }

        public T? Value { get; set; } = default;

        public byte[] Payload { get { return this.GetPayload(); }  }

        //------------------- Footer ----------------------------------------
        public byte ETX { get { return BinaryMsgDefines.ETX; } }
        public byte EOT { get { return  BinaryMsgDefines.EOT; } }


        public BinaryMsg() {
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


        public BinaryMsgMinData ToMinimumData() {
            return new BinaryMsgMinData() {
                MsgId = this.Id,
                MsgValue = this.ValueAsDouble,
            };
        }


        protected abstract ushort GetVariableSize();
        protected abstract byte[] GetPayload();
        protected abstract BinaryMsgDataType GetDataType();

        public abstract double ValueAsDouble { get; }

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

        private readonly static ClassLog log = new ("BinaryMsgExtensions");

        /// <summary>Use after popped from FIFO queue with valid start and end terminators</summary>
        /// <param name="packet">The raw data</param>
        /// <returns>true if valid, otherwise false</returns>
        public static bool IsValidMsg(this byte[] packet) {
            BinaryMsgDataType dataType = packet.GetDataType();
            if (dataType != BinaryMsgDataType.typeInvalid && dataType != BinaryMsgDataType.tyepUndefined) {
                ushort size = packet.GetSize();
                if (IsValidSizeForMessage(dataType, size)) {
                    if (packet.IsHeaderValid()) {
                        if (packet.IsFooterValid(BinaryMsgDefines.DataPos + dataType.DataSize())) {
                            return true;
                        }
                    }
                }
                else {
                    log.Error(9999, "", () => string.Format("Invalid size {0} for type {1}", size, dataType));
                }
            }
            return false;
        }

        public static bool IsValidMsg(this byte[] packet, BinaryMsgDataType dataType) {
            BinaryMsgDataType packetDataType = packet.GetDataType();
            if (packetDataType == dataType) {
                ushort size = packet.GetSize();
                if (IsValidSizeForMessage(dataType, size)) {
                    if (packet.IsHeaderValid()) {
                        if (packet.IsFooterValid(BinaryMsgDefines.DataPos + dataType.DataSize())) {
                            return true;
                        }
                    }
                }
                else {
                    log.Error(9999, "", () => string.Format("Invalid size {0} for type {1}", size, dataType));
                }
            }
            return false;
        }


        /// <summary>Called after the size and data type is checked</summary>
        /// <returns>true if header values are valid, otherwise false</returns>
        private static bool IsHeaderValid(this byte[] packet) {
            return
                packet[BinaryMsgDefines.SOHPos] == BinaryMsgDefines.SOH &&
                packet[BinaryMsgDefines.STXPos] == BinaryMsgDefines.STX;
        }


        /// <summary>Called after size and data type validated</summary>
        /// <param name="packet"></param>
        /// <param name="startpos"></param>
        /// <returns></returns>
        private static bool IsFooterValid(this byte[] packet, int startpos) {
            return
                packet[startpos] == BinaryMsgDefines.ETX &&
                packet[startpos + 1] == BinaryMsgDefines.EOT;
        }



        public static bool IsValidSizeForMessage(this BinaryMsgDataType dataType, ushort size) {
            return dataType switch {
                BinaryMsgDataType.typeBool => size == BinaryMsgDefines.SizeMsgBool,
                BinaryMsgDataType.typeInt8 => size == BinaryMsgDefines.SizeMsgInt8,
                BinaryMsgDataType.typeUInt8 => size == BinaryMsgDefines.SizeMsgUInt8,
                BinaryMsgDataType.typeInt16 => size == BinaryMsgDefines.SizeMsgInt16,
                BinaryMsgDataType.typeUInt16 => size == BinaryMsgDefines.SizeMsgUInt16,
                BinaryMsgDataType.typeInt32 => size == BinaryMsgDefines.SizeMsgInt32,
                BinaryMsgDataType.typeUInt32 => size == BinaryMsgDefines.SizeMsgUInt32,
                BinaryMsgDataType.typeFloat32 => size == BinaryMsgDefines.SizeMsgFloat,
                _ => false,
            };
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



        #region Messages form byte array

        public static BinaryMsgBool? ToBoolMsg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeBool)) {
                return new BinaryMsgBool(
                    packet[BinaryMsgDefines.IdPos],
                    packet[BinaryMsgDefines.DataPos]);
            }
            return null;
        }


        public static BinaryMsgUInt8? ToUInt8Msg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeUInt8)) {
                return new BinaryMsgUInt8(
                    packet[BinaryMsgDefines.IdPos],
                    packet[BinaryMsgDefines.DataPos]);
            }
            return null;
        }


        public static BinaryMsgInt8? ToInt8Msg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeInt8)) {
                return new BinaryMsgInt8(
                    packet[BinaryMsgDefines.IdPos],
                    packet.ToSByte(BinaryMsgDefines.DataPos));
            }
            return null;
        }


        public static BinaryMsgUInt16? ToUInt16Msg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeUInt16)) {
                return new BinaryMsgUInt16(
                    packet[BinaryMsgDefines.IdPos],
                    packet.ToUint16(BinaryMsgDefines.DataPos));
            }
            return null;
        }


        public static BinaryMsgInt16? ToInt16Msg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeInt16)) {
                return new BinaryMsgInt16(
                    packet[BinaryMsgDefines.IdPos],
                    packet.ToInt16(BinaryMsgDefines.DataPos));
            }
            return null;
        }


        public static BinaryMsgUInt32? ToUInt32Msg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeUInt32)) {
                return new BinaryMsgUInt32(
                    packet[BinaryMsgDefines.IdPos],
                    packet.ToUint32(BinaryMsgDefines.DataPos));
            }
            return null;
        }


        public static BinaryMsgInt32? ToInt32Msg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeInt32)) {
                return new BinaryMsgInt32(
                    packet[BinaryMsgDefines.IdPos],
                    packet.ToInt32(BinaryMsgDefines.DataPos));
            }
            return null;
        }


        public static BinaryMsgFloat32? ToFloat32Msg(this byte[] packet) {
            if (packet.IsValidMsg(BinaryMsgDataType.typeFloat32)) {
                return new BinaryMsgFloat32(
                    packet[BinaryMsgDefines.IdPos],
                    packet.ToFloat32(BinaryMsgDefines.DataPos));
            }
            return null;
        }

        #endregion


    }




}
