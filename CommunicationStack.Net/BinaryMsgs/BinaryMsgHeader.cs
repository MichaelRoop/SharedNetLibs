using CommunicationStack.Net.Enumerations;
using VariousUtils.Net;

namespace CommunicationStack.Net.BinaryMsgs {


    public class BinaryMsgHeader {
        public byte SOH { get; private set; } = 0;
        public byte STX { get; private set; } = 0;
        public ushort Size { get; private set; } = 0;
        public BinaryMsgDataType DataType { get; private set; } = BinaryMsgDataType.tyepUndefined;
        public byte Id { get; set; } = 0;


        public static BinaryMsgHeader? Init(byte[] packet) {
            if (packet.Length >= BinaryMsgDefines.SizeHeader) {
                BinaryMsgHeader header = new () {
                    SOH = packet[BinaryMsgDefines.SOHPos],
                    STX = packet[BinaryMsgDefines.STXPos],
                    DataType = packet.GetDataType(),
                    Id = packet[BinaryMsgDefines.IdPos],
                };
                header.Size = packet.ToUint16(BinaryMsgDefines.SizePos);
                if (header.DataType.IsValidSizeForMessage(header.Size)) {
                    return header;
                }
            }
            return null;
        }


    }

}
