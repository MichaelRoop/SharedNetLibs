using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertCategoryID : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 1;

        protected override void DoParse(byte[] data) {
            switch (data[0]) {
                case 0:
                    this.DisplayString = "Simple Alert";
                    break;
                case 1:
                    this.DisplayString = "Email";
                    break;
                case 2:
                    this.DisplayString = "News";
                    break;
                case 3:
                    this.DisplayString = "Incoming call";
                    break;
                case 4:
                    this.DisplayString = "Missed call";
                    break;
                case 5:
                    this.DisplayString = "SMS/MMS arrives";
                    break;
                case 6:
                    this.DisplayString = "Voice mail";
                    break;
                case 7:
                    this.DisplayString = "Scheduler";
                    break;
                case 8:
                    this.DisplayString = "High Prioritized";
                    break;
                case 9:
                    this.DisplayString = "Instant Message";
                    break;
                default:
                    this.DisplayString = "Unknown";
                    break;
            }
        }

    }
}
