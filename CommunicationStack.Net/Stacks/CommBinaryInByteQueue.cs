using CommunicationStack.Net.BinaryMsgs;
using LogUtils.Net;
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

        private readonly static int BUFF_MAX_LEN = 1000;
        private readonly byte[] buff = new byte[BUFF_MAX_LEN];
        // Next pos is also length of data contained
        private int nextPos = 0;
        private byte[] startDelimiters = "\n".ToAsciiByteArray();
        private byte[] endDelimiters = "\n".ToAsciiByteArray();
        private uint expectedLength = 0;
        private readonly ClassLog log = new ("CommBinaryInByteQueue");

        #endregion

        #region Events

        /// <summary>Event fired with a full message object is assembled</summary>
        public event EventHandler<byte[]>? MsgReceived;

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
                if (this.nextPos == 0 && data.Length > 0) {
                    if (!this.ValidateStartDelimiters(data)) {
                        // Walk through bytes to throw out leading bad parts
                        this.log.Error(9999, "", () => string.Format("Invalid entry data:{0}", data.ToFormatedByteString()));
                        byte[]? tmp = this.WalkUntilValidData(data);
                        if (tmp == null) {
                            return false;
                        }
                        else {
                            data = tmp;
                        }
                    }
                }

                if (data.Length > 0) {
                    this.log.Info("AddBytes", () => string.Format("Data: {0}", data.ToFormatedByteString()));
                    result = this.buff.FifoPush(data, ref this.nextPos);
                    while (true) {
                        byte[] msg = this.buff.FifoPop(this.endDelimiters, ref this.nextPos);
                        if (msg.Length > 0) {
                            if (this.MsgReceived != null) {
                                byte[] fullMsg = this.ReplaceStripedEndDelimiters(msg);
                                if (this.ValidateStartDelimiters(fullMsg)) {
                                    if (fullMsg.IsValidMsg()) {
                                        this.MsgReceived?.Invoke(this, fullMsg);
                                    }
                                }
                            }
                        }
                        else {
                            // No more messages in FIFI queue
                            break;
                        }
                    }
                }
                return result;
            }
        }


        private byte[]? WalkUntilValidData(byte[] msg) {
            byte[] scratch = new byte[msg.Length];
            for (int i = 0; i < msg.Length - this.startDelimiters.Length; i++) {
                bool found = true;
                for (int j = 0; j < this.startDelimiters.Length; j++) {
                    if (msg[i + j] != this.startDelimiters[j]) {
                        found = false;
                        break;
                    }   
                }

                if (found) {
                    // Populate the byte array
                    byte[] tmp = new byte[msg.Length - i];
                    Array.Copy(msg, i, tmp, 0, tmp.Length);
                    this.log.Error(9999, "", () => string.Format("CORRECTED IN BUFF:{0}", tmp.ToFormatedByteString()));
                    return tmp;
                }
            }
            this.log.Error(9999, "Failed on walkthrough of start of buffer");
            return null;
        }



        /// <summary>Used at start of new data to check if first bytes are start delimiters</summary>
        /// <param name="msg">The message to validate</param>
        /// <returns>true if the order of bytes are same as start delimiters, otherwise false</returns>
        private bool ValidateStartDelimiters(byte[] msg) {
            for (int i = 0; i < this.startDelimiters.Length && i < msg.Length; i++) {
                if (msg[i] != this.startDelimiters[i]) {
                    this.log.Error(9999, "ValidateStartDelimiters",
                        () => string.Format("Mismatch start delimiters pos:{0}, Expected:{1} Actual:{2}",
                        i, this.startDelimiters[i], msg[i]));
                    return false;
                }
            }
            return true;
        }


        /// <summary>Need to replace end deliminators (terminators) the FIFO queue strips</summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private byte [] ReplaceStripedEndDelimiters(byte[] msg) {
            byte[] fullMsg = new byte[msg.Length + this.endDelimiters.Length];
            Array.Copy(msg, fullMsg, msg.Length);
            Array.Copy(this.endDelimiters, 0, fullMsg, msg.Length, this.endDelimiters.Length);
            return fullMsg;
        }

        #endregion

    }
}
