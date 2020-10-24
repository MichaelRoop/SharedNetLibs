
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
            switch (dataType) {
                case PropertyDataType.TypeUnknown:
                    return "Unknown";
                case PropertyDataType.TypeString:
                    return "String";
                case PropertyDataType.TypeBool:
                    return "Bool";
                case PropertyDataType.TypeGuid:
                    return "Guid";
                case PropertyDataType.TypeInt:
                    return "Int";
                case PropertyDataType.TypeDouble:
                    return "Double";
                default:
                    return dataType.ToString();
            }
        }

    }



}
