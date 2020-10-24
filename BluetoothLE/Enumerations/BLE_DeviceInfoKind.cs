
namespace BluetoothLE.Net.Enumerations {

    /// <summary>Portable implementation of BLE Device Kind</summary>
    public enum BLE_DeviceInfoKind {

        /// <summary>
        /// The object is of an unknown type. This value is not used.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The DeviceInformation object represents a PnP device interface. These are exposed
        /// by device drivers to enable an app to talk to the device, typically using device
        /// IOCTLS (input output controls).
        /// </summary>
        PnP_Device_Interface = 1,

        /// <summary>
        /// The DeviceInformation object represents a device container. *DeviceContainer*
        /// objects describe a collection of device objects that exist in the same physical
        /// device. For example, a multi-function printer may have several different devices
        /// included, but they would all exist as part of the parent *DeviceContainer* object.
        /// </summary>
        Device_Container = 2,

        /// <summary>
        /// The DeviceInformation object represents a device object. This could also be referred
        /// to as a devnode. These devices are objects that represent a piece of the device
        /// functionality and optionally have drivers loaded on them. When a physical device
        /// is paired with windows, multiple *Device* objects are created for it. A device
        /// contains 0 or more *DeviceInterface* objects, is a child to one *DeviceContainer*
        /// object, and is related to 0 or 1 *AssociationEndpoint* objects.
        /// </summary>
        Device = 3,

        /// <summary>
        /// The DeviceInformation object represents a device interface class. Every *DeviceInterface*
        /// object belongs to a certain *DeviceInterfaceClass*. This is similar to a contract
        /// definition. These contracts are represented with an id and properties, just like
        /// every other PnP object. *DeviceInterfaceClass* objects contain little more information
        /// than a unique identifier and possibly a name.
        /// </summary>
        Device_Interface_Class = 4,

        /// <summary>
        /// The DeviceInformation object represents a device association endpoint (AEP).
        /// AEPs usually represent a device discovered over a wireless or network protocol.
        /// Some of these endpoints can be used without needing to first pair the device.
        /// Use CanPair to determine if a device supports pairing and IsPaired to determine
        /// if a device is already paired with the system. Only *AssociationEndpoint* objects
        /// have a non-NULL value for Pairing.
        /// </summary>
        AEP_Association_Endpoint = 5,

        /// <summary>
        /// Represents an association endpoint (AEP) container.
        /// An *AssociationEndpointContainer* object represents a single physical device
        /// that might have more than one *AssociationEndpoint* objects associated with it.
        /// For example, if a television supports two different network protocols, the *AssociationEndpointContainer*
        /// would be the television. It would also have two *AssociationEndpoint* objects
        /// to represent each protocol.
        /// </summary>
        AEP_Association_Endpoint_Container = 6,

        /// <summary>
        /// Represents an association endpoint (AEP) Service. An *AssociationEndpointService* 
        /// object represents a functional service contract exposed by the device. Not all 
        /// protocols support AEP services. An *AssociationEndpointService* can have a single 
        /// parent *AssociationEndpointContainer* object.
        /// </summary>
        AEP_Association_Endpoint_Service = 7,

        /// <summary>Represents a single physical face of a device enclosure</summary>
        Device_Panel = 8





    }
}
