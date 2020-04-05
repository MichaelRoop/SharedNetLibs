using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using Newtonsoft.Json;
using StorageFactory.Net.interfaces;
using System.IO;

namespace StorageFactory.Net.Serializers {


    /// <summary>Read and write a class to and from Stream in JSON format</summary>
    /// <typeparam name="T">The type of class to stream</typeparam>
    public class JsonReadWriteSerializer<T> : IReadWriteSerializer<T> where T : class {

        JsonSerializer serializer = new JsonSerializer();

        /// <summary>Deserialize a class from JSON in stream to a class</summary>
        /// <param name="stream">The input stream with the stored JSON</param>
        /// <returns>The class deserialized from the JSON</returns>
        public T Deserialize(Stream stream) {
            ErrReport err;
            T obj = WrapErr.ToErrReport(out err, 9999,
                () => string.Format("Failed read type {0}", typeof(T).Name),
                () => {
                    using (StreamReader r = new StreamReader(stream)) {
                        using (JsonTextReader t = new JsonTextReader(r)) {
                            return this.serializer.Deserialize<T>(t);
                        }
                    }
                });
            return err.Code == 0 ? obj : null;
        }


        /// <summary>Serialize a class to JSON and write it to stream</summary>
        /// <param name="obj">The class to serialize</param>
        /// <param name="stream">Stream to received the class serialized as JSON</param>
        /// <returns>true on success, otherwise false</returns>
        public bool Serialize(T obj, Stream stream) {
            ErrReport err;
            WrapErr.ToErrReport(out err, 9999,
                () => string.Format("Failed write type {0}", typeof(T).Name),
                () => {
                    using (StreamWriter w = new StreamWriter(stream)) {
                        using (JsonTextWriter t = new JsonTextWriter(w)) {
                            this.serializer.Serialize(t, obj);
                        }
                    }
                });
            return err.Code == 0;
        }
    }
}
