using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>For Characteristics not yet implemented to return byte string</summary>
    public class CharParser_Default : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_Default");

        protected override bool IsDataVariableLength { get; set; } = true;


        protected override void DoParse(byte[] data) {
            DescParser_PresentationFormat format = null;

            foreach (var desc in this.DescriptorParsers) {
                if (desc is DescParser_PresentationFormat){
                    format = desc as DescParser_PresentationFormat;
                }
            }

            // Use the format descriptor for data display format.Format


            this.DisplayString = data.ToFormatedByteString();
            this.log.Info("DoParse", () => string.Format("NOT IMPLEMENTED Display:{0}", this.DisplayString));
        }

    }

}
