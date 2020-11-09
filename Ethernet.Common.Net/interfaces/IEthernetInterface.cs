using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.interfaces;
using Ethernet.Common.Net.DataModels;
using System;

namespace Ethernet.Common.Net.interfaces {

    public interface IEthernetInterface : ICommStackChannel {

        #region Events

        /// <summary>Raised so that host name and service name can be requested</summary>
        event EventHandler<EthernetParams> ParamsRequestedEvent;

        /// <summary>Async Connection completed</summary>
        event EventHandler<MsgPumpResults> OnEthernetConnectionAttemptCompleted;

        /// <summary>For various errors encountered in asynchronous operations</summary>
        event EventHandler<MsgPumpResults> OnError;

        #endregion

        #region Properties

        bool Connected { get; }

        #endregion

        #region Methods

        /// <summary>Connect to a WIFI network</summary>
        /// <param name="dataModel">The information for connection</param>
        void ConnectAsync(EthernetParams dataModel);


        /// <summary>Disconnect ethernet</summary>
        void Disconnect();

        #endregion

    }

}
