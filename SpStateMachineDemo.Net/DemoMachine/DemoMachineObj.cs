using System;

namespace SpStateMachineDemo.Net.DemoMachine {

    public class DemoMachineObj :IDisposable {
        public DemoMachineObj() { }

        public void Dispose() {
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}
