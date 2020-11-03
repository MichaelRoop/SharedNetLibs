using SerialCommon.Net.Enumerations;

namespace SerialCommon.Net.DataModels {

    /// <summary>Wrap Stop bits for display list source</summary>
    public class StopBitDisplayClass {

        public string Display { get; set; } = string.Empty;

        public SerialStopBits StopBits { get; set; } = SerialStopBits.One;

        public StopBitDisplayClass(SerialStopBits sb) {
            this.Display = sb.Display();
            this.StopBits = sb;
        }

    }
}
