using SpStateMachine.Net.Core;
using SpStateMachine.Net.Interfaces;

namespace TestCases.SpStateMachineTests.TestImplementations {
    public class MyDummyDI {

        #region static singleton instances

        private static ISpMsgFactory? msgFactoryInstance = null;

        #endregion

        #region Static properties to return singletons

        public static ISpMsgFactory MsgFactoryInstance {
            get {
                if (msgFactoryInstance == null) {
                    msgFactoryInstance = new SpMsgFactory(new MyMsgProvider());
                }
                return msgFactoryInstance;
            }
        }



        #endregion



    }
}
