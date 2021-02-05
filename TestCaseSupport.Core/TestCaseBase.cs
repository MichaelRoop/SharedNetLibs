using System;
using System.Diagnostics;

namespace TestCaseSupport.Core {

    public class TestCaseBase {

        #region Data

        protected HelperLogReader logReader = new HelperLogReader();

        #endregion

        public virtual void OneTimeSetup() {
            try {
                this.logReader.StartLogging();
            }
            catch (Exception e) {
                Debug.WriteLine("Start logging exception:{0}", e.Message);
            }
        }

        public virtual void OneTimeTeardown() {
            System.Threading.Thread.Sleep(1000);
//            this.logReader.StopLogging();
//            this.logReader.Clear();
        }



    }
}
