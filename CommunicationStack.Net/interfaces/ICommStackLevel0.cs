using System;

namespace CommunicationStack.Net.interfaces {

    /// <summary>Stack object closest to the communication channel.  Assembles 
    /// incoming bytes into messages based on terminators and adds terminators 
    /// to messages before sending to the comm channel
    /// </summary>
    public interface ICommStackLevel0 {

        /// <summary>Event fired with the message stripped of termnators</summary>
        /// <remarks>
        /// An example of simple wrapper information is '\n\r' terminators. A sample stack
        /// with simple terminators are included in this projecct. Other, more complex
        /// wrappers will have to be coded for other applications
        /// </remarks>
        event EventHandler<byte[]> MsgReceived;


        /// <summary>Terminator used to recognize incoming msgs. Default '\n'</summary>
        byte[] InTerminators { get; set; }

        /// <summary>Terminator added to outgoing messages. Default '\n'</summary>
        byte[] OutTerminators { get; set; }

        ///// <summary>The outgoing comm channel</summary>
        //ICommStackChannel OutChannel { get; set; }


        /// <summary>Sends message through comm channel after adding terminators</summary>
        /// <param name="msg">The message to send</param>
        /// <returns>true on success, otherwise false</returns>
        bool SendToComm(byte[] msg);


        ///// <summary>Comm channel pushes incoming bytes here for processing</summary>
        ///// <param name="inData">The raw bytes comming from the comm channel</param>
        //void ProcessInBytes(byte[] inData);

    }
}
