
namespace StorageFactory.Net.Serializers {

    /// <summary>Implementation of the Json read writer that sets new line and indents</summary>
    /// <typeparam name="T">The type that is managed</typeparam>
    public class JsonReadWriteSerializerIndented<T> : JsonReadWriteSerializer<T> where T : class {

        /// <summary>Set the output as indented in the base class</summary>
        public JsonReadWriteSerializerIndented() 
            : base(true) {
        }

    }
}
