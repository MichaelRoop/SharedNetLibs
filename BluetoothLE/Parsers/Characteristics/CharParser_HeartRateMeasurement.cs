using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Heart rate mesurement data parser</summary>
    public class CharParser_HeartRateMeasurement : CharParser_Base {

        // TODO - this will be variable. set on each parse
        public override int RequiredBytes { get; protected set; } = 5;

        // TODO - implement parser
        protected override bool DoParse(byte[] data) {
            #region documentation
            // https://github.com/oesmith/gatt-xml/blob/master/org.bluetooth.characteristic.heart_rate_measurement.xml
            // https://docs.particle.io/tutorials/device-os/bluetooth-le/
            // Flags bit fields (uint8_t). Bit(s):
            //   bit 0 : Format, beats per minute: 
            //      0=8 bits - requires C1
            //      1=16 bits - requires C2
            //   bits 1-2 : Sensor contatct status: 
            //      0=not supported
            //      1=not supported 
            //      2=supported but contact not detected
            //      3=supported and contact detected
            //  bit 3 : Energy expended
            //      0=not present
            //      1=present. Units: kilo Joules - requires C3
            //  bit 4 : RR interval
            //      0=not present
            //      1=one or more present.requires C4
            //  bits 5-7 reserved
            // Heart Rate Measurement Value (uint_16)
            //   format found in bit 0 of Flags
            //   Unit: org.bluetooth.unit.period.beats_per_minute

            // byte 0 Flags
            // uint8_t OR uint16_t - (See Flags Format bit 0)
            // uint16_t - Energy Expended (Optional - see Flags bit 3)
            // variable length RR-Interval (see XML)


            #endregion

            throw new NotImplementedException();
        }

    }
}
