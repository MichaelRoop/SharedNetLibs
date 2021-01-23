using System.Globalization;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Humidity : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 2;


        protected override void DoParse(byte[] data) {
            // Each unit is 0.01 percentate - multiply to get real value with 2 decimal exponent 
            double temp = data.ToUint16(0) * 0.01;
            // Moved '%' out of the 'ToString' because it killed format
            this.DisplayString = string.Format("{0}%",
                temp.ToString("#######0.00", CultureInfo.CurrentCulture));
        }
    }

}
