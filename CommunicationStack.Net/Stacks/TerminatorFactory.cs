using System.Collections.Generic;
using VariousUtils;

namespace CommunicationStack.Net.Stacks {

    public class TerminatorFactory {

        List<TerminatorInfo> items = new List<TerminatorInfo>();

        public List<TerminatorInfo> Items { get { return this.items; } }


        public TerminatorFactory() {
            foreach (Terminator t in EnumHelpers.GetEnumList<Terminator>()) {
                this.items.Add(new TerminatorInfo(t));
            }
        }


    }
}
