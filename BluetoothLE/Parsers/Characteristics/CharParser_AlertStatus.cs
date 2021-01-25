using BluetoothLE.Net.Parsers.Types;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertStatus : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        public bool RingerState { get; set; } = false;
        public bool VibrateState { get; set; } = false;


        protected override void DoParse(byte[] data) {
            byte tmp = data.ToByte(0);
            this.RingerState = tmp.IsBitSet(0);
            this.VibrateState = tmp.IsBitSet(1);
            this.DisplayString = string.Format(
                "Ringer State:{0} Vibrate State:{1}", 
                this.RingerState.ActiveStateStr(), this.VibrateState.ActiveStateStr());
        }


        protected override void ResetMembers() {
            this.RingerState = false;
            this.VibrateState = false;
            base.ResetMembers();
        }


    }
}
