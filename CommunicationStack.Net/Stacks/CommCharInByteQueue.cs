using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace CommunicationStack.Net.Stacks {

    /// <summary>Object to manage incoming bytes until full message assembled</summary>
    /// <remarks>
    /// This manages the first stack layer over the comm channel to assemble 
    /// fragmented incoming messages into real messages based on expected 
    /// terminator. 
    /// WARNING - THIS IS FOR CHAR MSGS COMING IN AS BYTES
    /// Defragmenting and assembling pure binary messaging is another 
    /// animal altogether and much more complex
    /// </remarks>
    public class CommCharInByteQueue {

        #region Data

        private static int BUFF_MAX_LEN = 1000;
        private byte[] buff = new byte[BUFF_MAX_LEN];
        // Next pos is also length of data contained
        private int nextPos = 0;
        private byte[] terminator = "\n".ToAsciiByteArray();
        private ClassLog log = new ClassLog("CommCharInByteQueue");

        #endregion

        #region Events

        /// <summary>Event fired with the message stripped of terminators</summary>
        /// <remarks>Example of simple wrapper terminator is '\n\r'</remarks>
        public event EventHandler<byte[]>? MsgReceived;

        #endregion

        #region Properties

        /// <summary>Get or set the message terminator. Buffer flushed on set</summary>
        public byte[] Terminator {
            get { return this.terminator; }
            set {
                lock (this) {
                    // If we change the terminator we loose any data contained
                    this.FlushBuffer();
                    this.terminator = value;
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>Constructor</summary>
        /// <param name="terminator">The message terminator</param>
        public CommCharInByteQueue(byte[] terminator) {
            this.terminator = terminator;
        }

        #endregion

        #region Public

        /// <summary>Clear any bytes remaining in buffer</summary>
        public void FlushBuffer() {
            lock (this) {
                for (int i = 0; i < BUFF_MAX_LEN; i++) {
                    this.buff[i] = 0;
                }
                this.nextPos = 0;
            }
        }


        /// <summary>Push bytes into the queue which will raise event on conmpleted message</summary>
        /// <param name="data">The incoming data bytes</param>
        /// <returns>true on success, false if buffer already full</returns>
        public bool AddBytes(byte[] data) {
            lock (this) {
                bool result = true;
                if (data.Length > 0) {
                    this.log.Info("AddBytes", () => string.Format("Data: {0}", data.ToAsciiString()));
                    this.log.Info("AddBytes", () => string.Format("Data: {0}", data.ToFormatedByteString()));
                    result = this.buff.FifoPush(data, ref this.nextPos);
                    byte[] msg = this.buff.FifoPop(this.Terminator, ref this.nextPos);
                    if (msg.Length > 0) {
                        if (this.MsgReceived != null) {
                            this.MsgReceived(this, msg);
                        }
                    }
                }
                return result;
            }
        }

        #endregion

    }
}
