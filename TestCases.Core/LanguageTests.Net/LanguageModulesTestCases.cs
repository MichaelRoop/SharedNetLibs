using LanguageFactory.Net.data;
using LanguageFactory.Net.interfaces;
using LanguageFactory.Net.Messaging;
using NUnit.Framework;
using TestCaseSupport.Core;

namespace TestCases.LanguageTests.Net {

    [TestFixture]
    public class LanguageModulesTestCases : TestCaseBase {

        #region Data

        internal class TestDefaultLanguageDefined : SupportedLanguage {
            public TestDefaultLanguageDefined() : base() {
                this.SetLanguage(LangCode.BOGUS_TEST_LANGUAGE, "Bogussssss");
                this.AddMsg(MsgCode.save, "Blippo Blippo");
                // Others should have the default english

            }
        }


        #endregion

        #region Setup

#pragma warning disable CS8618
        private ILangFactory factory;
#pragma warning restore CS8618
        private SupportedLanguage selectedLanguage = new();
        private bool isEventRaised = false;

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
            this.factory = new SupportedLanguageFactory();
            this.factory.LanguageChanged += Factory_LanguageChanged;
        }

        private void Factory_LanguageChanged(object? sender, SupportedLanguage language) {
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

        #region Load Unload

        [Test]
        public void T01_01_UnloadNonLoaded() {
            TestHelpers.CatchUnexpected(() => {
                bool result = this.factory.UnloadLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                Assert.False(result, "Faile to unload");
            });
        }


        [Test]
        public void T01_02_LoadUnload() {
            TestHelpers.CatchUnexpected(() => {
                this.factory.LoadLanguage(new TestDefaultLanguageDefined());
                this.factory.SetCurrentLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                string msg = this.factory.GetMsgDisplay(MsgCode.save);
                Assert.AreEqual("Blippo Blippo", msg);
                bool result = this.factory.UnloadLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                Assert.True(result, "Faile to unload");
            });
        }


        [Test]
        public void T01_03_LoadTwice() {
            TestHelpers.CatchUnexpected(() => {
                this.factory.LoadLanguage(new TestDefaultLanguageDefined());
                this.factory.LoadLanguage(new TestDefaultLanguageDefined());
                bool result = this.factory.UnloadLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                Assert.True(result, "Faile to unload");
                result = this.factory.UnloadLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                Assert.False(result, "Should have failed on second unload");
            });
        }


        [Test]
        public void T01_04_UnloadTwice() {
            TestHelpers.CatchUnexpected(() => {
                this.factory.LoadLanguage(new TestDefaultLanguageDefined());
                bool result = this.factory.UnloadLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                Assert.True(result, "Should have unloaded on first try");
                result = this.factory.UnloadLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                Assert.False(result, "Should have failed on second unload");
            });
        }



        #endregion

        #region Test language messages

        [Test]
        public void T02_01_DefaultLanguage() {
            TestHelpers.CatchUnexpected(() => {
                //this.factory.SetCurrentLanguage(LangCode.English);
                string msg = this.factory.GetMsgDisplay(MsgCode.exit);
                Assert.AreEqual("Exit", msg);
            });
        }




        [Test]
        public void T02_02_ChangeToChinese() {
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
        public void T02_03_ChangeToSpanish() {
            TestHelpers.CatchUnexpected(() => {
                // language is always set to english at start of tests
                this.factory.SetCurrentLanguage(LangCode.Spanish);
                string msg = this.factory.GetMsgDisplay(MsgCode.stop);
                Assert.AreEqual("Detener", msg);
                Assert.AreEqual(true, this.isEventRaised);
                Assert.AreEqual(LangCode.Spanish, this.selectedLanguage.Language.Code);
            });
        }


        [Test]
        public void T02_04_MissingEntryInLanguage() {
            TestHelpers.CatchUnexpected(() => {
                this.factory.LoadLanguage(new TestDefaultLanguageDefined());
                this.factory.SetCurrentLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                string msg = this.factory.GetMsgDisplay(MsgCode.save);
                Assert.AreEqual("Blippo Blippo", msg);
                // This message is not defined in test language
                msg = this.factory.GetMsgDisplay(MsgCode.exit);
                Assert.AreEqual("Exit", msg);
                bool result = this.factory.UnloadLanguage(LangCode.BOGUS_TEST_LANGUAGE);
                Assert.True(result, "Should have unloaded test language");
            });
        }



        #endregion






        /*
        TestHelpers.CatchUnexpected(() => {
        });
        */

    }
}
