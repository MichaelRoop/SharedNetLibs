using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers;
using BluetoothLE.Net.Parsers.Characteristics;
using BluetoothLE.Net.Tools;
using LogUtils.Net;

namespace BluetoothLE.Net.DataModels {

    /// <summary>Cross platform holder of BLE Characteristic information</summary>
    public class BLE_CharacteristicDataModel : IUniquelyIdentifiable {

        // TODO need event to get the value read at the OS level Characteristic
        // TODO need to expose something so we can write to the OS level Characteristic
        // UWP characteristic has a ValueChangedEvent - reads bytes. Need to translate to string? or data type?

        #region Data

        private readonly BLERangeValidator validator = new ();
        private readonly ClassLog log = new ("BLE_CharacteristicDataModel");

        #endregion

        #region Events

        /// <summary>Raised from OS level when a read value changes</summary>
        public event EventHandler<BLE_CharacteristicReadResult>? OnReadValueChanged;

        /// <summary>Raised from OS level when read write error detected on the Characteristic</summary>
        public event EventHandler<BLE_CommunicationError>? OnCommunicationsError; 
        
        /// <summary>Raised from User to request a read of characteristic</summary>
        public event EventHandler? ReadRequestEvent;

        /// <summary>Raised from User to request a data write to the characteristic</summary>
        public event EventHandler<byte[]>? WriteRequestEvent;

        #endregion

        /// <summary>Unique identifier given by device</summary>
        public ushort AttributeHandle { get; set; } = 0;

        /// <summary>Determines what this characteristic can do</summary>
        public CharacteristicProperties PropertiesFlags { get; set; } = CharacteristicProperties.None; 

        /// <summary>Unique identifier</summary>
        public Guid Uuid { get; set; } = Guid.Empty;

        public GattNativeCharacteristicUuid GattType { get; set; } = GattNativeCharacteristicUuid.None;

        public BLE_ProtectionLevel ProtectionLevel { get; set; } = BLE_ProtectionLevel.DefaultPlain;

        public string DisplayHeader { get; set; } = "Characteristic";

        public string DisplayReadWrite { get; set; } = string.Empty;

        public string CharName { get; set; } = "xxxx";

        public string CharValue { get; set; } = string.Empty;

        /// <summary>User friendly description or empty</summary>
        public string UserDescription { get; set; } = string.Empty;

        public string DataTypeDisplay { get { return this.Parser.DataType.ToStr(); } }

        public List<BLE_DescriptorDataModel> Descriptors { get; set; } = new List<BLE_DescriptorDataModel>();

        // TODO - why a list? Can characteristic data have multiple formats?
        public List<BLE_PresentationFormat> PresentationFormats { get; set; } = new List<BLE_PresentationFormat>();

        /// <summary>The service that holds this characteristic</summary>
        public BLE_ServiceDataModel? Service { get; set; } 

        /// <summary>The parser to get read values for the characteristic</summary>
        public ICharParser Parser { get; set; } = new CharParser_Default();

        /// <summary>Bind the Characteristic parser with Descriptor parsers after both set</summary>
        public BLEOperationStatus SetDescriptorParsers() {
            List<IDescParser> descParsers = new ();
            foreach (var des in this.Descriptors) {
                descParsers.Add(des.Parser);
            }
            return this.Parser.SetDescriptorParsers(descParsers);
        }


        public bool IsReadable {
            get {
                return this.PropertiesFlags.HasFlag(CharacteristicProperties.Read);
            }
        }


        public bool IsWritable {
            get {
                return this.PropertiesFlags.HasFlag(CharacteristicProperties.Write);
            }
        }


        public BLE_CharacteristicDataModel() {
            //this.Descriptors = new Dictionary<string, BLE_DescriptorDataModel>();
            //this.Descriptors.Add("44", new BLE_DescriptorDataModel() {
            //    DisplayName = "blipo descriptor in characteristic",
            //});
        }


        /// <summary>Get data type and range information to display to user</summary>
        /// <returns>The data type display info for the Characteristic</returns>
        public DataTypeDisplay GetDataDisplayInfo() {
            return BLERangeValidator.GetRange(this.Parser.DataType);
        }


        public bool Read() {
            if (this.IsReadable) {
                this.ReadRequestEvent?.Invoke(this, new EventArgs());
            }
            return false;
        }


        public void Write(byte[] data) {
            // The binder will pick up this event and pass the data to the OS Characteristic Write
            this.WriteRequestEvent?.Invoke(this, data);
        }

        // Rather 
        public RangeValidationResult Write(string msg) {
            // Parse according to data type. On error return the code. On success proceed
            //this.Parser.DataType
            RangeValidationResult result = this.validator.Validate(msg, this.Parser.DataType);
            if (result.Status == BLE_DataValidationStatus.Success) {
                this.log.Info("Write", () => string.Format("Validated:{0}",msg));
                this.Write(result.Payload);
            }
            return result;
        }


        /// <summary>Used by the OS to push up characteristic read data</summary>
        /// <param name="data">The data read</param>
        public void PushReadDataEvent(byte[] data, string strValue) {
            this.CharValue = strValue;
            this.OnReadValueChanged?.Invoke(this, new BLE_CharacteristicReadResult(
                this,
                BLE_CharacteristicCommunicationStatus.Success,
                data,
                strValue)); 

            // TODO - we could just write the data to a Data field in string format 
            // and inform user to update to refresh display
            // User could also grab the data to push it somewhere else

            // This data model is what is displayed in the WIN BLE_ServicesDisplay
            // to writing to a field should work. the update is in question

            // TODO Write to CharValue. Need to convert according to type of value
        }


        /// <summary>Used by the OS to push up an error during read or write</summary>
        /// <param name="status"></param>
        public void PushCommunicationError(BLE_CharacteristicCommunicationStatus status) {
            this.OnCommunicationsError?.Invoke(this, new BLE_CommunicationError(this, status));
        }

    }
}
