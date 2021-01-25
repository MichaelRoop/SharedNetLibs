﻿using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics.DataTypes {

    public class TypeParser_DayDateTime : CharParser_Base {

        TypeParser_DateTime dateTime = new TypeParser_DateTime();
        TypeParser_DayOfWeek dayOfWeek = new TypeParser_DayOfWeek();

        public override int RequiredBytes { get; protected set; } = 0;

        public TypeParser_DayDateTime() : base() { this.Setup(); }


        protected override void DoParse(byte[] data) {
            int pos = 0;
            byte[] dtBlock = data.ToByteArray(this.dateTime.RequiredBytes, ref pos);
            byte[] dowBlock = data.ToByteArray(this.dayOfWeek.RequiredBytes, ref pos);
            StringBuilder sb = new StringBuilder();
            sb.Append(this.dayOfWeek.Parse(dowBlock))
                .Append(" ")
                .Append(this.dateTime.Parse(dtBlock));
            this.DisplayString = sb.ToString();
        }


        private void Setup() {
            this.RequiredBytes = this.dateTime.RequiredBytes + this.dayOfWeek.RequiredBytes;
        }


    }
}