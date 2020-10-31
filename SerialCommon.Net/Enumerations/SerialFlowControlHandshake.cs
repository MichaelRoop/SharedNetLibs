
namespace SerialCommon.Net.Enumerations {

    /// <summary>Cross platform enum of serial flow control protocols</summary>
    /// <remarks>
    /// Info from MS serial object
    /// </remarks>
    public enum SerialFlowControlHandshake {

        /// <summary>No protocol</summary>
        None = 0,

        /// <summary>On full incoming buffer RTS set false. When sending CTS set false</summary>
        /// <remarks>
        /// When the port is receiving data and if the read buffer is full, the Request-to-Send
        /// (RTS) line is set to **false**. When buffer is available, the line is set to
        /// **true**. When the serial port is transmitting data, CTS line is set to **false**
        ///     and the port does not send data until there is room in the write buffer.
        /// </remarks>
        RequestToSend = 1,

        /// <summary>Xoff sent to sender to stop sending. Xon sent to resume</summary>
        /// <remarks>
        /// The serial port sends an Xoff control to inform the sender to stop sending data.
        /// When ready, the port sends an Xon control to inform he sender that the port is
        /// now ready to receive data.
        /// </remarks>
        XonXoff = 2,

        /// <summary>Both Request to send and Xon Xoff used</summary>
        RequestToSendXonXoff = 3,

    }
}
