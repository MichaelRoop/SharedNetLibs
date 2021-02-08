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
        // Default characteristic with no aggregate and more than one format descriptor
        RedundantFormatDescriptorsDiscarded,
        Failed,
        UnhandledError,
        UnknownError,
    }
}
