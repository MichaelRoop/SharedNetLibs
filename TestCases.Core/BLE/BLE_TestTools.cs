using BluetoothLE.Net.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace TestCases.Core.BLE {
    public class BLE_TestTools {

        #region GetBlock

        public byte[] GetBlock() {
            return this.GetBlock(DataFormatEnum.UInt_32bit, UnitsOfMeasurement.Unitless);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum) {
            return this.GetBlock(formatEnum, UnitsOfMeasurement.Unitless);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units) {
            return this.GetBlock(formatEnum, units, 0);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent) {
            return this.GetBlock(formatEnum, units, exponent, 1, 0x221A);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent, byte nameSpace) {
            return this.GetBlock(formatEnum, units, exponent, nameSpace, 0x221A);
        }

        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent, byte nameSpace, ushort description) {
            byte[] data = new byte[7];
            int pos = 0;
            formatEnum.ToByte().WriteToBuffer(data, ref pos);   // 0
            exponent.WriteToBuffer(data, ref pos);              // 1
            units.ToUint16().WriteToBuffer(data, ref pos);      // 2
            nameSpace.WriteToBuffer(data, ref pos);// namespace    4
            description.WriteToBuffer(data, ref pos);           // 5
            return data;
        }

        #endregion

        public void SetExponent(byte[] data, sbyte exp) {
            exp.WriteToBuffer(data, 1);
        }

        public void SetUnits(byte[] data, UnitsOfMeasurement units) {
            units.ToUint16().WriteToBuffer(data, 2);
        }






    }
}
