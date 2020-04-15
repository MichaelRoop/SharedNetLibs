using System;

namespace CommunicationStack.Net.interfaces {

    /// <summary>Stack object closest to the communication channel.  Assembles 
    /// incoming bytes into messages based on terminators and adds terminators 
    /// to messages before sending to the comm channel
    /// </summary>
    public interface ICommStackLevel0 {

        #region Properties

        /// <summary>Event fired with message stripped of termnators defined in InTerminators</summary>
        event EventHandler<byte[]> MsgReceived;

        /// <summary>Terminator used to recognize incoming msgs</summary>
        byte[] InTerminators { get; set; }

        /// <summary>Terminator added to outgoing messages</summary>
        byte[] OutTerminators { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Allows defered initialisation with comm channel so DI can deliver 
        /// instances of these stacks for different communication channel objects. 
        /// </summary>
        /// <param name="commChannel">Communication channel satisfying the ICommStackChannel interface</param>
        void SetCommChannel(ICommStackChannel commChannel);


        /// <summary>Sends message to comm channel after adding terminators</summary>
        /// <param name="msg">The message to send</param>
        /// <returns>true on success, otherwise false</returns>
        bool SendToComm(byte[] msg);


        /// <summary>Sends message to comm channel after adding terminators</summary>
        /// <param name="msg">The message to send</param>
        /// <returns>true on success, otherwise false</returns>
        bool SendToComm(string msg);

        #endregion

    }

}
