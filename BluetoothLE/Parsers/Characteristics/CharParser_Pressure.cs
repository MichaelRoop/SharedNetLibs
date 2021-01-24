using System.Globalization;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Pressure : CharParser_Base {

        // uint32
        public override int RequiredBytes { get; protected set; } = 4;

        // Note that Arduinos uint are only 16bits. They must be set to unsigned long

        protected override void DoParse(byte[] data) {
            // Each unit is 0.1 pascals - multiply to get real value with 1 decimal exponent 
            double temp = data.ToUint32(0) * 0.1;
            this.DisplayString = temp.ToString("#######0.0", CultureInfo.CurrentCulture);
        }

    }

}
