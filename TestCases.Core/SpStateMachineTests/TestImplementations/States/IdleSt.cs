using LogUtils.Net;
using SpStateMachine.Net.Interfaces;
using TestCases.SpStateMachineTests.TestImplementations.Messages;

namespace TestCases.SpStateMachineTests.TestImplementations.States {

    public class IdleSt : MyState {

        //        private int triggerCount = 0;
        private readonly ClassLog log = new ("IdleSt");


        public IdleSt(ISpState<MyMsgId> parent, MyDataClass dataClass)
            : base(parent, MyStateID.Idle, dataClass) {
        }

        protected override ISpEventMessage ExecOnEntry(ISpEventMessage msg) {
            this.log.Info("ExecOnEntry", this.FullName);
            //return base.ExecOnEntry(msg);
            return this.MsgFactory.GetDefaultResponse(msg);
        }

        protected override ISpEventMessage ExecOnTick(ISpEventMessage msg) {
            this.log.Info("ExecOnTick", this.FullName + " ********************************************** ");
            if (This.DoIFlipStates) {
                // TODO - rework msg to allow creation of a msg with another msg to transfer correlation GUID
                this.log.Info("ExecOnTick", "Exceeded trigger count, ** changing msg to Start");
                MyBaseMsg newMsg = new (MyMsgType.SimpleMsg, MyMsgId.Start);
                newMsg.Uid = msg.Uid;
                //return base.ExecOnTick(newMsg);
            }
            return msg;
            //return base.ExecOnEntry(msg);
        }

        protected override void ExecOnExit() {
            this.log.Info("ExecOnExit", "");
            //base.ExecOnExit();
        }


        //override onde


    }
}
