
namespace CommunicationStack.Net.Stacks {

    /// <summary>
    /// Types of non printable ASCII characters used as terminators in ASCII messages
    /// </summary>
    /// <remarks>
    /// See: http://www.asciitable.com/
    /// </remarks>
    public enum Terminator : byte {
        // DO NOT CHANGE ORDER SINCE THE NUMBER CORRESPONDS TO ASCII in decimal format to store in byte
        NUL = 0,    // Null
        SOH = 1,    // Start of heading
        STX = 2,    // Start of text
        ETX = 3,    // End of text
        EOT = 4,    // End of transmission
        ENQ = 5,    // Enquiry
        ACK = 6,    // Acknowledge
        BEL = 7,    // Bell (alert)             \a
        BS = 8,     // Back space               \b
        TAB = 9,    // Horizontal tab           \t
        LF = 10,    // Line feed                \n
        VT = 11,    // Vertical tab             \v
        FF = 12,    // Form feed                \f
        CR = 13,    // Carriage return          \r
        SO = 14,    // Shift out
        SI = 15,    // Shift in
        DLE = 16,   // Data link escape
        DC1 = 17,   // Device control 1
        DC2 = 18,   // Device control 2
        DC3 = 19,   // Device control 3
        DC4 = 20,   // Device control 4
        NAK = 21,   // Negative acknowledge
        SYN = 22,   // Synchronous idle
        ETB = 23,   // End of transmission block
        CAN = 24,   // Cancel
        EM = 25,    // End of medium
        SUB = 26,   // Substitute
        ESC = 27,   // Escape
        FS = 28,    // File separator (->)
        GS = 29,    // Group separator (<-)
        RS = 30,    // Record separator (up arrow)
        US = 31,    // Unit separator (down arrow)




    }


    public static class TerminatorExtensions {

        public static string ToHexString(this Terminator code) {
            return string.Format("0x{0:x2}", (byte)code);
        }



        public static string ToStringChar(this Terminator code) {
            switch (code) {
                case Terminator.BEL: return "\a";
                case Terminator.BS: return "\b";
                case Terminator.TAB: return "\t";
                case Terminator.LF: return "\n";
                case Terminator.VT: return "\v";
                case Terminator.FF: return "\f";
                case Terminator.CR: return "\r";
                default: return "*";
            }
        }

        public static string ToStringCharDisplay(this Terminator code) {
            switch (code) {
                case Terminator.BEL: return @"\a";
                case Terminator.BS: return @"\b";
                case Terminator.TAB: return @"\t";
                case Terminator.LF: return @"\n";
                case Terminator.VT: return @"\v";
                case Terminator.FF: return @"\f";
                case Terminator.CR: return @"\r";
                default: return code.ToString();
            }
        }


        public static string Description(this Terminator code) {
            switch (code) {
                case Terminator.NUL: return "Null";
                case Terminator.SOH: return "Start of heading";
                case Terminator.STX: return "Start of text";
                case Terminator.ETX: return "End of text";
                case Terminator.EOT: return "End of transmission";
                case Terminator.ENQ: return "Enquiry";
                case Terminator.ACK: return "Acknowledge";
                case Terminator.BEL: return "Bell (alert)";
                case Terminator.BS: return "Back space";
                case Terminator.TAB: return "Horizontal tab";
                case Terminator.LF: return "Line feed";
                case Terminator.VT: return "Vertical tab";
                case Terminator.FF: return "Form feed";
                case Terminator.CR: return "Carriage return";
                case Terminator.SO: return "Shift out";
                case Terminator.SI: return "Shift in";
                case Terminator.DLE: return "Data link escape";
                case Terminator.DC1: return "Device control 1";
                case Terminator.DC2: return "Device control 2";
                case Terminator.DC3: return "Device control 3";
                case Terminator.DC4: return "Device control 4";
                case Terminator.NAK: return "Negative acknowledge";
                case Terminator.SYN: return "Synchronous idle";
                case Terminator.ETB: return "End of transmission block";
                case Terminator.CAN: return "Cancel";
                case Terminator.EM: return "End of medium";
                case Terminator.SUB: return "Substitute";
                case Terminator.ESC: return "Escape";
                case Terminator.FS: return "File separator (->)";
                case Terminator.GS: return "Group separator (<-)";
                case Terminator.RS: return "Record separator (up arrow)";
                case Terminator.US: return "Unit separator (down arrow)";
                default:
                    return "*NA*";
            }
        }




    }



} // namespace





