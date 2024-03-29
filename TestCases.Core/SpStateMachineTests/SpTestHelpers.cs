﻿using LogUtils.Net;
using SpStateMachine.Net.EventListners;
using SpStateMachine.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases.SpStateMachineTests {

    public class SpTestHelpers {

        private ClassLog log = new ("SpTestHelpers");





        public void ListnerMsgDumpDelegate(object? sender, EventArgs e) {
            this.ListnerMsgDebugRespDump(sender, e, true);
        }

        public void ListnerResponseDumpDelegate(object? sender, EventArgs e) {
            this.ListnerMsgDebugRespDump(sender, e, false);
        }


        private void ListnerMsgDebugRespDump(object? sender, EventArgs e, bool isMsg) {
            SpMessagingArgs args = (SpMessagingArgs)e;
            ISpEventMessage msg = args.Payload;

            string source = isMsg ? "Message" : "Response";
            this.log.Info("Dump msg / response", () =>
                string.Format("**** {0} Id:{1} Ret:{2} Status:{3} Payload:{4} Priority:{5} UID:{6}",
                source,
                msg.EventId,
                msg.ReturnCode,
                msg.ReturnStatus,
                msg.StringPayload,
                msg.Priority,
                msg.Uid));

        }


    }
}
