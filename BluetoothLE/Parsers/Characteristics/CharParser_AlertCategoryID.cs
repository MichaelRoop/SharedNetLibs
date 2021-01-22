using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertCategoryID : CharParser_Base {
        protected override bool DoParse(byte[] data) {
            this.strValue = "";
            if (this.CopyToRawData(data, 1)) {
                switch (this.RawData[0]) {
                    case 0:
                        this.strValue = "Simple Alert";
                        return true;
                    case 1:
                        this.strValue = "Email";
                        return true;
                    case 2:
                        this.strValue = "News";
                        return true;
                    case 3:
                        this.strValue = "Incoming call";
                        return true;
                    case 4:
                        this.strValue = "Missed call";
                        return true;
                    case 5:
                        this.strValue = "SMS/MMS arrives";
                        return true;
                    case 6:
                        this.strValue = "Voice mail";
                        return true;
                    case 7:
                        this.strValue = "Scheduler";
                        return true;
                    case 8:
                        this.strValue = "High Prioritized";
                        return true;
                    case 9:
                        this.strValue = "Instant Message";
                        return true;
                }
            }
            return false;
        }

        protected override Type GetDerivedType() {
            return typeof(CharParser_AlertCategoryID);
        }
    }
}
