﻿using BluetoothLE.Net.interfaces;
using ChkUtils.Net;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public abstract class CharParser_Base : ICharParser {

        #region Data

        private ClassLog baseLog = new ClassLog("CharParser_Base");
        protected string strValue = "";

        #endregion

        #region ICharParser Properties and methods

        public byte[] RawData { get; private set; } = new byte[0];

        public Type ImplementationType { get; private set; } = typeof(CharParser_Base);

        public string DisplayString() {
            try {
                return this.GetDisplayString();
            }
            catch (Exception e) {
                this.baseLog.Exception(13601, "DisplayString", "Failed On DoDisplayString", e);
                return "* FAILED *";
            }
        }


        public string Parse(byte[] data) {
            try {
                // Make sure zero out raw value. 
                this.RawData = new byte[0];
                // Do not need to reset type. Done on construction
                this.ResetMembers();
                if (data != null) {
                    if (data.Length > 0) {
                        if (this.DoParse(data)) {
                            return this.DisplayString();
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

        /// <summary>Provides a string of the derived class parsed data for display</summary>
        /// <returns>A display string</returns>
        protected virtual string GetDisplayString() {
            return this.strValue;
        }


        /// <summary>
        /// Derived to reset their specific data propertis before parse. 
        /// Base sets its own. NOTE: need to set the base RawData with 
        /// CopyToRawData when length is known in the DoParse method
        /// </summary>
        protected virtual void ResetMembers() {
            this.strValue = "";
        }


        /// <summary>Override to provide type for future cast of specific data fields</summary>
        /// <returns>The type of the derived class</returns>
        protected virtual Type GetDerivedType() {
            return this.GetType();
        }


        /// <summary>Override if a nested parser requires x number of bytes</summary>
        /// <returns>The required number of bytes or 0 if not overriden</returns>
        public virtual int RequiredBytes() {
            return 0;
        }


        #endregion

        #region Constructors

        public CharParser_Base() {
            WrapErr.ToErrorReportException(13610, "Failed on construction", () => {
                this.ImplementationType = this.GetDerivedType();
                this.RawData = new byte[0];
                this.ResetMembers();
            });
        }


        public CharParser_Base(byte[] data) {
            WrapErr.ToErrorReportException(13611, "Failed on construction", () => {
                this.ImplementationType = this.GetDerivedType();
                this.Parse(data);
            });
        }

        #endregion

        #region Protected

        /// <summary>
        /// Creates a new sized Raw buffer array and copies bytes to it. CALL IN DoParse method
        /// </summary>
        /// <param name="data">The data to copy</param>
        /// <param name="length">The length of data to copy</param>
        /// <returns>true on success, otherwise false on exception or if data null or smaller than length</returns>
        protected bool CopyToRawData(byte[] data, int length) {
            try {
                if (data != null) {
                    if (data.Length >= length) {
                        this.RawData = new byte[length];
                        Array.Copy(data, this.RawData, this.RawData.Length);
                        this.baseLog.Info("CopyToRawData", () => string.Format("Data:{0}", this.RawData.ToHexByteString()));
                        return true;
                    }
                    else {
                        this.baseLog.Error(13615, "CopyToRawData",
                            () => string.Format("Data length:{0} smaller than requested:{1} Data '{2}'",
                            data.Length, length, data.ToHexByteString()));
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
