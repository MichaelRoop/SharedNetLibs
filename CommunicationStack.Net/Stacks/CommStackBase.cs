using CommunicationStack.Net.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils;

namespace CommunicationStack.Net.Stacks {

    public class CommStackBase : ICommStackLevel0 {

        #region Data

        /// <summary>The  comm channel</summary>
        ICommStackChannel commChannel = null;

        /// <summary>Holds incoming bytes until they can be reassembled into messages</summary>
        private byte[] inBuffer = new byte[1000];

        /// <summary>Position to insert incoming bytes</summary>
        private int currentInPos = 0;

        #endregion

        #region ICommStackLevel0 Events

        /// <summary>Event fired with the message stripped of terminators</summary>
        /// <remarks>Example of simple wrapper terminator is '\n\r'</remarks>
        public event EventHandler<byte[]> MsgReceived;

        #endregion

        #region ICommStackLevel0 Properties

        /// <summary>Terminator used to recognize incoming msgs. Default '\n'</summary>
        public byte[] InTerminators { get; set; } = CharHelpers.ToByteArray('\n');

        /// <summary>Terminator added to outgoing messages. Default '\n'</summary>
        public byte[] OutTerminators { get; set; } = CharHelpers.ToByteArray('\n');

        #endregion


        public CommStackBase(ICommStackChannel commChannel) {
            this.commChannel = commChannel;
            this.commChannel.MsgReceivedEvent += this.CommChannel_MsgReceivedEvent;
        }


        public bool SendToComm(byte[] msg) {
            byte[] outBuff = new byte[msg.Length + this.OutTerminators.Length];
            Array.Copy(msg, outBuff, msg.Length);
            Array.Copy(this.OutTerminators, 0, outBuff, msg.Length,this.OutTerminators.Length);
            return this.commChannel.SendOutMsg(outBuff);
        }


        private void RaiseMsgReceived() {

        }


        private void CommChannel_MsgReceivedEvent(object sender, byte[] msg) {
            // Copy to in buffer
            Array.Copy(msg, 0, this.inBuffer, this.currentInPos, msg.Length);
            // move pointer to next
            this.currentInPos += msg.Length;
            // Look through buffer from start to see if there is a message

            //Array.FindIndex(this.inBuffer, 0, 5,  (b) => b.)





        }

        private void ProcessInBytes(byte[] inData) {
            throw new NotImplementedException();

        }


    }


    public static class X {

        public static int FindFirstBytePatternPos(this byte[] buff, int searchLen, byte[] pattern) {
            if (pattern.Length == 0) {
                return -1;
            }
            if (pattern.Length == 1) {
                return Array.FindIndex(buff, 0, searchLen, (b) => b == pattern[0]);
            }

            int pos = -1;
            for (int i = 0; i < searchLen; i++) {
                // Found first byte of pattern
                if (buff[i]  == pattern[0]) {
                    // Now step through the remaining bytes for remainder of pattern
                    int matches = 0;
                    for (int j = 0; j < pattern.Length && ((i + j) < searchLen); j++) {
                        if (buff[i+j] == pattern[j]) {
                            matches++;
                        }
                        else {
                            // mismatch, keep looking
                            break;
                        }
                    }
                    if (matches == pattern.Length) {
                        pos = i;
                        // Break out of outer loop
                        break;
                    }
                }
            }
            return pos;
        }

    }


}
