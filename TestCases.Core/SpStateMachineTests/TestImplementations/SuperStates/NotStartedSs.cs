using SpStateMachine.Net.Interfaces;
using TestCases.SpStateMachineTests.TestImplementations.Messages;
using TestCases.SpStateMachineTests.TestImplementations.States;

namespace TestCases.SpStateMachineTests.TestImplementations.SuperStates {

    public class NotStartedSs : MySuperState {

        #region Data

        ISpState<MyMsgId> StateIdle;
        ISpState<MyMsgId> StateActive;

        #endregion

        public NotStartedSs(ISpState<MyMsgId> parent, MyDataClass dataClass)
            : base(parent, MyStateID.NotStarted, dataClass) {

            // Setup sub-states
            this.StateIdle = (MyState)this.AddSubState(new IdleSt(this, dataClass));
            this.StateActive = (MyState)this.AddSubState(new ActiveSt(this, dataClass));

            // Idle State event and results transitions
            this.StateIdle.ToNextOnEvent(MyMsgId.Start, this.StateActive);
            this.StateIdle.ToExitOnEvent(MyMsgId.Abort);
            this.StateIdle.ToNextOnResult(MyMsgId.Start, this.StateActive);

            // Active State event and results transitions
            this.StateActive.ToNextOnEvent(MyMsgId.Stop, this.StateIdle, new MyTickMsg());
            this.StateActive.ToDeferedOnEvent(MyMsgId.Abort);
            this.StateActive.ToNextOnResult(MyMsgId.Stop, this.StateIdle, new MyTickMsg());

            // Super state transitions
            this.ToNextOnResult(MyMsgId.Stop, this.StateIdle);

            this.SetEntryState(this.StateIdle);
        }

    }
}
