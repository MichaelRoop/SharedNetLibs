using CommunicationStack.Net.Enumerations;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {

    public abstract class BinaryMsg<T> {
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
            //ushort size = 0;                            // Position
            //this.SOH.AddSize(ref size);                 // 0
            //this.STX.AddSize(ref size);                 // 1
            //this.Size.AddSize(ref size);                // 2,3
            //this.DataType.ToByte().AddSize(ref size);   // 4
            //this.Id.AddSize(ref size);                  // 5 Id  -- Up to here always same
            ////------------------- Header ----------------------------------------

            //// Variable payload size depending on type
            //size += (ushort)this.Payload.Length;        // Payload variable

            ////------------------- Footer ----------------------------------------
            //this.ETX.AddSize(ref size);        // payload + 1 -- From here down always same
            //this.EOT.AddSize(ref size);        // payload + 2
            //return size;

            ushort size = this.CalculateHeaderSize();
            size += (ushort)this.Payload.Length;
            size += this.CalculateFooterSize();
            return size;
        }


        private ushort CalculateHeaderSize() {
            ushort size = 0;                            // Position
            this.SOH.AddSize(ref size);                 // 0
            this.STX.AddSize(ref size);                 // 1
            this.Size.AddSize(ref size);                // 2,3
            this.DataType.ToByte().AddSize(ref size);   // 4
            this.Id.AddSize(ref size);                  // 5 Id  -- Up to here always same
            return size;
        }


        private ushort CalculateFooterSize() {
            ushort size = 0;                   // Position
            this.ETX.AddSize(ref size);        // payload + 1 -- From here down always same
            this.EOT.AddSize(ref size);        // payload + 2
            return size;
        }




    }


    public static class BinaryMsgExtensions {

        public static BinaryMsgDataType GetDataType(this byte[] packet) {
            if (packet.Length >= 5) {
                byte value = packet[BinaryMsgDefines.DataTypePos];
                if (value > BinaryMsgDataType.tyepUndefined.ToByte() &&
                    value < BinaryMsgDataType.typeInvalid.ToByte()) {
                    return (BinaryMsgDataType)value;
                }
            }
            return BinaryMsgDataType.tyepUndefined;
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
