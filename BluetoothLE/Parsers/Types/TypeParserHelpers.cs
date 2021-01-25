using BluetoothLE.Net.Enumerations;
using System;
using System.Globalization;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public static class TypeParserHelpers {

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

        /// <summary>Culture dependent day of week name</summary>
        /// <param name="day">The day enum</param>
        /// <returns>Localized day string</returns>
        public static string GetDayStr(this DayOfWeek day) {
            return DateTimeFormatInfo.CurrentInfo.GetDayName(day);
        }


        public static string GetMonthStr(this MonthOfYear month) {
            return ((int)month).GetMonthStr();
        }


        public static string GetMonthStr(this int month) {
            if (month == 0 || month > 12) {
                return "Unknown Month";
            }
            return DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
        }



        public static int GetSecond256FragmentAsMs(this byte data) {
            // the number is 1/256th of a second
            // range is 0-255. Max would come to 996ms
            // if we devide by 255.2 it comes to 999ms 
            int value = (int)((1000.0 / 255.2) * ((double)data));
            if (value > 9999) {
                value = 9999;
            }
            return value;
        }


        public static string CurrentTimeAdjustReasonStr(this byte bitmap) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Manual Update:").Append(bitmap.IsBitSet(0) ? "Enabled" : "Disabled")
              .Append("External Reference Cime Change:").Append(bitmap.IsBitSet(1) ? "Enabled" : "Disabled")
              .Append("Time zone Change:").Append(bitmap.IsBitSet(2) ? "Enabled" : "Disabled")
              .Append("DST Change:").Append(bitmap.IsBitSet(3) ? "Enabled" : "Disabled");
            return sb.ToString();
        }

        public static string GetYearStr(this ushort year) {
            if (year.IsYearValid()) {
                return year.ToString();
            }
            return "Year Out of range";
        }


        public static bool IsYearValid(this ushort year) {
            // 1528 - 9999
            return year > 1581 && year < 10000;
        }


        public static bool IsMonthValid(this byte value) { 
            return value > 0 && value < 13;
        }

        public static bool IsDayValid(this byte value) {
            return value > 0 && value < 32;
        }

        public static bool IsHourValid(this byte value) {
            return value >= 0 && value < 24;
        }

        public static bool IsMinuteValid(this byte value) {
            return value >= 0 && value < 60;
        }

        public static bool IsSecondsValid(this byte value) {
            return value >= 0 && value < 60;
        }


        public static string ActiveStateStr(this bool isActive) {
            return isActive ? "active" : "not active";
        }


    }
}
