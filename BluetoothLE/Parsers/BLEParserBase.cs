using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using ChkUtils.Net;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers {

    public abstract class BLEParserBase : IBLEParser {

        #region Data

        private ClassLog baseLog = new ClassLog("BLEParserBase");
        private byte[] RawData { get; set; } = new byte[0];

        /// <summary>Number of bytes in byte field</summary>
        protected const int BYTE_LEN = 1;
        /// <summary>Number of bytes for uint16 field</summary>
        protected const int UINT16_LEN = 2;
        /// <summary>Number of bytes for uint32 field</summary>
        protected const int UINT32_LEN = 4;
        /// <summary>Number of bytes for time second field</summary>
        protected const int TIMESECOND_LEN = 3; // 3 bytes, 24bit

        #endregion

        #region ICharParser Properties and methods

        public UInt16 AttributeHandle { get; set; } = 0;


        public virtual int RequiredBytes { get; protected set; } = 0;

        public string DisplayString { get; protected set; } = string.Empty;

        public virtual BLE_DataType DataType { get; protected set; } = BLE_DataType.Reserved;

        /// <summary>We ranslate boolean which differs from all other values</summary>
        public bool BoolValue { get; set; } = false;


        public string Translate(Func<string> translator) {
            string initial = this.DisplayString;
            try {
                this.DisplayString = translator.Invoke();
            }
            catch(Exception e) {
                this.baseLog.Exception(13327, "Translate", "", e);
                this.DisplayString = initial;
            }
            return this.DisplayString;
        }


        public string Parse(byte[] data) {
            try {
                this.ResetMembers();
                if (this.CopyToRawData(data)) {
                    this.DoParse(this.RawData);
                }
            }
            catch (Exception e) {
                this.baseLog.Exception(13607, "Parse", "Failure on Parse", e);
                this.DisplayString = "ERR";
            }
            return this.DisplayString;
        }
    

        #endregion

        #region Virtual base class

        /// <summary>Flag to indicate that the byte array length becomes RequiredBytes</summary>
        protected virtual bool IsDataVariableLength { get; set; } = false;


        /// <summary>Parse data according to derived. Null and zero length data checked</summary>
        /// <param name="data">The data to parse</param>
        /// <returns>true on success, otherwise false</returns>
        protected abstract void DoParse(byte[] data);

        /// <summary>Derived to reset specific data properties before parse</summary>
        protected virtual void ResetMembers() {
            this.RawData = new byte[0];
            this.DisplayString = "";
        }

        #endregion

        #region Constructors

        public BLEParserBase() {
            WrapErr.ToErrorReportException(13325, "Failed on construction", () => {
                this.ResetMembers();
            });
        }

        #endregion

        #region Private

        /// <summary>
        /// Creates a new sized Raw buffer array and copies bytes to it. CALL IN DoParse method
        /// </summary>
        /// <param name="data">The data to copy</param>
        /// <param name="length">The length of data to copy</param>
        /// <returns>true on success, otherwise false on exception or if data null or smaller than length</returns>
        private bool CopyToRawData(byte[] data) {
            // TODO - the numbers here are from the char parser
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

                        this.baseLog.Error(13615, "CopyToRawData",
                            () => string.Format("Data length:{0} smaller than requested:{1} Data '{2}'",
                            data.Length, this.RequiredBytes, data.ToHexByteString()));
                    }
                    else {
                        this.baseLog.Error(13618, "CopyToRawData", "byte[] is zero length");
                    }
                }
                else {
                    this.baseLog.Error(13616, "CopyToRawData", "Raw byte[] is null");
                }
            }
            catch (Exception e) {
                this.baseLog.Exception(13617, "CopyToRawData", "Failed on CopyToRaw", e);
                this.DisplayString = "ERR";
            }
            return false;
        }


        private void SetDataLengthIfVariable(byte[] data) {
            if (this.IsDataVariableLength) {
                this.RequiredBytes = data.Length;
            }
        }

        #endregion

    }
}
