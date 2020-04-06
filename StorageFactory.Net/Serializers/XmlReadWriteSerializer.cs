﻿using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using StorageFactory.Net.interfaces;
using System.IO;
using System.Runtime.Serialization;

namespace StorageFactory.Net.Serializers {


    /// <summary>Serializer to and from XML</summary>
    /// <typeparam name="T">The type to serialize</typeparam>
    public class XmlReadWriteSerializer<T> : IReadWriteSerializer<T> where T : class {

        DataContractSerializer serializer = new DataContractSerializer(typeof(T));

        /// <summary>Deserialize the XML in stream into a class</summary>
        /// <param name="stream">The stream containing the XML</param>
        /// <returns>A class T</returns>
        public T Deserialize(Stream stream) {
            ErrReport report;
            T result = WrapErr.ToErrReport(out report, 9999, "", () => {
                object tmp = this.serializer.ReadObject(stream);
                return tmp as T;
            });
            return report.Code == 0 ? result : default(T);
        }


        /// <summary>Serialize the object into XML and store in stream</summary>
        /// <param name="obj">The object to serialize</param>
        /// <param name="stream">The stream to contain the XML</param>
        /// <returns>A class T</returns>
        public bool Serialize(T obj, Stream stream) {
            ErrReport report;
            WrapErr.ToErrReport(out report, 9999, "", () => {
                this.serializer.WriteObject(stream, obj);
            });
            return report.Code == 0;
        }

    }
}
