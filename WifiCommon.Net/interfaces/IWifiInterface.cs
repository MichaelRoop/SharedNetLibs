using System;
using System.Collections.Generic;
using System.Text;
using WifiCommon.Net.DataModels;

namespace WifiCommon.Net.interfaces {

    /// <summary>Interface to access WIFI modules</summary>
    public interface IWifiInterface {

        #region Events

        /// <summary>Raised with list of adapters found in discovery</summary>
        event EventHandler<List<WifiAdapterInfo>> DiscoveredAdapters;

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronous discovery of WIFI adapters with DiscoveredAdapters event 
        /// raised on completion
        /// </summary>
        void DiscoverWifiAdaptersAsync();

        #endregion

    }
}
