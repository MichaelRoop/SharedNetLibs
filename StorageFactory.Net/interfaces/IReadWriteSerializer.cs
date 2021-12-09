namespace StorageFactory.Net.interfaces {

    /// <summary>Interface to serialize a class to and from a stream</summary>
    /// <typeparam name="T">The class to read or write</typeparam>
    public interface IReadWriteSerializer<T> where T : class {

        /// <summary>Deserialize input from stream to a class</summary>
        /// <param name="stream">The input stream with the stored class</param>
        /// <returns>The class from deserialized stream contents</returns>
        T? Deserialize(Stream stream);


        /// <summary>Serialize a class to stream</summary>
        /// <param name="obj">The class to serialize</param>
        /// <param name="stream">Stream to received the serialized class</param>
        /// <returns>true on success, otherwise false</returns>
        bool Serialize(T obj, Stream stream);

    }
}
