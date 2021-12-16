using LogUtils.Net;
using SpStateMachine.Net.Interfaces;
using TestCases.SpStateMachineTests.TestImplementations.Messages;

namespace TestCases.SpStateMachineTests.TestImplementations.States {

    public class ActiveSt : MyState {

        private readonly ClassLog log = new ("ActiveSt");
//        private int triggerCount = 0;


        public ActiveSt(ISpState<MyMsgId> parent, MyDataClass dataClass)
            : base(parent, MyStateID.Active, dataClass) {
        }

        protected override ISpEventMessage ExecOnEntry(ISpEventMessage msg) {
            this.log.Info("ExecOnEntry", this.FullName);
            //return base.ExecOnEntry(msg);
            return this.MsgFactory.GetDefaultResponse(msg);
        }

        protected override ISpEventMessage ExecOnTick(ISpEventMessage msg) {
            this.log.Info("ExecOnTick", "");
            if (This.DoIFlipStates) {
                // TODO rework msg to allow creation of a msg with another msg to transfer correlation GUID
                this.log.Info("ExecOnTick", "Exceeded trigger count, ** changing msg to Stop");
                MyBaseMsg newMsg = new (MyMsgType.SimpleMsg, MyMsgId.Stop);
                newMsg.Uid = msg.Uid;
                //return base.ExecOnTick(newMsg);
            }
            //return base.ExecOnEntry(msg);

            return msg;
        }

        protected override void ExecOnExit() {
            this.log.Info("ExecOnExit", "");
            //base.ExecOnExit();
        }

    }
}
