using System;

namespace BluetoothLE.Net.interfaces {

    /// <summary>Uniquely identifiable with a GUID</summary>
    public interface IUniquelyIdentifiable {

        /// <summary>Unique GATT identifier from server. Sets limit in system</summary>
        ushort AttributeHandle { get; set; }

        Guid Uuid { get; set; }
    }
}
