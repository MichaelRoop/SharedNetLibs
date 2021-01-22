using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertCategoryIDBitmask : CharParser_Base {


        protected override bool IsDataVariableLength { get; set; } = true;


        protected override void DoParse(byte[] data) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Simple Alert:").Append(this.Status(data[0], 0))
                .Append(", Email:").Append(this.Status(data[0], 1))
                .Append(", News:").Append(this.Status(data[0], 2))
                .Append(", Incoming Call:").Append(this.Status(data[0], 3))
                .Append(", Missed Call:").Append(this.Status(data[0], 4))
                .Append(", SMS/MMS arrives:").Append(this.Status(data[0], 5))
                .Append(", Voice Mail:").Append(this.Status(data[0], 6))
                .Append(", Schedule:").Append(this.Status(data[0], 7));
            if (data.Length > 1) {
                sb.Append(", High Prioritized Alert:").Append(this.Status(data[1], 0))
                  .Append(", Instant Message:").Append(this.Status(data[1], 1));
            }
            else {
                sb.Append(", High Prioritized Alert:Not supported")
                  .Append(", Instant Message:Not supported");
            }
            this.DisplayString = sb.ToString();
        }


        private string Status(byte data, int bit) {
            return data.IsBitSet(bit) ? "Supported" : "Not supported";
        }

    }
}
