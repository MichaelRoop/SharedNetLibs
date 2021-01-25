using BluetoothLE.Net.interfaces;
using ChkUtils.Net;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {
    public abstract class DescParser_Base : IDescParser {

        #region Data

        private ClassLog baseLog = new ClassLog("DescParser_Base");

        /// <summary>Number of bytes in byte field</summary>
        protected const int BYTE_LEN = 1;
        /// <summary>Number of bytes for uint16 field</summary>
        protected const int UINT16_LEN = sizeof(ushort);
        /// <summary>Number of bytes for uint32 field</summary>
        protected const int UINT32_LEN = sizeof(uint);
        /// <summary>Number of bytes for time second field</summary>
        protected const int TIMESECOND_LEN = 3; // 3 bytes, 24bit

        #endregion

        /// <summary>Raw bytes as returned from Descriptor retrieval</summary>
        private byte[] RawData { get; set; } = new byte[0];

        protected virtual bool IsDataVariableLength { get; set; } = false;


        #region IDescParser Propertis and methods

        /// <summary>Type of derived class to determine cast for specific Property with data</summary>
        public Type ImplementationType { get; private set; } = typeof(DescParser_Base);


        /// <summary>The number of bytes the parser requires</summary>
        public virtual int RequiredBytes { get; set; } = 0;

        /// <summary>User friendly display of descriptor value(s)</summary>
        public string DisplayString { get; set; } = "";


        /// <summary>Parse out the bytes returned from querying Descriptor</summary>
        /// <remarks>All is wrapped in try/catch so derived do not have to</remarks>
        /// <param name="data">The bytes to parse</param>
        /// <returns>A display string or "* N/A *" on failure</returns>
        public string Parse(byte[] data) {
            try {
                // Make sure zero out raw value. 
                this.RawData = new byte[0];
                this.DisplayString = "";
                // Do not need to reset type. Done on construction
                this.ResetMembers();
                if (this.CopyToRawData(data)) {
                    this.DoParse(this.RawData);
                }
                return this.DisplayString;
            }
            catch (Exception e) {
                this.baseLog.Exception(13307, "Parse", "Failure on Parse", e);
                return "ERR";
            }
        }

        #endregion

        #region Constructors

        public DescParser_Base() {
            WrapErr.ToErrorReportException(13325, "Failed on construction", () => {
                this.ImplementationType = this.GetDerivedType();
                this.RawData = new byte[0];
                this.ResetMembers();
            });
        }

        #endregion


        /// <summary>
        /// Creates a new sized Raw buffer array and copies bytes to it. CALL IN DoParse method
        /// </summary>
        /// <param name="data">The data to copy</param>
        /// <param name="length">The length of data to copy</param>
        /// <returns>true on success, otherwise false on exception or if data null or smaller than length</returns>
        private bool CopyToRawData(byte[] data) {
            try {
                if (data != null) {
                    if (data.Length > 0) {
                        this.SetDataLengthIfVariable(data);
                        if (data.Length >= this.RequiredBytes) {
                            this.RawData = new byte[this.RequiredBytes];
                            Array.Copy(data, this.RawData, this.RawData.Length);
                            this.baseLog.Info("CopyToRawData", () => string.Format("Data:{0}", this.RawData.ToHexByteString()));
                            return true;
                        }

                        this.baseLog.Error(13315, "CopyToRawData",
                            () => string.Format("Data length:{0} smaller than requested:{1} Data '{2}'",
                            data.Length, this.RequiredBytes, data.ToHexByteString()));
                    }
                    else {
                        // Change in the xml
                        this.baseLog.Error(13305, "CopyToRawData", "byte[] is zero length");
                    }
                }
                else {
                    this.baseLog.Error(13316, "CopyToRawData", "Raw byte[] is null");
                }
            }
            catch (Exception e) {
                this.baseLog.Exception(13317, "CopyToRawData", "Failed on CopyToRaw", e);
                this.DisplayString = "ERR";
            }
            return false;
        }


        private void SetDataLengthIfVariable(byte[] data) {
            if (this.IsDataVariableLength) {
                this.RequiredBytes = data.Length;
            }
        }


        #region Abstract methods

        /// <summary>Parse data according to derived. Null and zero length data checked</summary>
        /// <param name="data">The data to parse</param>
        protected abstract void DoParse(byte[] data);


        /// <summary>
        /// Derived to reset their specific data propertis before parse. 
        /// Base sets its own. NOTE: need to set the base RawData with 
        /// CopyToRawData when length is known in the DoParse method
        /// </summary>
        protected abstract void ResetMembers();


        /// <summary>Override to provide type for future cast of specific data fields</summary>
        /// <returns>The type of the derived class</returns>
        protected abstract Type GetDerivedType();

        #endregion

    }
}
