
namespace SerialCommon.Net.Enumerations {

    /// <summary>Cross platform enum of parity bit setttings</summary>
    public enum SerialParityType {

        /// <summary>No parity check</summary>
        None = 0,
        /// <summary>Sets bit so count of bits is odd</summary>
        Odd = 1,
        /// <summary>Sets bit so count of bits is even</summary>
        Even = 2,
        /// <summary>Leaves bit set to 1</summary>
        Mark = 3,
        /// <summary>Leaves bit set to 0</summary>
        Space = 4,

    }


    public static class SerialParityTypeExtensions {
        public static string Display(this SerialParityType spt) {
            return spt.ToString();
        }
    }


}
