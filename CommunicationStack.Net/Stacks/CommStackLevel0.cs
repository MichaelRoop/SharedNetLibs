using ChkUtils.Net;
using CommunicationStack.Net.interfaces;
using LogUtils.Net;
using System;
using System.Text;
using System.Threading.Tasks;
using VariousUtils;

namespace CommunicationStack.Net.Stacks {

    /// <summary>Manage level 0 of the incoming data stack next to comm channel</summary>
    public class CommStackLevel0 : ICommStackLevel0 {

        #region Data

        /// <summary>The  comm channel</summary>
        private ICommStackChannel commChannel = null;

        /// <summary>Input queue which defragments the incoming bytes into messages</summary>
        private CommCharInByteQueue queue = new CommCharInByteQueue("\n".ToAsciiByteArray());

        private ClassLog log = new ClassLog("CommStackLevel0");

        #endregion

        #region ICommStackLevel0 Events

        /// <summary>Event fired with the message stripped of terminators</summary>
        /// <remarks>Example of simple terminator is '\n\r'</remarks>
        public event EventHandler<byte[]> MsgReceived;

        #endregion

        #region ICommStackLevel0 Properties

        /// <summary>Terminator used to recognize incoming msgs. Default '\n'</summary>
        public byte[] InTerminators {
            get { return this.queue.Terminator; }
            set { this.queue.Terminator = value; }
        }

        /// <summary>Terminator added to outgoing messages. Default '\n'</summary>
        public byte[] OutTerminators { get; set; } = CharHelpers.ToByteArray('\n');

        #endregion

        #region Constructors

        /// <summary>Constructor</summary>
        /// <param name="commChannel">Communication channel</param>
        public CommStackLevel0() {
            // Need to set inTerminator default since cannot be done on Property init
            this.InTerminators = CharHelpers.ToByteArray('\n');
        }


        /// <summary>
        /// Allow defered initialisation of comm channel so DI can deliver multiple
        /// instances of channel for different comm channel object. 
        /// </summary>
        /// <param name="commChannel"></param>
        public void SetCommChannel(ICommStackChannel commChannel) {
            this.commChannel = commChannel;
            // intercept comm channel bytes received, push it to the queue for assembly
            // when assembled the queue will push out our message received with that data
            this.commChannel.MsgReceivedEvent += this.CommChannel_MsgReceivedEvent;
            this.queue.MsgReceived += this.Queue_MsgReceived;
        }

        #endregion

        #region Public

        /// <summary>Send a message to the comm channel. The terminator will be added</summary>
        /// <param name="msg">The message to send</param>
        /// <returns>true on success, otherwise false</returns>
        public bool SendToComm(byte[] msg) {
            byte[] outBuff = new byte[msg.Length + this.OutTerminators.Length];
            Array.Copy(msg, outBuff, msg.Length);
            Array.Copy(this.OutTerminators, 0, outBuff, msg.Length, this.OutTerminators.Length);
            this.log.Info("SendToComm", () => string.Format("Data: {0}", msg.ToAsciiString()));
            this.log.Info("SendToComm", () => string.Format("Data: {0}", msg.ToFormatedByteString()));
            return this.commChannel.SendOutMsg(outBuff);
        }


        /// <summary>Sends message through comm channel after adding terminators</summary>
        /// <param name="msg">The message to send</param>
        /// <returns>true on success, otherwise false</returns>
        public bool SendToComm(string msg) {
            return this.SendToComm(Encoding.ASCII.GetBytes(msg));
        }

        #endregion

        #region Private

        /// <summary>Handle the comm channel bytes received event</summary>
        /// <param name="sender">Sender of the message</param>
        /// <param name="data">The incoming bytes from comm channel</param>
        private void CommChannel_MsgReceivedEvent(object sender, byte[] data) {
            this.queue.AddBytes(data);
        }


        /// <summary>Handle the defragmented message from the queue</summary>
        /// <param name="sender">Sender of the message</param>
        /// <param name="msg">The incoming assembled message</param>
        private void Queue_MsgReceived(object sender, byte[] msg) {
            if (this.MsgReceived != null) {
                Task.Run(() => {
                    // Feed to thread pool to free up the comm channel
                    WrapErr.ToErrReport(9999, () => this.MsgReceived(this, msg));
                });

            }
        }

        #endregion

    }

}
