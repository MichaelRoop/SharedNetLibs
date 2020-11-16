using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.Enumerations;
using CommunicationStack.Net.interfaces;
using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationStack.Net.MsgPumps {

    /// <summary>Socket message pump using the Net Standard Socket API. Cross platform</summary>
    public class NetSocketMsgPump : IMsgPump<NetSocketConnectData> {

        #region Data

        private ClassLog log = new ClassLog("NetSocketMsgPump");
        private const int buffSize = 256;
        private byte[] buff = new byte[buffSize];
        private bool doReading = false;
        private Socket socket = null;
        private SocketAsyncEventArgs receiveArgs = null;
        private AutoResetEvent doneRead = new AutoResetEvent(false);

        #endregion

        #region Properties

        public bool Connected { get; private set; } = false;

        #endregion

        #region Events

        public event EventHandler<MsgPumpResults> MsgPumpConnectResultEvent;
        public event EventHandler<byte[]> MsgReceivedEvent;

        #endregion

        #region Constructors

        public NetSocketMsgPump() {
        }

        #endregion

        #region IMsgPump methods

        public void ConnectAsync(NetSocketConnectData paramsObj) {
            // Not going to await. User can check the event for completion
            this.ConnectAsync2(paramsObj);
        }


        public Task ConnectAsync2(NetSocketConnectData paramsObj) {
            return Task.Run(() => {
                try {
                    if (this.Connected) {
                        this.Disconnect();
                    }
                    IPAddress ip;
                    if (!IPAddress.TryParse(paramsObj.RemoteHostName, out ip)) {
                        this.RaiseConnectResult(MsgPumpResultCode.InvalidAddress, paramsObj.RemoteHostName);
                        return;
                    }

                    this.log.Info("ConnectAsync2", () => string.Format("{0}:{1} - {2}",
                        paramsObj.RemoteHostName, paramsObj.RemotePort, ip.AddressFamily));

                    this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                    args.Completed += ConnectCompletedHandler;
                    args.AcceptSocket = this.socket;
                    args.RemoteEndPoint = new IPEndPoint(ip, paramsObj.RemotePort);

                    this.log.Info("ConnectAsync2", () => string.Format("Connecting to:{0}",
                        args.RemoteEndPoint));


                    if (!Socket.ConnectAsync(SocketType.Stream, ProtocolType.Tcp, args)) {
                        // Synchronous return. Raise event immediately
                        if (args.SocketError != SocketError.Success) {
                            this.log.Info("ConnectAsync2", () => string.Format(
                                "Synchronous return Failed:{0}", args.SocketError.ToString()));
                        }
                        else {
                            this.log.Info("ConnectAsync2", "Synchronous return OK");
                            this.RaiseConnectOk();
                        }
                    }
                }
                catch (SocketException se) {
                    // TODO Conversion
                    this.log.Exception(9999, "", se);
                    this.RaiseConnectResult(MsgPumpResultCode.ConnectionFailure, se.Message);
                }
                catch (Exception e) {
                    this.log.Exception(9999, "", e);
                    this.RaiseConnectResult(MsgPumpResultCode.ConnectionFailure, e.Message);
                }
            });
        }


        // Synchronous disconnect
        public void Disconnect() {
            try {
                if (this.Connected) {
                    this.doReading = false;
                    this.doneRead.Set();
                    if (this.socket != null) {
                        // TODO - replace with socket.DisconnectAsync()
                        if (this.socket.Connected) {
                            this.socket.Disconnect(false);
                        }
                        this.socket.Dispose();
                        this.socket = null;
                    }
                }
            }
            catch (Exception e) {
                this.log.Exception(9999, "", e);
            }
        }


        /// <summary>Asynchrous write where this.SendCallback raised on completion</summary>
        /// <param name="msg">The message bytes to send</param>
        public void WriteAsync(byte[] msg) {
            try {
                if (this.Connected) {
                    this.socket.BeginSend(
                        msg, 0, msg.Length, SocketFlags.None,
                        new AsyncCallback(this.SendCallback), this.socket);
                }
            }
            catch (Exception e) {
                this.log.Exception(9999, "", e);
            }
        }



        #endregion

        #region Private

        private void RaiseConnectResult(MsgPumpResultCode code, string msg) {
            this.MsgPumpConnectResultEvent?.Invoke(this, new MsgPumpResults(code, msg));
        }


        private void RaiseConnectOk() {
            this.LaunchReadThread();
            this.Connected = true;
            this.MsgPumpConnectResultEvent?.Invoke(this, new MsgPumpResults(MsgPumpResultCode.Connected));
        }


        private void StartReceive(SocketAsyncEventArgs args) {
            args.SetBuffer(this.buff, 0, buffSize);
            if (!socket.ReceiveAsync(args)) {
                this.log.Info("StartReceive", "Synchronous processing");
                this.ProcessReceivedData(args);
            }
        }


        private void ProcessReceivedData(SocketAsyncEventArgs args) {
            if (args.SocketError != SocketError.Success) {
                if (this.doReading == false) {
                    try {
                        // This is an abort so do not post error
                        this.log.Info("ProcessReceivedData", "Aborting the read thread");
                        (args.UserToken as AutoResetEvent).Set();
                        return;
                    }
                    catch (Exception e) {
                        this.log.Exception(9999, "On Process Receive socket error", e);
                        (args.UserToken as AutoResetEvent).Set();
                        return;
                    }
                }

                // TODO Error but keep thread alive?
                this.log.Error(9999, "Error detected - keeping thread alive");
                this.RaiseConnectResult(MsgPumpResultCode.ConnectionFailure, args.SocketError.ToString());
                (args.UserToken as AutoResetEvent).Set();
            }
            else if (receiveArgs.BytesTransferred > 0) {
                this.log.Info("ProcessReceivedData", () => string.Format("raise event for {0} bytes received", receiveArgs.BytesTransferred));
                this.RaiseReceivedData(args);
                (args.UserToken as AutoResetEvent).Set();
            }
            else {
                // 0 Bytes so wait again for more
                this.log.Info("ProcessReceivedData", "0 Bytes received. Do not raise");
                (args.UserToken as AutoResetEvent).Set();
            }
        }


        private void LaunchReadThread() {
            Task.Run(()=>{
                try {
                    this.doReading = true;
                    if (this.receiveArgs != null) {
                        this.receiveArgs.Dispose();
                        this.receiveArgs = null;
                    }

                    this.receiveArgs = new SocketAsyncEventArgs();
                    this.receiveArgs.SetBuffer(this.buff, 0, buffSize);
                    this.receiveArgs.Completed += this.ReceiveArgs_Completed;
                    this.receiveArgs.UserToken = this.doneRead;
                    this.receiveArgs.AcceptSocket = this.socket;
                    this.receiveArgs.SocketFlags = SocketFlags.Partial;

                    this.log.Info("LaunchReadThread", () => string.Format("Thread:{0} number:{1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId));
                    while (this.doReading) {
                        this.doneRead.Reset();
                        this.StartReceive(this.receiveArgs);
                        this.doneRead.WaitOne();
                    }
                    this.receiveArgs.Completed -= this.ReceiveArgs_Completed;
                    this.receiveArgs.Dispose();
                    this.log.InfoExit("LaunchReadThread");
                    this.Connected = false;
                }
                catch(SocketException se) {
                    this.log.Exception(1222, "Socket Exception on read thread", se);
                    this.Connected = false;
                }
                catch (Exception e) {
                    this.log.Exception(1222, "Exception on read thread", e);
                    this.Connected = false;
                }
            });
        }


        private void ReceiveArgs_Completed(object sender, SocketAsyncEventArgs args) {
            this.log.Info("ReceiveArgs_Completed", "Asynchronous data in handler - raise and set event");
            this.ProcessReceivedData(args);

        }


        private void RaiseReceivedData(SocketAsyncEventArgs args) {
            int count = args.BytesTransferred;
            if (count > 0) {
                try {
                    byte[] tmpBuff = new byte[count];
                    Array.Copy(args.Buffer, tmpBuff, count);
                    this.MsgReceivedEvent?.Invoke(this, tmpBuff);
                }
                catch(Exception e) {
                    this.log.Exception(9999, "", e);
                }
            }
        }


        /// <summary>Event handler for ConnectAsync set on the async event args</summary>
        /// <param name="sender"></param>
        /// <param name="args">Async event args</param>
        private void ConnectCompletedHandler(object sender, SocketAsyncEventArgs args) {
            if (args.ConnectSocket != null) {
                this.log.Info("Args_ConnectCompleted", "Connect socket not null Connection success");
                this.log.Info("Args_ConnectCompleted", () => string.Format("Connected Status:{0}", args.ConnectSocket.Connected));

                this.socket = args.ConnectSocket;

                this.RaiseConnectOk();
            }
            else {
                this.log.Info("Args_ConnectCompleted", "Connect socket NULL FAil");
                // TODO - convert extension
                this.RaiseConnectResult(MsgPumpResultCode.ConnectionFailure, args.SocketError.ToString());
            }
        }



        /// <summary>Callback when send completes</summary>
        /// <param name="result">The asynchronous result object</param>
        private void SendCallback(IAsyncResult result) {
            try {
                Socket s = (Socket)result.AsyncState;
                SocketError err;
                s.EndSend(result, out err);
                if (err != SocketError.Success) {
                    this.log.Error(999, () => string.Format("Send Failed:{0}", err));
                    // TODO - raise error
                }
            }
            catch(Exception e) {
                this.log.Exception(9999, "Send callback exception", e);
            }
        }

        #endregion



    }
}
