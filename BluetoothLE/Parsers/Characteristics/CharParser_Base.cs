using BluetoothLE.Net.interfaces;
using ChkUtils.Net;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public abstract class CharParser_Base : ICharParser {

        #region Data

        private ClassLog baseLog = new ClassLog("CharParser_Base");

        #endregion

        #region ICharParser Properties and methods

        public abstract int RequiredBytes { get; protected set; }

        public byte[] RawData { get; private set; } = new byte[0];

        public string DisplayString { get; protected set; } = "";

        public string Parse(byte[] data) {
            try {
                // Make sure zero out raw value. 
                this.RawData = new byte[0];
                this.DisplayString = "";
                if (data != null) {
                    if (data.Length > 0) {
                        if (this.DoParse(data)) {
                            return this.DisplayString;
                        }
                    }
                    else {
                        this.baseLog.Error(13605, "Parse", "byte[] is zero length");
                    }
                }
                else {
                    this.baseLog.Error(13606, "Parse", "Raw byte[] is null");
                }
            }
            catch (Exception e) {
                this.baseLog.Exception(13607, "Parse", "Failure on Parse", e);
            }
            return "* N/A *";
        }

        #endregion

        #region Abstract methods

        /// <summary>Parse data according to derived. Null and zero length data checked</summary>
        /// <param name="data">The data to parse</param>
        /// <returns>true on success, otherwise false</returns>
        protected abstract bool DoParse(byte[] data);

        #endregion

        #region Virtual methods

        #endregion

        #region Constructors

        public CharParser_Base() {
            this.RawData = new byte[0];
            this.DisplayString = "";
        }

        #endregion

        #region Protected

        /// <summary>
        /// Creates a new sized Raw buffer array and copies bytes to it. CALL IN DoParse method
        /// </summary>
        /// <param name="data">The data to copy</param>
        /// <param name="length">The length of data to copy</param>
        /// <returns>true on success, otherwise false on exception or if data null or smaller than length</returns>
        protected bool CopyToRawData(byte[] data) {
            try {
                if (data != null) {
                    if (data.Length >= this.RequiredBytes) {
                        this.RawData = new byte[this.RequiredBytes];
                        Array.Copy(data, this.RawData, this.RawData.Length);
                        this.baseLog.Info("CopyToRawData", () => string.Format("Data:{0}", this.RawData.ToHexByteString()));
                        return true;
                    }
                    else {
                        this.baseLog.Error(13615, "CopyToRawData",
                            () => string.Format("Data length:{0} smaller than requested:{1} Data '{2}'",
                            data.Length, this.RequiredBytes, data.ToHexByteString()));
                    }
                }
                else {
                    this.baseLog.Error(13616, "CopyToRawData", "Raw byte[] is null");
                }
            }
            catch (Exception e) {
                this.baseLog.Exception(13617, "CopyToRawData", "Failed on CopyToRaw", e);
            }
            return false;
        }

        #endregion

    }
}
