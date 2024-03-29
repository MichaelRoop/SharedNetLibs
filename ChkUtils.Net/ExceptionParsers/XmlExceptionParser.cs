﻿using System.Diagnostics;
using System.Xml;

namespace ChkUtils.Net.ExceptionParsers {

    /// <summary>
    /// Parse out the particulars of an XmlException
    /// </summary>
    /// <author>Michael Roop</author>
    /// <copyright>July 2012 Michael Roop Used by permission</copyright> 
    public class XmlExceptionParser : ExceptionParserBase {
        
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="e">The Exception to parse</param>
        public XmlExceptionParser(Exception e)
            : base(e) {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Add the extra info from XmlException
        /// </summary>
        /// <param name="e"></param>
        protected override void AddExtraInfo(Exception e) {
            if (e.GetType() == typeof(XmlException)) {
                XmlException ex = (XmlException)e;
                this.ExtraInfo.Add(new ExceptionExtraInfo("Line Number", ex.LineNumber.ToString()));
                this.ExtraInfo.Add(new ExceptionExtraInfo("Line Position", ex.LinePosition.ToString()));
                string? uri = ex.SourceUri;
                this.ExtraInfo.Add(new ExceptionExtraInfo("Source URI", uri??"--"));
            }
            else {
                WrapErr.SafeAction(() => 
                    Debug.WriteLine("The Exception is a {0} instead of an XmlException", e.GetType().Name));
            }
        }

        #endregion

    }
}
