using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCases.TestToolSet;
//using TestCases.TestToolSet.Net;

namespace TestCases {
    
    public class TestCaseBase {

        #region Data

        protected HelperLogReader logReader = new HelperLogReader();

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
