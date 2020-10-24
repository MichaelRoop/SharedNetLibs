namespace Common.Net.Properties {

    public class BoolProperyUpdate {
        public string Key { get; set; } = "";
        public bool Value { get; set; } = false;
        public BoolProperyUpdate(string key, bool value) {
            this.Key = key;
            this.Value = value;
        }
    }

}
