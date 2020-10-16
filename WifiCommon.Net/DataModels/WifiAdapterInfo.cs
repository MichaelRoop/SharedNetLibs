using System;
using WifiCommon.Net.Enumerations;

namespace WifiCommon.Net.DataModels {

    /// <summary>Cross platform data retrieved from list of adapters</summary>
    public class WifiAdapterInfo {

        /// <summary>Unique identifier for the adapter</summary>
        public Guid AdapterId { get; set; } = Guid.Empty;

        /// <summary>Internet Assigned Names Authority given types</summary>
        public WifiIanaType IanaType { get; set; } = WifiIanaType.Undefined;

        /// <summary>Maximum inbound transfer rate in bits per second</summary>
        public ulong MaxBitsPerSecondIn { get; set; } = 0;

        /// <summary>Maximum outbound transfer rate in bits per second</summary>
        public ulong MaxBitsPerSecondOut { get; set; } = 0;

        public WifiReconnectionKind ReconnectionKind { get; set; } = WifiReconnectionKind.Automatic;

        // TODO - probably the TCP address

        // TODO UWP has connection profile informat

        // TODO  From the NetworkItem. do not know if cross platform
        // Only applies if is type Private
        //public Guid NetworkId { get; set; } = Guid.Empty;

        // NetkWorkItem also has list of NetworkTypes
        // None 0, Internet 1, Private 2 = use bitwise


    }
}
