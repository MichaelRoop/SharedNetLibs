using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertCategoryID : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 1;

        protected override bool DoParse(byte[] data) {
            switch (data[0]) {
                case 0:
                    this.DisplayString = "Simple Alert";
                    return true;
                case 1:
                    this.DisplayString = "Email";
                    return true;
                case 2:
                    this.DisplayString = "News";
                    return true;
                case 3:
                    this.DisplayString = "Incoming call";
                    return true;
                case 4:
                    this.DisplayString = "Missed call";
                    return true;
                case 5:
                    this.DisplayString = "SMS/MMS arrives";
                    return true;
                case 6:
                    this.DisplayString = "Voice mail";
                    return true;
                case 7:
                    this.DisplayString = "Scheduler";
                    return true;
                case 8:
                    this.DisplayString = "High Prioritized";
                    return true;
                case 9:
                    this.DisplayString = "Instant Message";
                    return true;
            }
            return true;
        }

    }
}
