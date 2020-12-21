using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Enumerations {
    public enum BLEOperationStatus {
        Success,
        NotFound,
        NoServices,
        GetServicesFailed,

        Failed,
        UnhandledError,
        UnknownError,
    }
}
