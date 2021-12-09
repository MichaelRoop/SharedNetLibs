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
        Heart_Rate_Sensor = 832,
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
        // Not in spec, in case categories are added
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceThermometer : uint {
        Generic = 0,
        Ear = 1,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceHeartRate : uint {
        Generic = 0,
        On_Belt_Heart_Rate_Sensor = 1,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceBloodPressure : uint {
        Generic = 0,
        Blood_Pressure_on_Arm = 1,
        Blood_Pressure_on_Wrist = 2,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
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
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceRunWalkSensor : uint {
        Generic = 0,
        In_Shoe_Run_Walk_Sensor = 1,
        On_Shoe_Run_Walk_Sensor = 2,
        On_Hip_Run_Walk_Sensor = 3,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceCycling : uint {
        Generic = 0,
        Cycling_Computer = 1,
        Cycling_Speed_Sensor = 2,
        Cycling_Cadence_Sensor = 3,
        Cycling_Power_Sensor = 4,
        Cycling_Speed_and_Cadence_Sensor = 5,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceControlDevice : uint {
        Generic = 0,
        Switch = 1,
        Multi_Switch = 2,
        Button = 3,
        Slider = 4,
        Rotary = 5,
        Touch_Panel = 6,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceSensor : uint {
        Generic = 0,
        Motion_Sensor = 1,
        Air_Quality_Sensor = 2,
        Temperature_Sensor = 3,
        Humidity_Sensor = 4,
        Leak_Sensor = 5,
        Smoke_Sensor = 6,
        Occupancy_Sensor = 7,
        Contact_Sensor = 8,
        Carbon_Monoxide_Sensor = 9,
        Carbon_Dioxide_Sensor = 10,
        Ambient_Light_Sensor = 11,
        Energy_Sensor = 12,
        Color_Light_Sensor = 13,
        Rain_Sensor = 14,
        Fire_Sensor = 15,
        Wind_Sensor = 16,
        Proximity_Sensor = 17,
        Multi_Sensor = 18,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceLightFixture : uint {
        Generic = 0,
        Wall_Light = 1,
        Ceiling_Light = 2,
        Floor_Light = 3,
        Cabinet_Light = 4,
        Desk_Light = 5,
        Troffer_Light = 6,
        Pendant_Light = 7,
        In_Ground_Light = 8,
        Flood_Light = 9,
        Underwater_Light = 10,
        Bollard_Light = 11,
        Pathway_Light = 12,
        Garden_Light = 13,
        Pole_Top_Light = 14,
        Spot_Light = 15,
        Linear_Light = 16,
        Street_Light = 17,
        Shelves_Light = 18,
        High_Bay_Low_Bay_Light = 19,
        Emergency_Exit_Light = 20,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceFan : uint {
        Generic = 0,
        Ceiling_Fan=1,
        Axial_Fan = 2,
        Exhaust_Fan = 3,
        Pedestal_Fan = 4,
        Desk_Fan = 5,
        Wall_Fan = 6,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceHVAC : uint {
        Generic = 0,
        Thermostat = 1,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceHeating : uint {
        Generic = 0,
        Radiator = 1,
        Boiler = 2,
        Heat_Pump = 3,
        Infrared = 4,
        Radiant_Panel = 5,
        Heating_Fan = 6,
        Heating_Air_Curtain = 7,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
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
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceMotorizedDevice : uint {
        Generic = 0,
        Motorized_Gate = 1,
        Motorized_Awning = 2,
        Motorized_Blinds_or_Shades = 3,
        Motorized_Curtains = 4,
        Motorized_Screen = 5,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
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
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceLightSource : uint {
        Generic = 0,
        Incandescent_Light_Bulb = 1,
        LED_Bulb = 2,
        HID_Lamp = 3,
        Fluorescent_Lamp = 4,
        LED_Array = 5,
        Multi_Color_LED_Array = 6,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceOximeter : uint {
        Generic = 0,
        Fingertip_Oximeter = 1,
        Wrist_Worn_Oximeter = 2,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }

    public enum BLE_AppearanceOutdoorSportActivity : uint {
        Generic = 0,
        Sports_Location_Display_Device = 1,
        Sports_Location_and_Navigation_Display_Device = 2,
        Sports_Location_Pod = 3,
        Sports_Location_and_Navigation_Pod = 4,
        // Not in spec, in case sub categories added. Never above 63
        Not_Handled = 0xFFFF
    }


}
