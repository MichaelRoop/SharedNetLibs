
namespace SerialCommon.Net.Enumerations {

    /// <summary>Cross platform enum for number of serial stop bits</summary>
    public enum SerialStopBits {
        /// <summary>1 Stop bit</summary>
        One = 0,
        /// <summary>1.5 Stop bits</summary>
        OnePointFive = 1,
        /// <summary>2 Stop bits</summary>
        Two = 2,
    }


    public static class SerialStopBitsExtensions {
        public static string Display(this SerialStopBits sb) {
            return sb switch {
                SerialStopBits.One => "1",
                SerialStopBits.OnePointFive => "1.5",
                SerialStopBits.Two => "2",
                _ => "1",
            };
        }
    }


}
