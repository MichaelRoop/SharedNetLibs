using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics.DataTypes {

    public static class TypeParser_Helpers {

        public static byte GetBleDayByte(this DayOfWeek day) {
            switch (day) {
                case DayOfWeek.Sunday:
                    return 7;
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                default:
                    return 0;
            }
        }


        public static string GetDayStr(this DayOfWeek day) {
            return DateTimeFormatInfo.CurrentInfo.GetDayName(day);
        }


        public static string Get256Fragment(this byte data) {
            // the number is 1/256th of a second
            // range is 0-255. Max would come to 996ms
            // if we devide by 255.2 it comes to 999ms 
            int value = (int)((1000.0 / 255.2) * ((double)data));
            if (value > 9999) {
                value = 9999;
            }
            return value.ToString();
        }



    }
}
