using CommunicationStack.Net.Enumerations;

namespace CommunicationStack.Net.DataModels {

    public class BinaryMsgDataTypeDisplay {

        /// <summary>Generate a list of valid data type display units</summary>
        public static List<BinaryMsgDataTypeDisplay> TypeList {
            get {
                List<BinaryMsgDataTypeDisplay> list = new() {
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeBool),
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeInt8),
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeInt16),
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeInt32),
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeUInt8),
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeUInt16),
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeUInt32),
                    new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeFloat32)
                };
                return list;
            }
        }

        public BinaryMsgDataType DataType { get; set; }

        public string Display { get; set; } = string.Empty;

        public BinaryMsgDataTypeDisplay(BinaryMsgDataType dataType) {
            this.DataType = dataType;
            this.Display = this.DataType.ToStr();
        }

    }
}
