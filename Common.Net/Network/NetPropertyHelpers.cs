using Common.Net.Enumerations;
using Common.Net.Network.Enumerations;
using Common.Net.Network.interfaces;
using LogUtils.Net;

namespace Common.Net.Network {

    public class NetPropertyHelpers {

        private static INetPropertyKeys? KEYS = null;
        private readonly static ClassLog log = new("NetPropertyHelpers");

        public static void SetPropertyKeys(INetPropertyKeys keys) {
            KEYS = keys;
        }


        public static Dictionary<string, NetPropertyDataModel> CreatePropertiesDictionary(IReadOnlyDictionary<string, object> propertyDict) {
            Dictionary<string, NetPropertyDataModel> properties = new();
            if (propertyDict != null) {
                foreach (var p in propertyDict) {
                    NetPropertyDataModel model = new() {
                        Key = p.Key,
                        Target = GetPropertyTarget(p.Key),
                    };
                    SetPropertyValue(p.Value, model);
                    if (!properties.ContainsKey(model.Key)) {
                        properties.Add(model.Key, model);
                    }
                    else {
                        log.Error(9999, "CreatePropertiesDictionary", () => string.Format("Duplicate property key '{0}'", model.Key));
                    }
                }

            }
            return properties;
        }


        private static void SetPropertyValue(object value, NetPropertyDataModel model) {
            if (value == null) {
                model.DataType = PropertyDataType.TypeString;
                model.Value = "";
            }
            else {
                model.Value = value;
                if (value is bool) {
                    model.DataType = PropertyDataType.TypeBool;
                }
                else if (value is string) {
                    model.DataType = PropertyDataType.TypeString;
                }
                else if (value is Guid) {
                    model.DataType = PropertyDataType.TypeGuid;
                }
                else {
                    model.DataType = PropertyDataType.TypeUnknown;
                }
            }
        }


        private static NetPropertyType GetPropertyTarget(string key) {
            if (key == null || key.Length == 0 || KEYS == null){
                return NetPropertyType.UnHandled;
            }
            else if (key == KEYS.IsConnected) {
                return NetPropertyType.IsConnected;
            }
            else if (key == KEYS.IsConnected) {
                return NetPropertyType.IsConnected;
            }
            else if (key == KEYS.IsConnectable) {
                return NetPropertyType.IsConnectable;
            }
            else if (key == KEYS.CanPair) {
                return NetPropertyType.CanPair;
            }
            else if (key == KEYS.IsPaired) {
                return NetPropertyType.IsPaired;
            }
            else if (key == KEYS.ContainerId) {
                return NetPropertyType.ContainerId;
            }
            else if (key == KEYS.IconPath) {
                return NetPropertyType.IconPath;
            }
            else if (key == KEYS.GlyphIconPath) {
                return NetPropertyType.GlyphIconPath;
            }
            else if (key == KEYS.ItemNameDisplay) {
                return NetPropertyType.ItemNameDisplay;
            }
            else {
                return NetPropertyType.UnHandled;
            }
        }




    }
}
