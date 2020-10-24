using System;

namespace Common.Net.Properties {

    public class GuidProperyUpdate {
        public string Key { get; set; } = "";
        public Guid Value { get; set; } = Guid.NewGuid();
        public GuidProperyUpdate(string key, Guid value) {
            this.Key = key;
            this.Value = value;
        }
    }

}
