namespace VariousUtils.Net {

    /// <summary>Some helpers for enum usage</summary>
    public static class EnumHelpers {

        public static T FirstOrDefault<T>(this byte value, T defaultValue) where T : Enum {
            return GetEnumList<T>().FirstOrDefault(e => (byte)(object)e == value, defaultValue);
        }


        public static T FirstOrDefault<T>(this int value, T defaultValue) where T : Enum {
            foreach (T item in GetEnumList<T>()) {
                if (((int)(object)item) == value) {
                    return item;
                }
            }
            return defaultValue;
        }


        public static T FirstOrDefault<T>(this uint value, T defaultValue) where T : Enum {
            return GetEnumList<T>().FirstOrDefault(e => (uint)(object)e == value, defaultValue);
        }


        public static T FirstOrDefault<T>(this ushort value, T defaultValue) where T : Enum {
            foreach (T item in GetEnumList<T>()) {
                if (((ushort)(object)item) == value) {
                    return item;
                }
            }
            return defaultValue;
        }


        /// <summary>Get list of enums to use in foreach. You must use the Enum type rather than var</summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns>A list of enums of that type</returns>
        public static List<T> GetEnumList<T>() where T : Enum {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }


        // Flag methods heavily modified from: https://stackoverflow.com/questions/3261451/using-a-bitmask-in-c-sharp

        /// <summary>Returns a copy of the flag enum with the extra flag added</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="originalFlagsEnum">The original enum with any number of flags set</param>
        /// <param name="flagToSet">The flag to add</param>
        /// <returns>The original flag enum with added flag</returns>
        public static T AddFlag<T>(this T originalFlagsEnum, T flagToSet) where T : Enum {
            return (originalFlagsEnum.ToInt() | flagToSet.ToInt()).ToEnum<T>();
        }


        /// <summary>Returns a copy of the flag enum with the extra flag removed</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="originalFlagsEnum">The original enum with any number of flags set</param>
        /// <param name="flagToUnSet">The flag to remove</param>
        /// <returns>The original flag enum with flag removed</returns>
        public static T RemoveFlag<T>(this T originalFlagsEnum, T flagToUnSet) where T : Enum {
            return (originalFlagsEnum.ToInt() & (~flagToUnSet.ToInt())).ToEnum<T>();
        }


        /// <summary>Cannot cast a generic T Enum directly so pass by object</summary>
        /// <typeparam name="T">The enum type to cast</typeparam>
        /// <param name="enumToCast"></param>
        /// <returns></returns>
        public static byte ToByte<T>(this T enumToCast) where T : Enum {
            return (byte)(object)enumToCast;
        }


        /// <summary>Cannot cast a generic T Enum directly so pass by object</summary>
        /// <typeparam name="T">The enum type to cast</typeparam>
        /// <param name="enumToCast"></param>
        /// <returns></returns>
        public static int ToInt<T>(this T enumToCast) where T : Enum {
            return (int)(object)enumToCast;
        }


        /// <summary>Cannot cast a generic T Enum directly so pass by object</summary>
        /// <typeparam name="T">The enum type to cast</typeparam>
        /// <param name="enumToCast"></param>
        /// <returns></returns>
        public static uint ToUInt<T>(this T enumToCast) where T : Enum {
            return (uint)(object)enumToCast;
        }


        /// <summary>Pass by object to cast int to enum</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="intToCast">The int to cast to the enum</param>
        /// <returns>The enum cast from int</returns>
        public static T ToEnum<T>(this byte byteToCast) where T : Enum {
            return (T)(object)byteToCast;
        }


        /// <summary>Pass by object to cast int to enum</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="intToCast">The int to cast to the enum</param>
        /// <returns>The enum cast from int</returns>
        //[Obsolete] // TODO - maybe make private since used here when I know the enum is valid
        public static T ToEnum<T>(this int intToCast) where T : Enum {
            return (T)(object)intToCast;
        }


        /// <summary>Pass by object to cast int to enum</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="intToCast">The int to cast to the enum</param>
        /// <returns>The enum cast from int</returns>
        public static T ToEnum<T>(this uint uintToCast) where T : Enum {
            return (T)(object)uintToCast;
        }


        /// <summary>Pass by object to cast int to enum or return default value if non existing</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="intToCast">The int to cast to the enum</param>
        /// <param name="defaultValue">Default if number invalid</param>
        /// <returns>The enum cast from int</returns>
        public static T ToEnum<T>(this byte byteToCast, T defaultValue) where T : Enum {
            return byteToCast.FirstOrDefault<T>(defaultValue);
        }


        /// <summary>Pass by object to cast int to enum or return default value if non existing</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="intToCast">The int to cast to the enum</param>
        /// <param name="defaultValue">Default if number invalid</param>
        /// <returns>The enum cast from int</returns>
        public static T ToEnum<T>(this int intToCast, T defaultValue) where T : Enum {
            return intToCast.FirstOrDefault<T>(defaultValue);
        }


        /// <summary>Pass by object to cast uint to enum or return default value if non existing</summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="uintToCast">The uint to cast to the enum</param>
        /// <param name="defaultValue">Default if number invalid</param>
        /// <returns>The enum cast from int</returns>
        public static T ToEnum<T>(this uint uintToCast, T defaultValue) where T : Enum {
            return uintToCast.FirstOrDefault<T>(defaultValue);
        }



    }
}
