using LogUtils.Net;
using NUnit.Framework;
using SpStateMachine.Net.Interfaces;
using System;
using System.Threading;
using TestCaseSupport.Core;
using TestCases.SpStateMachineTests.TestImplementations;
using TestCases.SpStateMachineTests.TestImplementations.Messages;
using TestCases.SpStateMachineTests.TestImplementations.SuperStates;
using TestCases.SpStateMachineTests.TestImplementations.SuperStates.CascadeOnExit;
using System.Diagnostics.CodeAnalysis;
using ChkUtils.Net;

namespace TestCases.SpStateMachineTests {

    [Ignore("NEED TO FIX")]
    [TestFixture]
    public class StateTransitionTests {

        #region Data

        readonly HelperLogReader logReader = new();

        #endregion

        #region Setup

        [SetUp]
        public void TestSetup() {
            this.logReader.StartLogging();
        }

        [TearDown]
        public void TestTeardown() {
            Thread.Sleep(200);
            this.logReader.StopLogging();
            this.logReader.Clear();
        }

        #endregion

        [Test]
        public void TestDeferedTransitionsInSuperState() {
            
            TestHelpers.CatchUnexpected(() => {

                // Setting flip count will cause back and fourth between active and idle
                MyDataClass dataClass = new ();
                MySuperState notStartedSs = new NotStartedSs(null, dataClass);
                ISpStateMachine sm = new MyStateMachine(dataClass, notStartedSs);

                //this.TickAndValidateState(new MyTickMsg(), sm, "NotStarted.Idle");
                //this.TickAndValidateState(new MyTickMsg(), sm, "NotStarted.Idle");

                TickAndValidateState(GetMsg(MyMsgId.Tick), sm, "NotStarted.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Start), sm, "NotStarted.Active");
                TickAndValidateState(GetMsg(MyMsgId.Abort), sm, "NotStarted.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Tick), sm, "NotStarted.Idle");
            });
        }


        [Test]
        public void TestExitStateTransitionsInSuperState() {

            TestHelpers.CatchUnexpected(() => {

                // Setting flip count will cause back and fourth between active and idle
                MyDataClass dataClass = new ();
                MySuperState mainSs = new MainSs(dataClass);
                ISpStateMachine sm = new MyStateMachine(dataClass, mainSs);

                //this.TickAndValidateState(new MyTickMsg(), sm, "Main.NotStarted");
                //this.TickAndValidateState(new MyTickMsg(), sm, "Main.NotStarted.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Tick), sm, "Main.NotStarted.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Start), sm, "Main.NotStarted.Active");
                TickAndValidateState(GetMsg(MyMsgId.Stop), sm, "Main.NotStarted.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Abort), sm, "Main.Recovery.Idle");
                //this.TickAndValidateState(this.GetMsg(MyEventType.Tick), sm, "Main.Recovery.Idle");

                //Thread.Sleep(500);
            });
        }


        [Test]
        public void TestExitStateCascadeInSuperState() {

            //TestHelpers.CatchUnexpected(() => {

            // Setting flip count will cause back and fourth between active and idle
            MyDataClass dataClass = new();
                MySuperState mainSs = new LevelMainSs(dataClass);
                ISpStateMachine sm = new MyStateMachine(dataClass, mainSs);

                ValidateState(sm, "Main.Level2.Level3.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Tick), sm, "Main.Level2.Level3.Idle");
                //this.TickAndValidateState(new MyTickMsg(), sm, "Main.Level2.Level3.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Start), sm, "Main.Level2.Level3.Active");

                Console.WriteLine("**********************************");
                //this.Tick(this.GetMsg(MyEventType.Abort), sm);
                TickAndValidateState(GetMsg(MyMsgId.Abort), sm, "Main.Recovery.Idle");
                TickAndValidateState(GetMsg(MyMsgId.Tick), sm, "Main.Recovery.Idle");



                //Console.WriteLine("**********************************");

                //this.Tick(new MyTickMsg(), sm);
                //Console.WriteLine("**********************************");

                //this.TickAndValidateState(new MyTickMsg(), sm, "Main.Recovery");
                //sm.Tick(new MyTickMsg());


                //this.TickAndValidateState(new MyTickMsg(), sm, "Main.NotStarted.Idle");
                //this.TickAndValidateState(this.GetMsg(MyEventType.Start), sm, "Main.NotStarted.Active");
                //this.TickAndValidateState(this.GetMsg(MyEventType.Stop), sm, "Main.NotStarted.Idle");
                //this.TickAndValidateState(this.GetMsg(MyEventType.Abort), sm, "Main.Recovery.Idle");
            //});
        }



        #region Private Methods

        private static MyBaseMsg GetMsg(MyMsgId eventId) {
            //Console.WriteLine("-- Sending msg:{0}", eventId.ToString());

            Log.Info("","", String.Format("---------------------- Sending msg:{0}", eventId));
            return new MyBaseMsg(MyMsgType.SimpleMsg, eventId);
        }


#pragma warning disable IDE0051 // Remove unused private members
        private static MyBaseMsg GetStartMsg() {
            return new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start);
        }

        private static MyBaseMsg GetStopMsg() {
            return new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Stop);
        }

        private static MyBaseMsg GetAbortMsg() {
            return new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Abort);
        }
#pragma warning restore IDE0051 // Remove unused private members

        [return:MaybeNull]
        private static ISpEventMessage Tick(ISpEventMessage msg, ISpStateMachine sm) {
            ISpEventMessage? ret = null;
            TestHelpers.CatchUnexpected(() => {
                ret = sm.Tick(msg);
            });
            return ret;
        }



        private static void TickAndValidateState(ISpEventMessage msg, ISpStateMachine sm, string expected) {
            ISpEventMessage? ret = Tick(msg, sm);
            Thread.Sleep(0);
            ValidateState(sm, expected);
            WrapErr.ChkVar(ret, 9999, "");
            ValidateReturn(msg, ret);
        }

        private static void ValidateReturn(ISpEventMessage msg, ISpEventMessage ret) {
            Assert.AreEqual(msg.Uid, ret.Uid, "Mismatch in GUIDs on return");
        }


        private static void ValidateState(ISpStateMachine sm, string expected) {
            Log.Info("", "", String.Format("---------------------- Validate that state is:{0}", expected));

            //Console.WriteLine("-- Validate that state is:{0}", expected);
            //Console.WriteLine("-- Validate that state is:{0} - Current State Name is: {1}", expected, sm.CurrentStateName);
            Assert.AreEqual(expected, sm.CurrentStateName);
        }

        #endregion

    }

}
