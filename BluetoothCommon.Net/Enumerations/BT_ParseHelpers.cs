using System.Text.RegularExpressions;

namespace BluetoothCommon.Net.Enumerations {

    public static class BT_ParseHelpers {

        public static BT_ServiceType GetServiceType(string  bluetoothServiceName) {
            // Find the id betwee the {}
            // https://stackoverflow.com/questions/378415/how-do-i-extract-text-that-lies-between-parentheses-round-brackets
            //\{([^}]*)\}
            string uid = Regex.Match(bluetoothServiceName, @"\{([^}]*)\}").Groups[1].Value;
            return GetServiceType(new Guid(uid));
        }


        public static BT_ServiceType GetServiceType(Guid serviceUuid) {
            if (IsSigDefinedUuid(serviceUuid)) {
                if (Enum.TryParse(serviceUuid.ToShortId().ToString(), out BT_ServiceType serviceType)) {
                    return serviceType;
                }
            }
            return BT_ServiceType.NotHandled;
        }


        public static BT_ServiceType GetServiceType(uint id) {
            if (Enum.TryParse(id.ToString(), out BT_ServiceType service)) {
                return service;
            }
            return BT_ServiceType.NotHandled;
        }

        // TODO - move to common area. Used by BLE also

        public static bool IsSigDefinedUuid(Guid uuid) {
            var bluetoothBaseUuid = new Guid("00000000-0000-1000-8000-00805F9B34FB");

            var bytes = uuid.ToByteArray();
            // Zero out the first and second bytes
            // Note how each byte gets flipped in a section - 1234 becomes 34 12
            // Example Guid: 35918bc9-1234-40ea-9779-889d79b753f0
            //                   ^^^^
            // bytes output = C9 8B 91 35 34 12 EA 40 97 79 88 9D 79 B7 53 F0
            //                ^^ ^^
            bytes[0] = 0;
            bytes[1] = 0;
            var baseUuid = new Guid(bytes);
            return baseUuid == bluetoothBaseUuid;
        }


        // TODO - move to common area. Used by BLE also
        /// <summary>
        /// Convert from standard 128bit UUID to assigned 32bit UUIDs. Makes it easy to compare services
        /// that devices expose to the standard list.
        /// </summary>
        /// <param name="uuid">UUID to convert to 32 bit</param>
        /// <returns>The unsigned short ID</returns>
        public static ushort ToShortId(this Guid uuid) {
            // Get the short Uuid
            byte[] bytes = uuid.ToByteArray();
            ushort shortUuid = (ushort)(bytes[0] | (bytes[1] << 8));
            return shortUuid;
        }



    }
}
