using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VariousUtils {

    public static class EnumHelpers {

        public static List<T> GetEnumList<T>() where T : new() {
            T valueType = new T();
            return typeof(T).GetFields()
                .Select(fieldInfo => (T)fieldInfo.GetValue(valueType))
                .Distinct()
                .ToList();
        }


    }
}
