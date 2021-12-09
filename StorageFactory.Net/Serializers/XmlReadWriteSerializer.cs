using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using StorageFactory.Net.interfaces;
using System.Runtime.Serialization;
using System.Xml;

namespace StorageFactory.Net.Serializers {


    /// <summary>Serializer to and from XML</summary>
    /// <typeparam name="T">The type to serialize</typeparam>
    public class XmlReadWriteSerializer<T> : IReadWriteSerializer<T> where T : class {

        private readonly DataContractSerializer serializer = new (typeof(T));
        private readonly bool indented = false;


        public XmlReadWriteSerializer(bool indented = false) {
            this.indented = indented;
        }


        /// <summary>Deserialize the XML in stream into a class</summary>
        /// <param name="stream">The stream containing the XML</param>
        /// <returns>A class T</returns>
        public T? Deserialize(Stream stream) {
            T? result = WrapErr.ToErrReport(out ErrReport report, 9999, "", () => {
                return this.serializer.ReadObject(stream) as T;
            });
            return report.Code == 0 ? result : default;
        }


        /// <summary>Serialize the object into XML and store in stream</summary>
        /// <param name="obj">The object to serialize</param>
        /// <param name="stream">The stream to contain the XML</param>
        /// <returns>A class T</returns>
        public bool Serialize(T obj, Stream stream) {
            WrapErr.ToErrReport(out ErrReport report, 9999, "", () => {
                if (this.indented) {
                    using StreamWriter streamWriter = new (stream);
                    using XmlTextWriter txtWriter = new (streamWriter) { Formatting = Formatting.Indented };
                    this.serializer.WriteObject(txtWriter, obj);
                }
                else {
                    this.serializer.WriteObject(stream, obj);
                }
            });
            return report.Code == 0;
        }

    }
}
