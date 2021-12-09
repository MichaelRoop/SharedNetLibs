using ChkUtils.Net.ErrObjects;

namespace LogUtils.Net.Interfaces {

    /// <summary>Abstract to OS specific way of writing to a console or other debut output</summary>
    public interface IOS_ConsoleWriter {

        /// <summary>Write to equivalent of a console</summary>
        /// <param name="logLine">The line to log to the output</param>
        void WriteToConsole(string logLine);


        /// <summary>Write to the equivalent of a console with formating of output done the OS level
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="report"></param>
        void WriteToConsole(MsgLevel level, ErrReport report);

    }

}
