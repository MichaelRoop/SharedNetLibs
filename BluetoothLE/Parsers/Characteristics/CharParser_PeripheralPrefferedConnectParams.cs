﻿using LogUtils.Net;
using System;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_PeripheralPrefferedConnectParams : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_PeripheralPrefferedConnectParams");

        public override int RequiredBytes { get; protected set; } = 8;


        protected override bool DoParse(byte[] data) {
            //Peripheral Preferred Connection Parameters  Value:0x14,0x00,0x24,0x00,0x04,0x00,0xC8,0x00 - 8 bytes
            // 8 bytes in 4 uint16 fields
            // 1. Minimum Connect interval 6-3200
            // 2. Maximum Connect interval 6-3200
            // 3. Slave latency 0-1000
            // 4. Connection Supervisor Timeout Multiplier 10-3200
            if (this.CopyToRawData(data)) {
                StringBuilder sb = new StringBuilder();
                sb
                    .Append("Min Connect Interval:")
                    .Append(BitConverter.ToInt16(this.RawData, 0)).Append(", ")
                    .Append("Max Connect Interval:")
                    .Append(BitConverter.ToInt16(this.RawData, 2)).Append(", ")
                    .Append("Slave Latency:")
                    .Append(BitConverter.ToInt16(this.RawData, 4)).Append(", ")
                    .Append("Connect Supervisor Timout multiplier:")
                    .Append(BitConverter.ToInt16(this.RawData, 6));

                this.DisplayString = sb.ToString();
                this.log.Info("DoParse", () => 
                    string.Format("{0} from bytes {1}", 
                        this.DisplayString, this.RawData.ToFormatedByteString()));
                return true;
            }
            return false;
        }

    }
}
