using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCases.TestToolSet.Net;

namespace TestCases {
    
    public class TestCaseBase {

        #region Data

        protected HelperLogReaderNet logReader = new HelperLogReaderNet();

        #endregion

        public void OneTimeSetup() {
            this.logReader.StartLogging();
        }

        public void OneTimeTeardown() {
            System.Threading.Thread.Sleep(1000);
            this.logReader.StopLogging();
            this.logReader.Clear();
        }



    }
}
