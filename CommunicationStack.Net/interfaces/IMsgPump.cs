using CommunicationStack.Net.DataModels;
using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.interfaces {

    /// <summary>Interface for a communications message pump</summary>
    /// <typeparam name="TConnectParams">The connect parameters object type</typeparam>
    public interface IMsgPump<TConnectParams> where TConnectParams : class {

        #region Properties

        /// <summary>Connected status</summary>
        bool Connected { get; }

        #endregion

        #region Events

        /// <summary>Raised on completion of connection attempt</summary>
        event EventHandler<MsgPumpConnectResults> ConnectResultEvent;

        /// <summary>Raised on each message received</summary>
        event EventHandler<byte[]> MsgReceivedEvent;

        #endregion

        #region Methods

        /// <summary>Do asynchronous connect to socket and raise ConnectResultEvent</summary>
        /// <param name="paramsObj">Data model holding the co</param>
        void ConnectAsync(TConnectParams paramsObj);

        /// <summary>Stop reading or sending if connected, then disconnect</summary>
        void Disconnect();

        /// <summary>Send out a message asynchronously</summary>
        /// <param name="msg">The message to send</param>
        void WriteAsync(byte[] msg);

        #endregion

    }



}
