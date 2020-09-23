using LogUtils.Net;
using SpStateMachine.Net.Interfaces;

namespace TestCases.SpStateMachineTests.TestImplementations.States {

    public class FailedSt : MyState {

        private string className = "FailedSt";

        public FailedSt(ISpState<MyMsgId> parent, MyDataClass dataClass)
            : base(parent, MyStateID.Idle, dataClass) {
        }

        protected override ISpEventMessage ExecOnEntry(ISpEventMessage msg) {
            Log.Info(this.className, "ExecOnEntry", "");
            return base.ExecOnEntry(msg);
        }

        protected override ISpEventMessage ExecOnTick(ISpEventMessage msg) {
            Log.Info(this.className, "ExecOnTick", "");
            return base.ExecOnEntry(msg);
        }

        protected override void ExecOnExit() {
            Log.Info(this.className, "ExecOnExit", "");
            base.ExecOnExit();
        }

    }
}
