using SerialCommon.Net.Enumerations;

namespace SerialCommon.Net.DataModels {

    /// <summary>Wrap Serial Parity for display list source</summary>
    public class SerialParityDisplayClass {

        public string Display { get; set; } = string.Empty;

        public SerialParityType ParityType { get; set; } = SerialParityType.None;

        public SerialParityDisplayClass(SerialParityType pt) {
            this.Display = pt.Display();
            this.ParityType = pt;
        }

    }
}
