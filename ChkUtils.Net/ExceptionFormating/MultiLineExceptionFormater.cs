﻿using ChkUtils.Net.ExceptionParsers;
using System.Text;

namespace ChkUtils.Net.ExceptionFormating {

    /// <summary>
    /// Formats Exception information on one line
    /// </summary>
    /// <author>Michael Roop</author>
    /// <copyright>July 2012 Michael Roop Used by permission</copyright> 
    public class MultiLineExceptionFormater : IExceptionOutputFormater {

        /// <summary>
        /// Use the IExceptionParser to parse out all of the exception and
        /// nested exceptions stack information to a multi line string
        /// </summary>
        /// <param name="parser">The parser to break down the exception</param>
        /// <param name="target">The target string builder for the stack string</param>
        public void FormatException(IExceptionParser? parser, StringBuilder target) {

            // Get the first level parser for first level exception
            //IExceptionParser parser = ExceptionParserFactory.Get(e);
            while (parser != null) {
                // Exception Name and message
                target.AppendLine(String.Format("{0} : {1}", parser.Info.Name, parser.Info.Msg));

                // Extra info items added one per line
                parser.ExtraInfo.ForEach(
                    item => target.AppendLine(String.Format("{0}={1}", item.Name, item.Value)));

                // Stack trace items one per line
                parser.GetStackFrames(true).ForEach(
                    item => target.AppendLine(item));

                // Recurse to inner parser for inner exception
                parser = parser.InnerParser;
            }
        }


        //public void FormatException(IExceptionParser parser, StringBuilder target) {
        //    throw new NotImplementedException();
        //}
    }
}
