using SpStateMachine.Net.Converters;
using SpStateMachine.Net.Core;
using SpStateMachine.Net.Interfaces;

namespace TestCases.SpStateMachineTests.TestImplementations.Messages {

    /// <summary>
    /// Default response for ok returns
    /// </summary>
    //public class MySimpleOkResponse : MyBaseResponse {
    public class MySimpleOkResponse : MyBaseMsg {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="msg">The paired incoming message</param>
        public MySimpleOkResponse(ISpEventMessage msg)
            : this(msg, "") {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="msg">The paired incoming message</param>
        /// <param name="status">Extra status information</param>
        //public MySimpleOkResponse(MyBaseMsg msg, string status)
        //: base(MyMsgType.SimpleResponse, msg, MyReturnCode.Success, status) {
        public MySimpleOkResponse(ISpEventMessage msg, string status)
            : base(MyMsgType.SimpleResponse, MyMsgId.Tick, SpEventPriority.Normal) {
                this.ReturnCode = SpConverter.EnumToInt(MyReturnCode.Success);
                this.ReturnStatus = status;
                this.Uid = msg.Uid;
        }



        
        
    }
}
