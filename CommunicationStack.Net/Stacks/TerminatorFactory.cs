﻿using VariousUtils.Net;

namespace CommunicationStack.Net.Stacks {

    /// <summary>Builds terminator info lists and makes it available</summary>
    public class TerminatorFactory {

        /// <summary>The terminator info list</summary>
        private readonly List<TerminatorInfo> items = new ();

        /// <summary>The terminator info list exposed to user</summary>
        public List<TerminatorInfo> Items { get { return this.items; } }


        /// <summary>Constructor builds the list</summary>
        public TerminatorFactory() {
            foreach (Terminator t in EnumHelpers.GetEnumList<Terminator>()) {
                this.items.Add(new TerminatorInfo(t));
            }
        }


    }
}
