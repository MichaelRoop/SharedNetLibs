
namespace StorageFactory.Net.Serializers {

    /// <summary>Derived XML serializer class to set indented to true on default constructor</summary>
    /// <typeparam name="T"></typeparam>
    public class XmlReadWriteSerializerIndented<T> : XmlReadWriteSerializer<T> where T: class {

        /// <summary>Default constructor sets indented mode to true</summary>
        public XmlReadWriteSerializerIndented() : base(true) {
        }

    }
}
