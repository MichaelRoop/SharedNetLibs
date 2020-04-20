
namespace CommunicationStack.Net.Stacks {

    public class TerminatorInfo {

        /// <summary>Unique ID for the terminator type</summary>
        public Terminator Code { get; set; } = Terminator.NUL;

        /// <summary>The ASCII byte value of the terminator</summary>
        public byte Value { get; set; } = (byte)Terminator.NUL;

        /// <summary>UI display of terminator like \n</summary>
        public string Display { get; set; } = Terminator.NUL.ToStringCharDisplay();

        /// <summary>The UI display of terminator in hex format like 0x03</summary>
        public string HexDisplay { get; set; } = Terminator.NUL.ToHexString();

        /// <summary>Description of terminator</summary>
        public string Description { get; set; } = "*NA*";


        /// <summary>Constructor</summary>
        /// <param name="code">The unique terminator enum</param>
        public TerminatorInfo(Terminator code) {
            this.Code = code;
            this.Value = (byte)this.Code;
            this.Display = this.Code.ToStringCharDisplay();
            this.HexDisplay = this.Code.ToHexString();
            this.Description = this.Code.Description();
        }

    }
}
