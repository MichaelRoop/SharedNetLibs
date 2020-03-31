using ChkUtils.Net.ExceptionFormating;
using ChkUtils.Net.ExceptionParsers;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace ChkUtils.Net.ErrObjects {

    /// <summary>Object to hold error information</summary>
    /// <author>Michael Roop</author>
    /// <copyright>March 2020 Michael Roop Used by permission</copyright> 
    [DataContract]
    public class ErrReport {

        #region Data

        private int code = 0;

        private string atMethod = "";

        private string atClass = "";

        private string msg = "";

        private StringBuilder stackTrace = new StringBuilder();

        DateTime stamp = DateTime.Now;

        #endregion

        #region Properties

        /// <summary>Error code</summary>
        [DataMember]
        public int Code { get { return this.code; } set { this.code = value; } }

        /// <summary>Originating class for the error</summary>
        [DataMember]
        public string AtClass {
            get {
                return this.atClass;
            }
            set {
                this.atClass = value;
            }
        }


        /// <summary>
        /// The originating class for the error
        /// </summary>
        [DataMember]
        public string AtMethod {
            get {
                return this.atMethod;
            }
            set {
                this.atMethod = value;
            }
        }

        /// <summary>
        /// The error message
        /// </summary>
        [DataMember]
        public string Msg {
            get {
                return this.msg;
            }
            set {
                this.msg = value;
            }
        }

        /// <summary>
        /// The stack trace
        /// </summary>
        [DataMember]
        public string StackTrace {
            get {
                return this.stackTrace.ToString();
            }
            set {
                this.stackTrace.Clear();
                this.stackTrace.Append(value);
            }
        }

        /// <summary>
        /// The time stamp
        /// </summary>
        [DataMember]
        public DateTime TimeStamp {
            get {
                return this.stamp;
            }
            set {
                this.stamp = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for object with no error (success)
        /// </summary>
        public ErrReport() {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="atClass">Originating class</param>
        /// <param name="atMethod">Originating method</param>
        /// <param name="msg">Error message</param>
        /// <param name="atException">Originating Exception</param>
        public ErrReport(int code, string atClass, string atMethod, string msg, Exception atException) {
            this.code = code;
            this.atClass = atClass;
            this.atMethod = atMethod;
            this.msg = msg;
            this.InitialiseStackTraceInfo(atException);
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="method">Originating stack frame method</param>
        /// <param name="msg">Error message</param>
        /// <param name="atException">Originating Exception</param>
        public ErrReport(int code, ErrorLocation location, string msg, Exception atException)
            : this(code, location.ClassName, location.MethodName, msg, atException) {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="atClass">Originating class</param>
        /// <param name="atMethod">Originating method</param>
        /// <param name="msg">Error message</param>
        public ErrReport(int code, string atClass, string atMethod, string msg)
            : this(code, atClass, atMethod, msg, null) {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="method">Originating stack frame method</param>
        /// <param name="msg">Error message</param>
        public ErrReport(int code, ErrorLocation location, string msg)
            : this(code, location.ClassName, location.MethodName, msg, null) {
        }

        #endregion

        #region Private Methods

        /// <summary>Parse Exception to stack trace string and store in report</summary>
        /// <param name="e">The exception to parse</param>
        private void InitialiseStackTraceInfo(Exception e) {
            // Translate any exception information to string but do not store the exception. This allows the 
            // object to be serialized and passed to a FaultException that can used to traverse WCF boundries
            try {
                ExceptionFormaterFactory.Get().FormatException(ExceptionParserFactory.Get(e), stackTrace);
            }
            catch (Exception ee) {
                System.Diagnostics.Debug.WriteLine(string.Format("Exception caught from the exception formater - {0} - {1} {2}", e.Message, ee.Message, ee.StackTrace));
            }
        }

        #endregion

    }
}
