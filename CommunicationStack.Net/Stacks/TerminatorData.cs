using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.Stacks {

    /// <summary>Groups a list of terminator info and the block it defines</summary>
    public class TerminatorData {
        public byte[] TerminatorBlock { get; set; } = new byte[0];
        public List<TerminatorInfo> TerminatorInfos { get; set; } = new List<TerminatorInfo>();

        public TerminatorData() { }

        public TerminatorData(List<TerminatorInfo> infos) {
            this.TerminatorInfos = infos;
            this.TerminatorBlock = new byte[this.TerminatorInfos.Count];
            for (int i = 0; i < this.TerminatorBlock.Length; i++) {
                this.TerminatorBlock[i] = this.TerminatorInfos[i].Value;
            }
        }



    }
}
