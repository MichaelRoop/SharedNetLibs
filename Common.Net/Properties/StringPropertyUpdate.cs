
namespace Common.Net.Properties {

    public class StringProperyUpdate {
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
        public StringProperyUpdate(string key, string value) {
            this.Key = key;
            this.Value = value;
        }
    }

}
