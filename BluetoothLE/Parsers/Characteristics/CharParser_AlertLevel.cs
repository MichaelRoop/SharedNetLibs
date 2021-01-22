using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertLevel : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 1;

        protected override void DoParse(byte[] data) {
            switch (data[0]) {
                case 0:
                    this.DisplayString = "No Alert";
                    break;
                case 1:
                    this.DisplayString = "Mild Alert";
                    break;
                case 2:
                    this.DisplayString = "High Alert";
                    break;
                default:
                    this.DisplayString = "ERR";
                    break;
            }
        }

    }

}
