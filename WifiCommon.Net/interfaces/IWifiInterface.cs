using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WifiCommon.Net.DataModels;

namespace WifiCommon.Net.interfaces {

    /// <summary>Interface to access WIFI modules</summary>
    public interface IWifiInterface : ICommStackChannel {

        #region Events

        /// <summary>Raised with list of adapters found in discovery</summary>
        event EventHandler<List<WifiAdapterInfo>> DiscoveredAdapters;

        /// <summary>Raised with list of networks found in discovery</summary>
        event EventHandler<List<WifiNetworkInfo>> DiscoveredNetworks;

        /// <summary>For various errors encountered in asynchronous operations</summary>
        event EventHandler<WifiError> OnError;

        /// <summary>Async Connection completed</summary>
        event EventHandler<MsgPumpResults> OnWifiConnectionAttemptCompleted;

        /// <summary>Raised if there is no password, host name or service name in the connection data model</summary>
        event EventHandler<WifiCredentials> CredentialsRequestedEvent;

        #endregion

        #region Properties

        bool Connected { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronous discovery of WIFI adapters with DiscoveredAdapters event 
        /// raised on completion
        /// </summary>
        void DiscoverWifiAdaptersAsync();


        /// <summary>Connect to a WIFI network</summary>
        /// <param name="dataModel">The information for connection</param>
        void ConnectAsync(WifiNetworkInfo dataModel);


        void Disconnect();

        #endregion

    }
}
