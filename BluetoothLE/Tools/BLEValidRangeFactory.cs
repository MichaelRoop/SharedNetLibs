using BluetoothLE.Net.Enumerations;
using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using System;

namespace BluetoothLE.Net.Tools {
    public class BLEValidRangeFactory {

        public DataTypeDisplay GetRange(BLE_DataType dataType) {
            ErrReport report;
            DataTypeDisplay result = WrapErr.ToErrReport(out report, 9999, 
                () => string.Format("Failure retrieving range for data type:{0}", dataType), 
                () => {
                    switch (dataType) {
                        case BLE_DataType.Bool:
                            return new DataTypeDisplay(BLE_DataType.Bool, "0", "1");
                        case BLE_DataType.UInt_2bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_2bit, "0", "3");
                        case BLE_DataType.UInt_4bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_4bit, "0", "15");
                        case BLE_DataType.UInt_8bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_8bit, Byte.MinValue.ToString(), Byte.MaxValue.ToString());
                        case BLE_DataType.UInt_12bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_12bit, "0", "4095");
                        case BLE_DataType.UInt_16bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_16bit, UInt16.MinValue.ToString(), UInt16.MaxValue.ToString());
                        case BLE_DataType.UInt_24bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_24bit, "0", "16777215");
                        case BLE_DataType.UInt_32bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_32bit, UInt32.MinValue.ToString(), UInt32.MaxValue.ToString());
                        case BLE_DataType.UInt_48bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_48bit, "0", "281474976710655");
                        case BLE_DataType.UInt_64bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_64bit, UInt64.MinValue.ToString(), UInt64.MaxValue.ToString());
                        case BLE_DataType.UInt_128bit:
                            return new DataTypeDisplay(BLE_DataType.UInt_128bit, "0", "340282366920938463463374607431768211455");
                        case BLE_DataType.Int_8bit:
                            return new DataTypeDisplay(BLE_DataType.Int_8bit, SByte.MinValue.ToString(), SByte.MaxValue.ToString());
                        case BLE_DataType.Int_12bit:
                            return new DataTypeDisplay(BLE_DataType.Int_12bit, "-2048", "2047");
                        case BLE_DataType.Int_16bit:
                            return new DataTypeDisplay(BLE_DataType.Int_16bit, Int16.MinValue.ToString(), Int16.MaxValue.ToString());
                        case BLE_DataType.Int_24bit:
                            return new DataTypeDisplay(BLE_DataType.Int_24bit, "-8388608", "8388607");
                        case BLE_DataType.Int_32bit:
                            return new DataTypeDisplay(BLE_DataType.Int_32bit, Int32.MinValue.ToString(), Int32.MaxValue.ToString());
                        case BLE_DataType.Int_48bit:
                            return new DataTypeDisplay(BLE_DataType.Int_48bit, "-140737488355328", "140737488355327");
                        case BLE_DataType.Int_64bit:
                            return new DataTypeDisplay(BLE_DataType.Int_64bit, Int64.MinValue.ToString(), Int64.MaxValue.ToString());
                        case BLE_DataType.Int_128bit:
                            return new DataTypeDisplay(BLE_DataType.Int_128bit, "-170141183460469231731687303715884105728", "170141183460469231731687303715884105727");
                        case BLE_DataType.IEEE_754_32bit_floating_point:
                            return new DataTypeDisplay(BLE_DataType.IEEE_754_32bit_floating_point, Single.MinValue.ToString(), Single.MaxValue.ToString());
                        case BLE_DataType.IEEE_754_64bit_floating_point:
                            return new DataTypeDisplay(BLE_DataType.IEEE_754_64bit_floating_point, Double.MinValue.ToString(), Double.MaxValue.ToString());
                        case BLE_DataType.IEEE_11073_16bit_SFLOAT:
                            // Require some bit shifting. TBD
                            return new DataTypeDisplay(BLE_DataType.IEEE_11073_16bit_SFLOAT, "0", "0");
                        case BLE_DataType.IEEE_11073_32bit_FLOAT:
                            // Require some bit shifting. TBD
                            return new DataTypeDisplay(BLE_DataType.IEEE_11073_32bit_FLOAT, "0", "0");
                        case BLE_DataType.IEEE_20601_format:
                            // this is 2 Uint16 in one Uint32 block need to handle both pieces as UINT16
                            return new DataTypeDisplay(
                                BLE_DataType.IEEE_20601_format,
                                string.Format("{0}|{0}", UInt16.MinValue),
                                string.Format("{0}|{0}", UInt16.MaxValue));
                        case BLE_DataType.UTF8_String:
                            return new DataTypeDisplay(BLE_DataType.UTF8_String, "1", "VAR");
                        case BLE_DataType.UTF16_String:
                            return new DataTypeDisplay(BLE_DataType.UTF16_String, "1", "VAR");
                        case BLE_DataType.OpaqueStructure:
                        case BLE_DataType.Reserved:
                        default:
                            return new DataTypeDisplay(BLE_DataType.Reserved, "0", "0");

                    }
            });
            return (report.Code == 0) ? result : new DataTypeDisplay(BLE_DataType.Reserved, "ERR", "ERR");
        }

    }
}
