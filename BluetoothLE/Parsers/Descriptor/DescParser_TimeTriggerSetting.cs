using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// TODO - implement
    /// 
    /// (0x290E) Data type:
    ///     1. Condition: uint8
    ///     2. Value
    ///         Condition: 0 (None) - no comparison required (Digital or Analog)
    ///             uint8
    ///         Condition: 1,2 (TimeIntervalContinuousAfterSettableTime, TimeIntervalOnTimeExpiredOrDifferentState) 
    ///             uint24 (3 bytes) (org.bluetooth.unit.time.second)
    ///         Condition: 3 (Count) 
    ///             uint16
    /// </summary>
    public class DescParser_TimeTriggerSetting : DescParser_Base {

        #region Data

        private ClassLog log = new ClassLog("DescParser_TimeTriggerSetting");

        #endregion

        #region Properties

        public TimeTriggerCondition Condition { get; set; } = TimeTriggerCondition.None;
        public ushort Count { get; set; }
        public byte NoneValue { get; set; }

        public uint TimeInterval { get; set; }

        public bool IsValid { get; set; } = false;

        protected override bool IsDataVariableLength { get; set; } = true;

        #endregion


        private string BuildDisplayString() {
            if (this.IsValid) {
                switch (this.Condition) {
                    case TimeTriggerCondition.None:
                        return string.Format("Time Trigger Condition:{0} Value:-", this.Condition.ToString());
                    case TimeTriggerCondition.Count:
                        return string.Format("Time Trigger Condition:{0} Value:{1}", this.Condition.ToString(), this.Count);
                    case TimeTriggerCondition.TimeIntervalContinuousAfterSettableTime:
                    case TimeTriggerCondition.TimeIntervalOnTimeExpiredOrDifferentState:
                        return string.Format("Time Trigger Condition:{0} Value:{1}", this.Condition.ToString(), this.TimeInterval);
                    default:
                        return string.Format("Time Trigger Condition:{0} UNHANDLED", this.Condition.ToString());
                }
            }
            else {
                return "* N/A *";
            }
        }

        protected override void DoParse(byte[] data) {
            // first need to read the condition to determine the values size
            int pos = 0;
            byte tmp = data.ToByte(ref pos);
            if (tmp > (byte)TimeTriggerCondition.Count) {
                this.DisplayString = "Trigger condition not handled";
                return;
            }
            this.Condition = (TimeTriggerCondition)tmp;
            switch (this.Condition) {
                case TimeTriggerCondition.Count:
                    this.Count = data.ToUint16(ref pos);
                    this.IsValid = true;
                    break;
                case TimeTriggerCondition.None:
                    this.NoneValue = data.ToByte(ref pos);
                    this.IsValid = true;
                    break;
                case TimeTriggerCondition.TimeIntervalContinuousAfterSettableTime:
                case TimeTriggerCondition.TimeIntervalOnTimeExpiredOrDifferentState:
                    // TODO How to copy the 3 bytes for the BLE seconds time data
                    this.TimeInterval = 9999;
                    this.IsValid = true;
                    break;
                default:
                    // should never happen. just to satisfy compiler
                    break;
            }

            this.DisplayString = this.BuildDisplayString();
        }


        protected override Type GetDerivedType() {
            return this.GetType();
        }

        protected override void ResetMembers() {
            this.Condition = TimeTriggerCondition.None;
            this.Count = 0;
            this.TimeInterval = 0;
            this.NoneValue = 0;
            this.IsValid = false;
        }

    }

}
