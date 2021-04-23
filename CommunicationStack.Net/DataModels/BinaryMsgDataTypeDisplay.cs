using CommunicationStack.Net.Enumerations;
using System.Collections.Generic;

namespace CommunicationStack.Net.DataModels {

    public class BinaryMsgDataTypeDisplay {

        /// <summary>Generate a list of valid data type display units</summary>
        public static List<BinaryMsgDataTypeDisplay> TypeList {
            get {
                List<BinaryMsgDataTypeDisplay> list = new List<BinaryMsgDataTypeDisplay>();
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeBool));
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeInt8));
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeInt16));
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeInt32));
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeUInt8));
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeUInt16));
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeUInt32));
                list.Add(new BinaryMsgDataTypeDisplay(BinaryMsgDataType.typeFloat32));
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
