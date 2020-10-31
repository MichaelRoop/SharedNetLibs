﻿using Common.Net.Network;
using SerialCommon.Net.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerialCommon.Net.DataModels {
    
    public class SerialDeviceInfo {
        public string Name { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public bool IsEnabled { get; set; } = false;
        public string PortName { get; set; } = string.Empty;
        
        /// <summary>Gets or sets Baud rate</summary>
        public uint Baud { get; set; } = 0;
        
        /// <summary>Number of data bits per character. Does not include parity or stop bits</summary>
        public ushort DataBits { get; set; } = 0;
        
        /// <summary>Stop bit count</summary>
        public SerialStopBits StopBits { get; set; } = SerialStopBits.One;
        
        /// <summary>Gets or sets parity bit</summary>
        public SerialParityType Parity { get; set; } = SerialParityType.None;

        /// <summary>Serial data flow control protocol</summary>
        public SerialFlowControlHandshake FlowHandshake { get; set; } = SerialFlowControlHandshake.None;

        /// <summary>Gets or sets value when write operation time out</summary>
        public TimeSpan WriteTimeout { get; set; }

        /// <summary>Gets or sets value when read operation time out- near infinite by default</summary>
        public TimeSpan ReadTimeout { get; set; }

        /// <summary>Gets or sets the TX to enable or disable transmission</summary>
        public bool TX_BreakSignalEnabled { get; set; } = true;
        
        /// <summary>Gets state of CD Carrier detect line, true if line is detected</summary>
        public bool CD_CarrierDetectLineState { get; set; } = true;

        /// <summary>Gest state of CTS - Clear To Send Line true if detected</summary>
        public bool CTS_ClearToSendLineState { get; set; } = false;
        
        /// <summary> Gets state of  - CTS line</summary>
        public bool CTS_IsClearToSendEnabled { get; set; } = false;
        
        /// <summary>Gets or sets the RTS signal</summary>
        public bool RTS_IsRequesttoSendEnabled { get; set; } = false;

        /// <summary> Gets or sets value - enable of DTR Data Terminal Ready signal</summary>
        public bool DTR_IsDataTerminalReady { get; set; } = false;

        /// <summary> Gets value of whether DSR has been sent to serial port</summary>
        public bool DSR_DataSetReadyState { get; set; } = false;

        /// <summary>Bytes received on last input operation. Not required to show</summary>
        public uint BytesReceivedOnLastInput { get; set; }

        /// <summary>ID of USB vendor. Example 0x3EB would be registered to Atmel</summary>
        /// <remarks>see: https://the-sz.com/products/usbid/</remarks>
        public ushort USB_VendorId { get; set; } = 0;

        /// <summary>ID of USB Product. Example 0x2145 would be registered to ATMEGA328P-XMINI (CDC ACM)</summary>
        /// <remarks>see: https://the-sz.com/products/usbid/</remarks>
        public ushort USB_ProductId { get; set; } = 0;


        // Not sure if the same
        public Dictionary<string, NetPropertyDataModel> Properties { get; set; } =
            new Dictionary<string, NetPropertyDataModel>();
        
        // Device information kind - same as BLE -

    }
}
