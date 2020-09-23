using System;
using System.Diagnostics;
using TestCases.Core.TestToolSet.Net;

namespace TestCases.Core.TestToolSet {

    public class TestCaseBase {

        #region Data

        protected HelperLogReaderNet logReader = new HelperLogReaderNet();

        #endregion

        public void OneTimeSetup() {
            try {
                this.logReader.StartLogging();
            }
            catch (Exception e) {
                Debug.WriteLine("Start logging exception:{0}", e.Message);
            }
        }

        public void OneTimeTeardown() {
            System.Threading.Thread.Sleep(1000);
//            this.logReader.StopLogging();
//            this.logReader.Clear();
        }



    }
}
