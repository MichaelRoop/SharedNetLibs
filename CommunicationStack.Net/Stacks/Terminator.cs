
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
            return code switch {
                Terminator.BEL => "\a",
                Terminator.BS => "\b",
                Terminator.TAB => "\t",
                Terminator.LF => "\n",
                Terminator.VT => "\v",
                Terminator.FF => "\f",
                Terminator.CR => "\r",
                _ => "*",
            };
        }

        public static string ToStringCharDisplay(this Terminator code) {
            return code switch {
                Terminator.BEL => @"\a",
                Terminator.BS => @"\b",
                Terminator.TAB => @"\t",
                Terminator.LF => @"\n",
                Terminator.VT => @"\v",
                Terminator.FF => @"\f",
                Terminator.CR => @"\r",
                _ => code.ToString(),
            };
        }


        public static string Description(this Terminator code) {
            return code switch {
                Terminator.NUL => "Null",
                Terminator.SOH => "Start of heading",
                Terminator.STX => "Start of text",
                Terminator.ETX => "End of text",
                Terminator.EOT => "End of transmission",
                Terminator.ENQ => "Enquiry",
                Terminator.ACK => "Acknowledge",
                Terminator.BEL => "Bell (alert)",
                Terminator.BS => "Back space",
                Terminator.TAB => "Horizontal tab",
                Terminator.LF => "Line feed",
                Terminator.VT => "Vertical tab",
                Terminator.FF => "Form feed",
                Terminator.CR => "Carriage return",
                Terminator.SO => "Shift out",
                Terminator.SI => "Shift in",
                Terminator.DLE => "Data link escape",
                Terminator.DC1 => "Device control 1",
                Terminator.DC2 => "Device control 2",
                Terminator.DC3 => "Device control 3",
                Terminator.DC4 => "Device control 4",
                Terminator.NAK => "Negative acknowledge",
                Terminator.SYN => "Synchronous idle",
                Terminator.ETB => "End of transmission block",
                Terminator.CAN => "Cancel",
                Terminator.EM => "End of medium",
                Terminator.SUB => "Substitute",
                Terminator.ESC => "Escape",
                Terminator.FS => "File separator (->)",
                Terminator.GS => "Group separator (<-)",
                Terminator.RS => "Record separator (up arrow)",
                Terminator.US => "Unit separator (down arrow)",
                _ => "*NA*",
            };
        }




    }



} // namespace





