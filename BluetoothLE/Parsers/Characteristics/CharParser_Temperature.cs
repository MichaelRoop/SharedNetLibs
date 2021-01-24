using System.Globalization;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Temperature : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 2;

        protected override void DoParse(byte[] data) {
            // Each unit is 0.01 degree celcius - multiply to get real value with 2 decimal exponent 
            double temp = data.ToInt16(0) * 0.01;
            this.DisplayString = temp.ToString("#######0.00", CultureInfo.CurrentCulture);
        }

    }

}
