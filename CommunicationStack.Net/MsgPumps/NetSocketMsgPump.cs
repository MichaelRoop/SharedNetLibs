using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.Enumerations;
using CommunicationStack.Net.interfaces;
using LogUtils.Net;
using System.Net;
using System.Net.Sockets;

namespace CommunicationStack.Net.MsgPumps {

    /// <summary>Socket message pump using the Net Standard Socket API. Cross platform</summary>
    public class NetSocketMsgPump : IMsgPump<NetSocketConnectData> {

        #region Data

        private ClassLog log = new ClassLog("NetSocketMsgPump");
        private const int buffSize = 256;
        private byte[] buff = new byte[buffSize];
        private bool doReading = false;
        private Socket? socket = null;
        private SocketAsyncEventArgs? receiveArgs = null;
        private AutoResetEvent doneRead = new AutoResetEvent(false);

        #endregion

        #region Properties

        public bool Connected { get; private set; } = false;

        #endregion

        #region Events

        public event EventHandler<MsgPumpResults>? MsgPumpConnectResultEvent;
        public event EventHandler<byte[]>? MsgReceivedEvent;

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
                    IPAddress? ip;
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
                    if (this.socket is not null) {
                        this.socket.BeginSend(
                            msg, 0, msg.Length, SocketFlags.None,
                            new AsyncCallback(this.SendCallback), this.socket);
                    }
                    else {
                        // TODO report error
                    }
                }
            }
            catch (Exception e) {
                this.log.Exception(9999, "", e);
            }
        }

        #endregion

        #region Private

        /// <summary>Start a new asynchronous read</summary>
        /// <param name="args">The read event args where buffer is reset</param>
        private void StartReceive(SocketAsyncEventArgs args) {
            if (this.socket is not null) {
                args.SetBuffer(this.buff, 0, buffSize);
                if (!socket.ReceiveAsync(args)) {
                    this.log.Info("StartReceive", "Synchronous processing");
                    this.ProcessReceivedEvent(args);
                }
            }
            else {
                // TODO error report
            }
        }


        /// <summary>Process the results of the last read event</summary>
        /// <param name="args">The read event args</param>
        private void ProcessReceivedEvent(SocketAsyncEventArgs args) {
            if (doReading == false) {
                this.log.Info("ProcessReceivedData", "Aborting the read thread");
            }
            else if (args.SocketError != SocketError.Success) {
                // TODO Error but keep thread alive?
                this.log.Error(9999, "Error detected - keeping thread alive");
                this.RaiseConnectResult(MsgPumpResultCode.ConnectionFailure, args.SocketError.ToString());
            }
            else if (this.receiveArgs is null) {
                this.log.Error(9999, "Receive args not initialized");
                this.RaiseConnectResult(MsgPumpResultCode.ReadFailure, "receiveArgs not initialized");
            }
            else if (receiveArgs.BytesTransferred > 0) {
                this.log.Info("ProcessReceivedData", () => string.Format("{0} Bytes received", receiveArgs.BytesTransferred));
                this.RaiseReceivedData(args);
            }
            else {
                //this.log.Info("ProcessReceivedData", "0 Bytes received");
                // Do a bit of a delay
                Thread.Sleep(25);
            }

            (args.UserToken as AutoResetEvent)?.Set();
        }


        /// <summary>Launch the read task that stays active until disconnection</summary>
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


        /// <summary>Process synchronous or asynchronous read event</summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="args">The event args</param>
        private void ReceiveArgs_Completed(object? sender, SocketAsyncEventArgs args) {
            //this.log.Info("ReceiveArgs_Completed", "Asynchronous data in handler - raise and set event");
            this.ProcessReceivedEvent(args);
        }


        /// <summary>Raise an event with the bytes received</summary>
        /// <param name="args">The read event args with the data</param>
        private void RaiseReceivedData(SocketAsyncEventArgs args) {
            int count = args.BytesTransferred;
            if (count > 0) {
                try {
                    if (args.Buffer != null) {
                        byte[] tmpBuff = new byte[count];
                        Array.Copy(args.Buffer, tmpBuff, count);
                        this.MsgReceivedEvent?.Invoke(this, tmpBuff);
                    }
                    else {
                        throw new NullReferenceException("Null args.Buffer");
                    }
                }
                catch(Exception e) {
                    this.log.Exception(9999, "", e);
                }
            }
        }


        /// <summary>Raise the connection results event</summary>
        /// <param name="code">The connection result code</param>
        /// <param name="msg">Message in case of error</param>
        private void RaiseConnectResult(MsgPumpResultCode code, string msg) {
            this.MsgPumpConnectResultEvent?.Invoke(this, new MsgPumpResults(code, msg));
        }


        /// <summary>Raise the connection result event with success and launch the read thread</summary>
        private void RaiseConnectOk() {
            this.LaunchReadThread();
            this.Connected = true;
            this.MsgPumpConnectResultEvent?.Invoke(this, new MsgPumpResults(MsgPumpResultCode.Connected));
        }


        /// <summary>Event handler for ConnectAsync set on the async event args</summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="args">Async event args</param>
        private void ConnectCompletedHandler(object? sender, SocketAsyncEventArgs args) {

            this.log.Info("ConnectCompletedHandler", () => string.Format("args.ConnectSocket NULL:{0}", args.ConnectSocket == null));
            this.log.Info("ConnectCompletedHandler", () => string.Format("args.AcceptSocket NULL:{0}", args.AcceptSocket == null));

            if (args.ConnectSocket != null) {
                if (args.SocketError == SocketError.Success) {
                    this.log.Info("ConnectCompletedHandler", () => string.Format("Connected Status:{0}", args.ConnectSocket.Connected));
                    this.socket = args.ConnectSocket;
                    this.RaiseConnectOk();
                }
                else {
                    // Found instance of when it returned with non null Connect socket
                    this.RaiseConnectResult(MsgPumpResultCode.ConnectionFailure, args.SocketError.ToString());
                }
            }
            else {
                this.log.Info("Args_ConnectCompleted", "Connect socket NULL Fail");
                // TODO - convert extension
                this.RaiseConnectResult(MsgPumpResultCode.ConnectionFailure, args.SocketError.ToString());
            }
        }


        /// <summary>Callback when send completes</summary>
        /// <param name="result">The asynchronous result object</param>
        private void SendCallback(IAsyncResult result) {
            try {
                if (result.AsyncState == null) {
                    throw new ArgumentNullException("null asyncState");
                }

                Socket? s = result.AsyncState as Socket;
                if (s == null) {
                    throw new ArgumentNullException("null Socket in AsyncState");
                }
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
