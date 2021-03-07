
using SerialCommon.Net.DataModels;

namespace SerialCommon.Net.StorageIndexExtraInfo {

    /// <summary>Store extra info in the index file for lookup compares</summary>
    /// <remarks>
    /// The extra info can be put in the ListBox display so user can select it
    /// based on the visual. The actual index info in the index item will 
    /// locate the correct file from storage
    /// 
    /// Also can be referenced when iterting through list as below
    /// 
    /// index is IIndexItem<SerialIndexExtraInfo>
    /// obj is SerialDeviceInfo
    /// 
    /// The index.Display has been populated with PortName on creation
    /// 
    /// Where 
    ///     index.Display == obj.PortName &&
    ///     index.ExtraInfoObj.USBVendorId == obj.USB_VendorId &&
    ///     index.ExtraInfoObj.USBProductId == obj.USB_ProductId;
    ///     
    /// Display is a field in the index
    /// 
    /// This will index to the actual SerialDeviceInfo object in storage
    /// Use the ushort id for query in case the name lookup changes
    /// </remarks>
    public class SerialIndexExtraInfo {

        public string PortName { get; set; } = string.Empty;

        /// <summary>Display string representing USB vendor. Either name of hex id</summary>
        public string USBVendor { get; set; } = string.Empty;

        /// <summary>Display string representing USB product. Either name of hex id</summary>
        public string USBProduct { get; set; } = string.Empty;


        /// <summary>ushort ID of USB vendor (Ex. 0x3EB is Atmel). User for querry</summary>
        public ushort USBVendorId { get; set; } = 0;

        /// <summary>ushort ID of USB Product (Ex 0x2145 is ATMEGA328P-XMINI (CDC ACM)). Use for query</summary>
        public ushort USBProductId { get; set; } = 0;


        public SerialIndexExtraInfo(SerialDeviceInfo info) {
            this.PortName = info.PortName;
            this.USBVendorId = info.USB_VendorId;
            this.USBVendor = info.USB_VendorIdDisplay;
            this.USBProductId = info.USB_ProductId;
            this.USBProduct = info.USB_ProductIdDisplay;
        }

        public SerialIndexExtraInfo() {

        }


    }
}
