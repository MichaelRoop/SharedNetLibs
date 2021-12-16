using BluetoothLE.Net.Enumerations;
using VariousUtils.Net;

namespace TestCases.Core.BLE {
    public class BLE_TestTools {

        #region GetBlock

        public static byte[] GetBlock() {
            return GetBlock(DataFormatEnum.UInt_32bit, UnitsOfMeasurement.Unitless);
        }


        public static byte[] GetBlock(DataFormatEnum formatEnum) {
            return GetBlock(formatEnum, UnitsOfMeasurement.Unitless);
        }


        public static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units) {
            return GetBlock(formatEnum, units, 0);
        }


        public static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent) {
            return GetBlock(formatEnum, units, exponent, 1, 0x221A);
        }


        public static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent, byte nameSpace) {
            return GetBlock(formatEnum, units, exponent, nameSpace, 0x221A);
        }

        public static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent, byte nameSpace, ushort description) {
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

        public static void SetExponent(byte[] data, sbyte exp) {
            exp.WriteToBuffer(data, 1);
        }

        public static void SetUnits(byte[] data, UnitsOfMeasurement units) {
            units.ToUint16().WriteToBuffer(data, 2);
        }






    }
}
