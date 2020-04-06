﻿using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using StorageFactory.Net.interfaces;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace StorageFactory.Net.Serializers {

    /// <summary>Read and write a class to and from Stream in encrypted format</summary>
    /// <typeparam name="T">The type of class to stream</typeparam>
    public class EncryptingDataSerializer<T> : IReadWriteSerializer<T> where T : class {

        #region Data

        private ICryptoTransform encryptKey = null;
        private ICryptoTransform decryptKey = null;

        // To serialize the class before saving and deserializing
        private IReadWriteSerializer<T> primarySerializer = new JsonReadWriteSerializer<T>();

        #endregion

        #region Constructors

        /// <summary>Default constructor which sets up the encryption</summary>
        public EncryptingDataSerializer() {
            DESCryptoServiceProvider service = new DESCryptoServiceProvider();
            byte[] key = Encoding.ASCII.GetBytes("64bitPas");
            byte[] IV = Encoding.ASCII.GetBytes("xytT26**D0k87jIJ5*s8S");
            this.encryptKey = service.CreateEncryptor(key, IV);
            this.decryptKey = service.CreateDecryptor(key, IV);
        }


        /// <summary>Constructor</summary>
        /// <param name="primarySerializer">
        /// Handles converting the decrypted data to the type and vice versa 
        /// </param>
        public EncryptingDataSerializer(IReadWriteSerializer<T> primarySerializer) : this() {
            this.primarySerializer = primarySerializer;
        }

        #endregion


        /// <summary>Decrypt from stream then deserialize to T type</summary>
        /// <param name="stream">The input stream with encrypted value</param>
        /// <returns>Decrypted and deserialized value to T type</returns>
        public T Deserialize(Stream stream) {
            ErrReport report;
            T obj = WrapErr.ToErrReport(out report, 9999,
                () => string.Format("Failed read type {0}", typeof(T).Name),
                () => {
                    using (CryptoStream cs = new CryptoStream(stream, this.decryptKey, CryptoStreamMode.Read)) {
                            return this.primarySerializer.Deserialize(cs);
                    }
                });
            return report.Code == 0 ? obj : null;
        }


        /// <summary>
        /// Serialize a T type and feed it to the encrypting stream which feeds it to the output stream
        /// </summary>
        /// <param name="obj">The T class type to serialize and encrypt</param>
        /// <param name="stream">Stream to received the class serialized as JSON</param>
        /// <returns>true on success, otherwise false</returns>
        public bool Serialize(T obj, Stream stream) {
            ErrReport report;
            WrapErr.ToErrReport(out report, 9999,
                () => string.Format("Failed write type {0}", typeof(T).Name),
                () => {
                    using (CryptoStream cs = new CryptoStream(stream, this.encryptKey, CryptoStreamMode.Write)) {
                        return this.primarySerializer.Serialize(obj, cs);
                    }
                });
            return report.Code == 0;
        }
    }
}






