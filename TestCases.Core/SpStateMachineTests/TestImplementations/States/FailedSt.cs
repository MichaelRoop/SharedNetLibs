using LogUtils.Net;
using SpStateMachine.Net.Interfaces;

namespace TestCases.SpStateMachineTests.TestImplementations.States {

    public class FailedSt : MyState {

        private readonly ClassLog log = new("FailedSt");

        public FailedSt(ISpState<MyMsgId> parent, MyDataClass dataClass)
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
