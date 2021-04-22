using ChkUtils.Net;
using CommunicationStack.Net.interfaces;
using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VariousUtils.Net;

namespace CommunicationStack.Net.Stacks {

    public class CommBinaryStackLevel0 : ICommStackLevel0 {

        #region Data

        private ClassLog log = new ClassLog("CommBinaryStackLevel0");
        /// <summary>The  comm channel</summary>
        private ICommStackChannel commChannel = null;
        // Reuse InTerminators for the start of packet delimiters
        //byte[] startDelimiters = new byte[0];
        //// Reuse OutTerminators for the end of packet delimiters
        //byte[] endDelimiters = new byte[0];

        private CommBinaryInByteQueue queue = new CommBinaryInByteQueue(new byte[0], new byte[0]);


        #endregion

        #region ICommStackLevel0 Properties

        //public byte[] InTerminators {
        //    get { return this.startDelimiters; }
        //    set { this.startDelimiters = value; }
        //}
        //public byte[] OutTerminators {
        //    get { return this.endDelimiters; }
        //    set { this.endDelimiters = value; }
        //}


        public byte[] InTerminators {
            get { return this.queue.StartDelimiters; }
            set { this.queue.StartDelimiters = value; }
        }



        public byte[] OutTerminators {
            get { return this.queue.EndDelimiters; }
            set { this.queue.EndDelimiters = value; }
        }

        #endregion

        #region ICommStackLevel0 Events

        /// <summary>Raised when the complete packet arrives</summary>
        public event EventHandler<byte[]> MsgReceived;

        #endregion

        #region Constructors

        public CommBinaryStackLevel0() {
            // Need to set inTerminator default since cannot be done on Property init
            this.InTerminators = new byte[0];
            this.OutTerminators = new byte[0];
        }

        #endregion

        #region Public

        public bool SendToComm(byte[] msg) {
            // Presume the proper struct is sent
            this.log.Info("SendToComm", () => string.Format("Data: {0}", msg.ToFormatedByteString()));
            if (this.commChannel != null) {
                // wrapper should have built this
            }
            return this.commChannel.SendOutMsg(msg);
        }

        public bool SendToComm(string msg) {
            // DO NOT USE WITH BINARY
            throw new NotImplementedException();
        }

        public void SetCommChannel(ICommStackChannel commChannel) {
            this.commChannel = commChannel;
            this.commChannel.MsgReceivedEvent += this.commChannelMsgReceived;
            this.queue.MsgReceived += this.queueMsgReceived;
        }

        private void queueMsgReceived(object sender, byte[] msg) {
            if (this.MsgReceived != null) {
                Task.Run(() => {
                    // Feed to thread pool to free up the comm channel
                    WrapErr.ToErrReport(9999, () => this.MsgReceived(this, msg));
                });
            }
        }

        private void commChannelMsgReceived(object sender, byte[] msg) {
            this.queue.AddBytes(msg);
        }

        #endregion

    }
}
