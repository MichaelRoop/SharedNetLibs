using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Enumerations {
    public enum BLEOperationStatus {
        Success,
        NotFound,
        NoServices,
        GetServicesFailed,
        /// <summary>Used when validating the Format descriptors for the Aggregate format</summary>
        AggregateFormatMissingFormats,
        AggregateFormatDuplicateFormats,
        AggregateFormatHandleNotFormatType,
        RedundantFormatDescriptorsDiscarded,
        Failed,
        UnhandledError,
        UnknownError,
    }
}
