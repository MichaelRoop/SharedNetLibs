using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Enumerations {


    public enum BLE_AppearanceCategory : uint {
        Unknown = 0,
        Phone = 64,
        Computer = 128,
        Watch = 192,
        Clock = 256,
        Display = 320,
        Remote_Control = 384,
        Eye_Glasses = 448,
        Tag = 512,
        Key_Ring = 576,
        Media_Player = 640,
        Barcode_Scanner = 704,
        Thermometer = 768,
        Heart_Rate = 832,
        Blood_Pressure = 896,
        Human_Interface_Device = 960,
        Glucose_Meter = 1024,
        Run_Walk_Sensor = 1088,
        Cycling = 1152,
        Control_Device = 1216,
        Network_Device = 1280,
        Sensor = 1344,
        Light_Fixture = 1408,
        Fan = 1472,
        HVAC = 1536,
        Air_Conditioning = 1600,
        Humidifier = 1664,
        Heating = 1728,
        Access_Control = 1792,
        Motorized_Device = 1856,
        Power_Device = 1920,
        Light_Source = 1984,
        Oximeter = 3136,
        Weight_Scale = 3200,
        Outdoor_Sports_Activity= 5184,
    }

    public enum BLE_AppearanceWatch : uint {
        Generic = 0,
        Sports_Watch = 1,
    }

    public enum BLE_AppearanceThermometer : uint {
        Generic = 0,
        Ear = 1,
    }

    public enum BLE_AppearanceHeartRate : uint {
        Generic = 0,
        Belt = 1,
    }

    public enum BLE_AppearanceBloodPressure : uint {
        Generic = 0,
        Arm = 1,
        Wrist = 2,
    }

    public enum BLE_AppearanceHID : uint {
        Generic = 0,
        Keyboard = 1,
        Mouse = 2,
        Joystick = 3,
        Gamepad = 4,
        Digitizer = 5,
        Card_Reader = 6,
        Digital_Pen = 7,
        Barcode_Scanner = 8,
    }

    public enum BLE_AppearanceRunWalkSensor : uint {
        Generic = 0,
        In_Shoe = 1,
        On_Shoe = 2,
        On_Hip = 3,
    }

    public enum BLE_AppearanceCycling : uint {
        Generic = 0,
        Computer = 1,
        Speed_Sensor = 2,
        Cadence_Sensor = 3,
        Power_Sensor = 4,
        Speed_and_Cadence_Sensor = 5,
    }

    public enum BLE_AppearanceControlDevice : uint {
        Generic = 0,
        Switchl = 1,
        Multi_Switch = 2,
        Button = 3,
        Slider = 4,
        Rotary = 5,
        Touch_Panel = 6,
    }

    public enum BLE_AppearanceSensor : uint {
        Generic = 0,
        Motion = 1,
        Air_Quality = 2,
        Temperature = 3,
        Humidity = 4,
        Leak = 5,
        Smoke = 6,
        Occupancy = 7,
        Contact = 8,
        Carbon_Monoxide = 9,
        Carbon_Dioxide = 10,
        Ambient_Light = 11,
        Energy = 12,
        Color_Light = 13,
        Rain = 14,
        Fire = 15,
        Wind = 16,
        Proximity = 17,
        Multi_Sensor = 18,
    }

    public enum BLE_AppearanceLightFixture : uint {
        Generic = 0,
        Wall_Light = 1,
        Ceiling = 2,
        Floor = 3,
        Cabinet = 4,
        Desk = 5,
        Troffer = 6,
        Pendant = 7,
        In_Ground = 8,
        Flood = 9,
        Underwater = 10,
        Bollard = 11,
        Pathway = 12,
        Garden = 13,
        Pole_Top = 14,
        Spotlight = 15,
        Linear = 16,
        Street_Light = 17,
        Shelves = 18,
        High_Bay_Low_Bay = 19,
        Emergency_Exit = 20,
    }

    public enum BLE_AppearanceFan : uint {
        Generic = 0,
        Ceiling=1,
        Axial = 2,
        Exhaust = 3,
        Pedestal = 4,
        Desk = 5,
        Wall = 6,
    }

    public enum BLE_AppearanceHVAC : uint {
        Generic = 0,
        Thermostat = 1,
    }

    public enum BLE_AppearanceHeating : uint {
        Generic = 0,
        Radiator = 1,
        Boiler = 2,
        Heat_Pump = 3,
        Infrared = 4,
        Radiant_Panel = 5,
        Fan = 6,
        Air_Curtain = 7,
    }

    public enum BLE_AppearanceAccessControl : uint {
        Generic = 0,
        Access_Door = 1,
        Garage_Door = 2,
        Emergency_Exit_Door = 3,
        Access_Lock = 4,
        Elevator = 5,
        Window = 6,
        Entrance_Gate = 7,
    }

    public enum BLE_AppearanceMotorizedDevice : uint {
        Generic = 0,
        Motorized_Gate = 1,
        Awning = 2,
        Blinds_or_Shades = 3,
        Curtains = 4,
        Screen = 5,
    }

    public enum BLE_AppearancePowerDevice : uint {
        Generic = 0,
        Power_Outlet = 1,
        Power_Strip = 2,
        Plug = 3,
        Power_Supply = 4,
        LED_Driver = 5,
        Fluorescent_Lamp_Gear = 6,
        HID_Lamp_Gear = 7,
    }

    public enum BLE_AppearanceLightSource : uint {
        Generic = 0,
        Incandescent_Light_Bulb = 1,
        LED_Bulb = 2,
        HID_Lamp = 3,
        Fluorescent_Lamp = 4,
        LED_Array = 5,
        Multi_Color_LED_Array = 6,
    }

    public enum BLE_AppearanceOximeter : uint {
        Generic = 0,
        Fingertip = 1,
        Wrist_Worn = 2,
    }

    public enum BLE_AppearanceOutdoorSportActivity : uint {
        Generic = 0,
        Location_Display_Device = 1,
        Location_and_Navigation_Display_Device = 2,
        Location_Pod = 3,
        Location_and_Navigation_Pod = 4,
    }





    /// <summary>The spec appearance types which combine category and sub category</summary>
    /// <remarks>
    /// BLE Spec: 
    /// 
    /// Category takes (10 bits), Sub-category (6 bits)
    /// So, if we concatenate both we can get the type with one number
    /// Example 
    ///         Watch = 192 (Category 192, Sub Category 0)
    ///   Sport Watch = 193 (Category 192, Sub Category 1)
    ///
    /// Each category can have 64 entries in the sub category 6 bits (0-63)
    /// </remarks>
    public enum BLE_AppearanceConcatenated {
        Unknown = 0,
        Phone = 64,     
        Computer = 128, 
        Watch = 192,    
        SportsWatch = 193,
        Clock = 256,
        Display = 320,
        RemoteControl = 384,
        EyeGlasses = 448,
        Tag = 512,
        Keyring = 576,
        MediaPlayer = 640,
        GenericBarcodeScanner = 704,
        Thermometer = 768,
        EarThermometer = 769,
        HeartRateSensor = 832,
        BeltHeartRateSensor = 833,
        BloodPressure = 896,
        BloodPressureArm = 897,
        BloodPressureWrist = 898,
        //--------------------------------
        // HID category 960
        InterfaceDevice = 960,
        Keyboard = 961,
        Mouse = 962,
        Joystick = 963,
        Gamepad = 964,
        Digitizer = 965,
        CardReader = 966,
        DigitalPen = 967,
        BarcodeScanner = 968,
        //--------------------------------
        GlucoseMeter = 1024,
        //--------------------------------
        // Walking sensors category 1088
        WalkingSensor = 1088,
        WalkingSensorInShoe = 1089,
        WalkingSensorOnShoe = 1090,
        WalkingSensorOnHip = 1091,
        //--------------------------------
        // Cycling category 1152
        CyclingGeneric = 1152,
        CyclingComputer = 1153,
        CyclingSpeedSensor = 1154,
        CyclingCadenceSensor = 1155,
        CyclingPowerSensor = 1156,
        CyclingSpeedAndCadenceSensor = 1157,
        //--------------------------------
        // Control devices category 1216
        ControlDevice = 1216,
        SwitchControl = 1217,
        MultiSwitchControl = 1218,
        ButtonControl = 1219,
        SliderControl = 1220,
        RotaryControl = 1221,
        TouchPanelControl = 122,
        //--------------------------------
        NetworkDevice = 1280,
        //--------------------------------
        // Sensors category 1344
        GenericSensor = 1344,
        MotionSensor = 1345,
        AirQualitySensor = 1346,
        TemperatureSensor = 1347,
        HumiditySensor = 1348,
        LeakSensor = 1349,
        SmokeSensor = 1350,
        OccupancySensor = 1351,
        ContactSensor = 1352,
        CarbonMonoxideSensor = 1353,
        CarbonDioxideSensor = 1354,
        AmbientLightSensor = 1355,
        EnergySensorSensor = 1356,
        ColorLightSensor = 1357,
        RainSensorSensor = 1358,
        FireSensorSensor = 1359,
        WindSensor = 1360,
        ProximitySensor = 1361,
        MultiSensorSensor = 1362,
        //--------------------------------
        // Light fixtures category 1408
        GenericLightFixtures= 1408,
        WallLightFixture = 1409,
        CeilingLight = 14010,
        FloorLight = 14011,
        CabinetLight = 14012,
        DeskLight = 14013,
        TrofferLight = 14014,
        PendantLight = 14015,
        InGroundLight = 14016,
        FloodLight = 14017,
        UnderwaterLight = 14018,
        BollardWithLight = 14019,
        PathwayLight = 14020,
        GardenLight = 14021,
        PoleTopLight = 14022,
        Spotlight = 14023,
        LinearLight = 14024,
        StreetLight = 14025,
        ShelvesLight = 14026,
        HighBayLowBayLight = 14027,
        EmergencyExitLight = 14028,
        //--------------------------------

        /*
1472 0 Generic Fan Generic category
1 Ceiling Fan Fan subtype
2 Axial Fan Fan subtype
3 Exhaust Fan Fan subtype
4 Pedestal Fan Fan subtype
5 Desk Fan Fan subtype
6 Wall Fan 
        */

        /*
1536 0 Generic HVAC
1 Thermostat        
        */

        /*
1600 0 Generic Air Conditioning
        */

        /*
1664 0 Generic Humidifier
        */

        /*
1728 0 Generic Heating Generic category
1 Radiator Heating subtype
2 Boiler Heater subtype
3 Heat Pump Heater subtype
4 Infrared Heater Heater subtype
5 Radiant Panel Heater Heater subtype
6 Fan Heater Heater subtype
7 Air Curtain
        */

        /*
1792 0 Generic Access Control Generic category
1 Access Door Access subtype
2 Garage Door Access subtype
3 Emergency Exit Door Access subtype
4 Access Lock Access subtype
5 Elevator Access subtype
6 Window Access subtype
7 Entrance Gate 
        */

        /*
1856 0 Generic Motorized Device Generic category
1 Motorized Gate Motorized subtype
Appearance Values / Document
Bluetooth SIG Proprietary Page 11 of 12
Category
(10 bits)
Sub-category
(6 bits)
Value Definition Description
2 Awning Motorized subtype
3 Blinds or Shades Motorized subtype
4 Curtains Motorized subtype
5 Screen 
        */

        /*
1920 0 Generic Power Device Generic category
1 Power Outlet Power subtype
2 Power Strip Power subtype
3 Plug Power subtype
4 Power Supply Power subtype
5 LED Driver Power subtype
6 Fluorescent Lamp Gear Power subtype
7 HID Lamp Gear
        */

        /*
1984 0 Generic Light Source Generic category
1 Incandescent Light Bulb Light subtype
2 LED Bulb Light subtype
3 HID Lamp Light subtype
4 Fluorescent Lamp Light subtype
5 LED Array Light subtype
6 Multi-Color LED Array
        */

        /*
3136 0 Generic Pulse Oximeter Generic category
1 Fingertip (concatenated value: 3137) Pulse Oximeter subtype
2 Wrist Worn (concatenated value: 3138)
        */

        /*
3200 0 Generic: Weight Scale
        */

        /*
5184 0 Generic Outdoor Sports Activity Generic category
1 Location Display Device (concatenated value:
5185)
Outdoor Sports Activity
subtype
2 Location and Navigation Display Device
(concatenated value: 5186)
Outdoor Sports Activity
subtype
3 Location Pod (concatenated value: 5187) Outdoor Sports Activity
subtype
4 Location and Navigation Pod (concatenated
value: 5188)
Outdoor Sports Activity
subtype
        */

        /*

        */


    }

}
