using LanguageFactory.Net.data;
using LanguageFactory.Net.interfaces;
using LanguageFactory.Net.Messaging;
using NUnit.Framework;
using TestCaseSupport.Core;

namespace TestCases.LanguageTests.Net {

    [TestFixture]
    public class LanguageModulesTestCases : TestCaseBase {

        #region Setup

        private ILangFactory factory = null;
        private SupportedLanguage selectedLanguage = new SupportedLanguage();
        private bool isEventRaised = false;

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
            this.factory = new SupportedLanguageFactory();
            this.factory.LanguageChanged += Factory_LanguageChanged;
        }

        private void Factory_LanguageChanged(object sender, SupportedLanguage language) {
            this.isEventRaised = true;
            this.selectedLanguage = language;
        }

        [OneTimeTearDown]
        public void TestSetTeardown() {
            this.OneTimeTeardown();
        }

        [SetUp]
        public void SetupEachTest() {
            // Reset it each time to english
            this.factory.SetCurrentLanguage(LangCode.English);
            this.isEventRaised = false;
        }

        #endregion

        #region Test1

        [Test]
        public void TestDefaultLanguage() {
            TestHelpers.CatchUnexpected(() => {
                //this.factory.SetCurrentLanguage(LangCode.English);
                string msg = this.factory.GetMsgDisplay(MsgCode.exit);
                Assert.AreEqual("Exit", msg);
            });
        }

        [Test]
        public void ChangeToChinese() {
            TestHelpers.CatchUnexpected(() => {
                // language is always set to english at start of tests
                this.factory.SetCurrentLanguage(LangCode.Chinese);
                string msg = this.factory.GetMsgDisplay(MsgCode.start);
                Assert.AreEqual("开始", msg);
                Assert.AreEqual(true, this.isEventRaised);
                Assert.AreEqual(LangCode.Chinese, this.selectedLanguage.Language.Code);
            });
        }


        [Test]
        public void ChangeToSpanish() {
            TestHelpers.CatchUnexpected(() => {
                // language is always set to english at start of tests
                this.factory.SetCurrentLanguage(LangCode.Spanish);
                string msg = this.factory.GetMsgDisplay(MsgCode.stop);
                Assert.AreEqual("Detener", msg);
                Assert.AreEqual(true, this.isEventRaised);
                Assert.AreEqual(LangCode.Spanish, this.selectedLanguage.Language.Code);
            });
        }



        #endregion

        /*
        TestHelpers.CatchUnexpected(() => {
        });
        */

    }
}
