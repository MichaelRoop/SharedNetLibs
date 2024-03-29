﻿using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using System.Diagnostics;

namespace LogUtils.Net {

    public class LogHelper {

        #region Data

        private readonly ClassLog log = new ("Logger");
        private DateTime currentDate = DateTime.Now;
        private bool sendToDebug = true;
        private string build = "0.0.0.0";
        private string appName = "UNKNOWN APP";

        #endregion

        #region Events

        /// <summary>Posts every message regardless of verbosity</summary>
        public event EventHandler<string>? EveryMsgEvent;

        /// <summary>Raised on messages of level Info</summary>
        public event EventHandler<string>? InfoMsgEvent;

        /// <summary>Raised on messages of level Debug</summary>
        public event EventHandler<string>? DebugMsgEvent;

        /// <summary>Raised on messages of level Warning</summary>
        public event EventHandler<string>? WarningMsgEvent;

        /// <summary>Raised on messages of level Error</summary>
        public event EventHandler<string>? ErrorMsgEvent;

        /// <summary>Raised on messages of level Exception</summary>
        public event EventHandler<string>? ExceptionMsgEvent;

        /// <summary>Raised on every message with raw info</summary>
        public Action<MsgLevel, ErrReport>? RawCurrentVerbotsityMsgInfoEvent;

        #endregion

        #region Public

        /// <summary>Setup where messages are pushed through the events</summary>
        /// <param name="build">Current build number for the log header</param>
        /// <param name="verbosity">Verbosity level of the logs</param>
        /// <param name="sendToDebug">Send to debug as well as events for logger</param>
        /// <param name="msgCountThreshold">
        /// The number of accumulated messages where they dumped even if dump timeout not expired
        /// </param>
        public void Setup(string build, MsgLevel verbosity, bool sendToDebug, int msgCountThreshold = 5) {
            this.Setup(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name??"---", 
                build, 
                verbosity, 
                sendToDebug, 
                msgCountThreshold);
        }


        /// <summary>Setup where messages are pushed through the events</summary>
        /// <param name="appName">Name of the application</param>
        /// <param name="build">Current build number for the log header</param>
        /// <param name="verbosity">Verbosity level of the logs</param>
        /// <param name="sendToDebug">Send to debug as well as events for logger</param>
        /// <param name="msgCountThreshold">
        /// The number of accumulated messages where they dumped even if dump timeout not expired
        /// </param>
        public void Setup(string appName, string build, MsgLevel verbosity, bool sendToDebug, int msgCountThreshold = 5) {
            this.build = build;
            this.appName = appName;
            this.sendToDebug = sendToDebug;
            WrapErr.SetStackTools(new StackTools());
            // TODO - this is done in the TestCases but not in app
            WrapErr.InitialiseOnExceptionLogDelegate(Log.LogExceptionDelegate);
            Log.SetStackTools(new StackTools());
            SetVerbosity(verbosity);
            Log.SetMsgNumberThreshold(msgCountThreshold);
            Log.OnLogMsgEvent += new LogingMsgEventDelegate(this.Log_OnLogMsgEvent);
            DumpLogHeader();
        }


        public static void SetVerbosity(MsgLevel verbosity) {
            Log.SetVerbosity(verbosity);
        }

        #endregion

        #region Event Handlers

        /// <summary>Safely pass Log message to the logger implementation</summary>
        /// <param name="level">The loging level of the message</param>
        /// <param name="err">The error report object with the information</param>
        void Log_OnLogMsgEvent(MsgLevel level, ErrReport err) {
            try {
                if (err.TimeStamp.Day != this.currentDate.Day) {
                    this.log.Warning(0, "******************* New Day *******************");
                    this.log.Warning(0, "*");
                    this.log.Warning(0, string.Format("*  Day {0}", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")));
                    this.log.Warning(0, "*");
                    this.log.Warning(0, "************************************************");
                    this.currentDate = err.TimeStamp;
                }

                this.EveryMsgEvent?.Invoke(this, Log.GetMsgFormatNoTimestamp(level, err));
                this.RawCurrentVerbotsityMsgInfoEvent?.Invoke(level, err);

                string msg = Log.GetMsgFormat1(level, err);
                switch (level) {
                    case MsgLevel.Info:
                        this.InfoMsgEvent?.Invoke(this, msg);
                        break;
                    case MsgLevel.Debug:
                        this.DebugMsgEvent?.Invoke(this, msg);
                        break;
                    case MsgLevel.Warning:
                        this.WarningMsgEvent?.Invoke(this, msg);
                        break;
                    case MsgLevel.Error:
                        this.ErrorMsgEvent?.Invoke(this, msg);
                        break;
                    case MsgLevel.Exception:
                        this.ExceptionMsgEvent?.Invoke(this, msg);
                        break;
                }

                if (sendToDebug) {
                    Debug.WriteLine(msg);
                }
            }
            catch (Exception e) {
                WrapErr.SafeAction(() => Debug.WriteLine(
                    string.Format("Exception on logging out message:{0}", e.Message)));
            }
        }

        #endregion

        #region Private

        /// <summary>Create a new header entry everytime the app starts up</summary>
        private void DumpLogHeader() {
            this.log.Warning(0, "");
            this.log.Warning(0, "************** New Session ****************");
            this.log.Warning(0, "*");
            this.log.Warning(0, string.Format("* {0}", this.appName));
            this.log.Warning(0, string.Format("* Version: {0}", this.build));
            // This operates on the project build version
            //this.log.Warning(0, string.Format("* Version: {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            this.log.Warning(0, "*");
            this.log.Warning(0, "*");
            this.log.Warning(0, string.Format("*  Day {0}", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")));
            this.log.Warning(0, "*");
            //this.log.Warning(0, string.Format("*  {0}", ""));
            this.log.Warning(0, "*******************************************");
        }


        #endregion

    }
}
