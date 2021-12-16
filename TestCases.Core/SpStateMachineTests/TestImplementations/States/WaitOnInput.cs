using LogUtils.Net;
using SpStateMachine.Net.Interfaces;

namespace TestCases.SpStateMachineTests.TestImplementations.States {

    public class WaitOnInput : MyState {

        private readonly ClassLog log = new ("WaitOnInput");

        public WaitOnInput(ISpState<MyMsgId> parent, MyDataClass dataClass)
            : base(parent, MyStateID.Idle, dataClass) {
        }

        protected override ISpEventMessage ExecOnEntry(ISpEventMessage msg) {
            this.log.Info("ExecOnEntry", "");
            return base.ExecOnEntry(msg);
        }

        protected override ISpEventMessage ExecOnTick(ISpEventMessage msg) {
            this.log.Info("ExecOnTick", "");
            return base.ExecOnEntry(msg);
        }

        protected override void ExecOnExit() {
            this.log.Info("ExecOnExit", "");
            base.ExecOnExit();
        }

    }
}
