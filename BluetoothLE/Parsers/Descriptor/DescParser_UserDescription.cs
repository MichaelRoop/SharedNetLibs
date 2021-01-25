using System;
using System.Text;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// Parses User Description Descriptor data
    /// (0x2901) Data type: string
    /// </summary>
    public class DescParser_UserDescription : DescParser_Base {

        public string Description { get; set; } = "";

        protected override bool IsDataVariableLength { get; set; } = true;


        protected override void DoParse(byte[] data) {
            this.Description = Encoding.UTF8.GetString(data);
            this.DisplayString = this.Description;
        }


        protected override void ResetMembers() {
            this.Description = "";
            base.ResetMembers();
        }

    }

}
