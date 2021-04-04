using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace CommunicationStack.Net.Stacks {


    /// <summary>Object to manage incoming bytes until full message assembled</summary>
    /// <remarks>
    /// This manages the first stack layer over the comm channel to assemble 
    /// fragmented incoming messages into real messages based on expected 
    /// start and end terminators and expected length. 
    /// </remarks>
    public class CommBinaryInByteQueue {

        #region Data

        private static int BUFF_MAX_LEN = 1000;
        private byte[] buff = new byte[BUFF_MAX_LEN];
        // Next pos is also length of data contained
        private int nextPos = 0;
        private byte[] startDelimiters = "\n".ToAsciiByteArray();
        private byte[] endDelimiters = "\n".ToAsciiByteArray();
        private uint expectedLength = 0;
        private ClassLog log = new ClassLog("CommBinaryInByteQueue");

        #endregion

        #region Events

        /// <summary>Event fired with a full message object is assembled</summary>
        public event EventHandler<byte[]> MsgReceived;

        #endregion

        #region Properties

        /// <summary>Get or set the message packet start delimiters. Buffer flushed on set</summary>
        public byte[] StartDelimiters {
            get { return this.startDelimiters; }
            set {
                lock (this) {
                    // If we change delimiters we loose any data contained
                    this.FlushBuffer();
                    this.startDelimiters = value;
                }
            }
        }


        /// <summary>Get or set the message packet start delimiters. Buffer flushed on set</summary>
        public byte[] EndDelimiters {
            get { return this.endDelimiters; }
            set {
                lock (this) {
                    // If we change delimiters we loose any data contained
                    this.FlushBuffer();
                    this.endDelimiters = value;
                }
            }
        }

        public uint ExpectedLength {
            get { return this.expectedLength; }
            set {
                lock (this) {
                    // If we change delimiters we loose any data contained
                    this.FlushBuffer();
                    this.expectedLength = value;
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>Constructor</summary>
        /// <param name="startDelimters">The delimiters that indicate packet start</param>
        /// <param name="endDelimiters">The delimiters that indicate packet end</param>
        /// <param name="expectedLength">Expected length for fixed sized packets. Default 0 for no check</param>
        public CommBinaryInByteQueue(byte[] startDelimters, byte[] endDelimiters, uint expectedLength = 0) {
            this.startDelimiters = startDelimters;
            this.endDelimiters = endDelimiters;
            this.expectedLength = expectedLength;
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
                // Start afresh. Validate first bytes of incoming are delimiters
                if (this.nextPos == 0 && data.Length >= this.startDelimiters.Length) {
                    // All messages will have 
                    // SOH (1 byte)
                    // STX (1 byte)
                    // Size (1 byte)
                    if (!this.ValidateStartDelimiters(data)) {
                        return false;
                    }
                }

                if (data.Length > 0) {
                    this.log.Info("AddBytes", () => string.Format("Data: {0}", data.ToFormatedByteString()));
                    result = this.buff.FifoPush(data, ref this.nextPos);
                    byte[] msg = this.buff.FifoPop(this.endDelimiters, ref this.nextPos);
                    if (msg.Length > 0) {
                        if (this.MsgReceived != null) {
                            // Need to add the end delimitors as the Fifo will have stripped them out
                            byte[] fullMsg = new byte[msg.Length + this.endDelimiters.Length];
                            Array.Copy(msg, fullMsg, msg.Length);
                            Array.Copy(this.endDelimiters, 0, fullMsg, msg.Length, this.endDelimiters.Length);
                            // TODO - at this point we have validated at least the end parameters. Now must 
                            // evaluate start, length fields


                            this.MsgReceived?.Invoke(this, fullMsg);
                        }
                    }
                }
                return result;
            }
        }



        private bool ValidateStartDelimiters(byte[] msg) {
            for (int i = 0; i < this.startDelimiters.Length; i++) {
                if (msg[i] != this.startDelimiters[i]) {
                    this.log.Error(9999, "ValidateStartDelimiters",
                        () => string.Format("Mismatch start delimiters pos:{0}, Expected:{1} Actual:{2}",
                        i, this.startDelimiters[i], msg[i]));
                    return false;
                }
            }
            return true;
        }



        #endregion

    }
}
