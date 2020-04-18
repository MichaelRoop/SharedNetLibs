using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.Stacks {

    public class TerminatorInfo {

        public Terminator Code { get; set; } = Terminator.NUL;
        public byte Value { get; set; } = (byte)Terminator.NUL;
        public string HexDisplay { get; set; } = Terminator.NUL.ToHexString();
        public string Description { get; set; } = "*NA*";


        public TerminatorInfo(Terminator code) {
            this.Code = code;
            this.Value = (byte)this.Code;
            this.HexDisplay = this.Code.ToHexString();
            this.Description = this.Code.Description();
        }

    }
}
