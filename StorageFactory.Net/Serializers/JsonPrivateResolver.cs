using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace StorageFactory.Net.Serializers {


    /// <summary>
    /// Allows you to deserialize from JSON when a property is private setter and
    /// the constructor sets the value
    /// </summary>
    /// <remarks>
    /// https://talkdotnet.wordpress.com/2019/03/15/newtonsoft-json-deserializing-objects-that-have-private-setters/
    /// 
    /// In data model set the property
    /// [JsonProperty]
    /// public string LastName { get; private set; }
    /// 
    /// Using serializer 
    /// var personCopy = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(jsonString, new JsonSerializerSettings() {
    ///     ContractResolver = new PrivateResolver(),
    ///     ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
    /// });
    /// 
    /// or 
    /// JsonSerializer serializer = new JsonSerializer();
    /// this.serializer.ContractResolver = new JsonPrivateResolver();
    /// 
    ///  using (StreamReader r = new StreamReader(stream)) {
    ///     using (JsonTextReader t = new JsonTextReader(r)) {
    ///         return this.serializer.Deserialize<T>(t);
    ///     }
    ///  }
    /// 
    /// </remarks>
    public class JsonPrivateResolver : DefaultContractResolver {

        /// <summary>
        /// Will allow a constructor to set the private property on serialization
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (!property.Writable) {
                PropertyInfo propertyInfo = member as PropertyInfo;
                bool hasPrivateSetter = propertyInfo?.GetSetMethod(true) != null;
                property.Writable = hasPrivateSetter;
            }
            return property;
        }

    }
}
