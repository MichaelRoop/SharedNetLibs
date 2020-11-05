using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.interfaces;
using SerialCommon.Net.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerialCommon.Net.interfaces {

    public interface ISerialInterface : ICommStackChannel {


        #region Events

        /// <summary>Raised with list of adapters found in discovery</summary>
        event EventHandler<List<SerialDeviceInfo>> DiscoveredDevices;

        /// <summary>For various errors encountered in asynchronous operations</summary>
        event EventHandler<SerialUsbError> OnError;

        /// <summary>Async Connection completed</summary>
        event EventHandler<MsgPumpResults> OnSerialConnectionAttemptCompleted;

        #endregion

        #region Properties

        bool Connected { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronous discovery of WIFI adapters with DiscoveredAdapters event 
        /// raised on completion
        /// </summary>
        void DiscoverSerialDevicesAsync();


        /// <summary>Connect to a WIFI network</summary>
        /// <param name="dataModel">The information for connection</param>
        void ConnectAsync(SerialDeviceInfo dataModel);


        void Disconnect();

        #endregion


    }
}
