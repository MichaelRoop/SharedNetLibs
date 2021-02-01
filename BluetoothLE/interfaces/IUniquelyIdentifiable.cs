using System;

namespace BluetoothLE.Net.interfaces {

    /// <summary>Uniquely identifiable with a GUID</summary>
    public interface IUniquelyIdentifiable {
        Guid Uuid { get; set; }
    }
}
