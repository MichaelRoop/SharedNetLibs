﻿using LogUtils.Net;
using NUnit.Framework;
using SpStateMachine.Net.EventListners;
using SpStateMachine.Net.Interfaces;
using System;
using System.Threading;
using TestCases.SpStateMachineTests.TestImplementations;
using TestCases.SpStateMachineTests.TestImplementations.Messages;
using TestCaseSupport.Core;

namespace TestCases.SpStateMachineTests {

    [TestFixture]
    public class SimpleEventListnerTests {

        #region Data

        HelperLogReader logReader = new ();
#pragma warning disable CS8618
        private ISpEventListner listner;
#pragma warning restore CS8600
        private ClassLog log = new ("SimpleEventListnerTests");

        #endregion

        #region Setup

        [SetUp]
        public void TestSetup() {
            this.logReader.StartLogging();
            this.listner = new SimpleEventListner();
        }

        [TearDown]
        public void TestTeardown() {
            // Wait for logs to dump
            Thread.Sleep(300);
            this.logReader.StopLogging();
            this.logReader.Clear();
            this.listner.Dispose();
        }

        #endregion

        #region PostMessage
            
        [Test]
        public void _50032_PostMessage_Disposed() {
            TestHelpers.CatchExpected(50032, "SimpleEventListner", "PostMessage", "Attempting to use Disposed Object", () => {
                this.listner.Dispose();
                this.listner.PostMessage(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start));
            });
        }

        #endregion

        #region PostResponse

        [Test]
        public void _50033_PostResponse_Disposed() {
            TestHelpers.CatchExpected(50033, "SimpleEventListner", "PostResponse", "Attempting to use Disposed Object", () => {
                this.listner.Dispose();
                this.listner.PostResponse(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
            });
        }

        #endregion

        #region MessageReceived


        [Test]
        public void _0_MessageReceived_validMsg() {
            bool received = false;
            ISpEventMessage? msgCopy = null;
            TestHelpers.CatchUnexpected(() => {
                this.listner.MsgReceived += new EventHandler((o, e) => {
                    this.log.Info("_0_MessageReceived_validMsg", "Woke up on msg received");
                    received = true;
                    msgCopy = ((SpMessagingArgs)e).Payload;
                });
                this.listner.PostMessage(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start));

            });

            // On thread pool so have to wait for response
            for (int i = 0; i < 21; i++) {
                if (received) {
                    this.log.Info("_0_MessageReceived_validMsg", () => string.Format("Received on count {0}", i));
                    break;
                }
                Thread.Sleep(25);
            }

            Assert.IsTrue(received, "The received event was not raised");
            Assert.IsNotNull(msgCopy, "Message was not copied");
            if (msgCopy == null) { return; } // For compiler
            Assert.AreEqual((int)MyMsgType.SimpleMsg, msgCopy.TypeId);
            Assert.AreEqual((int)MyMsgId.Start, msgCopy.EventId);
        }

        #endregion

        #region ResponseReceived

        [Test]
        public void _0_ResponseReceived_validMsg() {
            bool received = false;
            ISpEventMessage? msgCopy = null;

            TestHelpers.CatchUnexpected(() => {
                this.listner.ResponseReceived += new EventHandler((o, e) => {
                    this.log.Info("_0_MessageReceived_validMsg", "Woke up on msg received");
                    received = true;
                    msgCopy = ((SpMessagingArgs)e).Payload;
                });

                this.listner.PostResponse(
                    new MyBaseResponse(
                        MyMsgType.SimpleMsg,
                        new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Tick), MyReturnCode.Success, ""));
            });
            // On thread pool so have to wait for response
            for (int i = 0; i < 21; i++) {
                if (received) {
                    break;
                }
                Thread.Sleep(25);
            }
            Assert.IsTrue(received, "The received event was not raised");
            Assert.IsNotNull(msgCopy, "Message was not copied");
            if (msgCopy == null) { return; } // for compiler
            Assert.AreEqual((int)MyMsgType.SimpleMsg, msgCopy.TypeId);
            Assert.AreEqual((int)MyMsgId.Tick, msgCopy.EventId);
        }


        [Test]
        public void _50031_RaiseEvent_ResponseNoSubscribers() {
            TestHelpers.CatchUnexpected(() => {
                this.listner.PostResponse(
                    new MyBaseResponse(
                        MyMsgType.SimpleMsg,
                        new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Tick), MyReturnCode.Success, ""));
            });
            this.logReader.Validate(50031, "SimpleEventListner", "RaiseEvent", "No subscribers to 'Response' message");
        }


        [Test]
        public void _50031_MessageReceived_NoSubscribers() {
            TestHelpers.CatchUnexpected(() => {
                this.listner.PostMessage(new MyBaseMsg( MyMsgType.SimpleMsg, MyMsgId.Tick));
            });
            this.logReader.Validate(50031, "SimpleEventListner", "RaiseEvent", "No subscribers to 'Message' message");
        }


        [Test]
        public void _50030_RaiseEvent_CatchUserResponseDelegateException() {

            TestHelpers.CatchUnexpected(() => {
                this.listner.ResponseReceived += new EventHandler((o, e) => {
                    this.log.Info("_0_MessageReceived_validMsg", "** Response Received triggered - Exception coming **");
                    throw new Exception("User Exception in delegate");
                });

                this.listner.PostResponse(
                    new MyBaseResponse(
                        MyMsgType.SimpleMsg,
                        new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Tick), MyReturnCode.Success, ""));

            });
            // Allow the thread pool to catch up
            Thread.Sleep(100);
            //this.logReader.Validate(50030, "QueueUserWorkItemCallback", "WaitCallback_Context", "Unexpected Error Raising Event 'Response'");
            this.logReader.Validate(50030, "QueueUserWorkItemCallback", "Execute", "Unexpected Error Raising Event 'Response'");
        }


        [Test]
        public void _50030_RaiseEvent_CatchUserMessageDelegateException() {

            TestHelpers.CatchUnexpected(() => {
                this.listner.MsgReceived += new EventHandler((o, e) => {
                    this.log.Info("_0_MessageReceived_validMsg", "** Message Received triggered - Exception coming **");
                    throw new Exception("User Exception in delegate");
                });
                this.listner.PostMessage(
                    new MyBaseResponse(
                        MyMsgType.SimpleMsg,
                        new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Tick), MyReturnCode.Success, ""));
            });
            // Allow the thread pool to catch up
            Thread.Sleep(100);
            //this.logReader.Validate(50030, "QueueUserWorkItemCallback", "WaitCallback_Context", "Unexpected Error Raising Event 'Message'");
            this.logReader.Validate(50030, "QueueUserWorkItemCallback", "Execute", "Unexpected Error Raising Event 'Message'");

        }

        #endregion

    }
}
