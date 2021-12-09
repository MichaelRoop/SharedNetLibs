
namespace Common.Net.Enumerations {

    public enum PropertyDataType {
        TypeUnknown,
        TypeString,
        TypeBool,
        TypeGuid,
        TypeInt,
        TypeDouble,

    }


    public static class PropertyDataTypeExtensions {

        /// <summary>Create a displayble type identifier from the PropertyDataType</summary>
        /// <param name="dataType">The enum to transform</param>
        /// <returns>A freindly string</returns>
        public static string ToFriendlyString(this PropertyDataType dataType) {
            return dataType switch {
                PropertyDataType.TypeUnknown => "Unknown",
                PropertyDataType.TypeString => "String",
                PropertyDataType.TypeBool => "Bool",
                PropertyDataType.TypeGuid => "Guid",
                PropertyDataType.TypeInt => "Int",
                PropertyDataType.TypeDouble => "Double",
                _ => dataType.ToString(),
            };
        }

    }



}
