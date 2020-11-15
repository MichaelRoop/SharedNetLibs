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
    public class NetSocketMsgPump : IMsgPump<NetSocketConnectData> {

        #region Data

        private static Socket socket = null;
        private const int buffSize = 256;
        private byte[] buff = new byte[buffSize];
        ClassLog log = new ClassLog("**** NetSocketMsgPump");
        //        Task connectTask = null;
        //Task readTask = null;
        //ManualResetEvent connectComplete = new ManualResetEvent(false);
        //ManualResetEvent readThreadStarted = new ManualResetEvent(false);
        //ManualResetEvent readThreadEnded = new ManualResetEvent(false);

        //CancellationTokenSource readCancelation = new CancellationTokenSource();

        //SocketAsyncEventArgs receiveArgs = new SocketAsyncEventArgs();

        //private bool connecting = false;


        //private static Socket stSocket = null;


        #endregion

        #region Properties

        public bool Connected { get; private set; } = false;

        #endregion

        #region Events

        public event EventHandler<MsgPumpResults> MsgPumpConnectResultEvent;
        public event EventHandler<byte[]> MsgReceivedEvent;

        #endregion

        public NetSocketMsgPump() {
        }


        public void ConnectAsync(NetSocketConnectData paramsObj) {
            // Not going to await. User can check the event for completion
            this.ConnectAsync2(paramsObj);

            //if (this.DoItTask != null) {
            //    this.DoItTask.Dispose();
                    
            //}


        }

        //private Task DoItTask = null;
        //private void DoIt() { }


        public Task ConnectAsync2(NetSocketConnectData paramsObj) {
            return Task.Run(() => {
                try {
                    if (this.Connected) {
                        // TODO - teardown
                        this.Disconnect();
                    }
                    IPAddress ip;
                    if (!IPAddress.TryParse(paramsObj.RemoteHostName, out ip)) {
                        this.MsgPumpConnectResultEvent?.Invoke(this,
                            new MsgPumpResults(MsgPumpResultCode.InvalidAddress));
                        return;
                    }

                    this.log.Info("ConnectAsync2", () => string.Format("{0}:{1} - {2}", 
                        paramsObj.RemoteHostName, paramsObj.RemotePort, ip.AddressFamily));

                    //IPEndPoint endPoint = new IPEndPoint(ip, paramsObj.RemotePort);
                    //socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                    args.Completed += Args_ConnectCompleted;
                    args.AcceptSocket = socket;
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
                    this.MsgPumpConnectResultEvent?.Invoke(this,
                        new MsgPumpResults(MsgPumpResultCode.ConnectionFailure, se.Message));
                }
                catch (Exception e) {
                    this.log.Exception(9999, "", e);
                    this.MsgPumpConnectResultEvent?.Invoke(this,
                        new MsgPumpResults(MsgPumpResultCode.ConnectionFailure, e.Message));
                }
            });
        }


        private void Args_ConnectCompleted(object sender, SocketAsyncEventArgs args) {
            if (args.ConnectSocket != null) {
                this.log.Info("Args_ConnectCompleted", "Connect socket not null Connection success");
                this.log.Info("Args_ConnectCompleted", () => string.Format("Connected Status:{0}", args.ConnectSocket.Connected));

                socket = args.ConnectSocket;
                
                this.RaiseConnectOk();
            }
            else {
                this.log.Info("Args_ConnectCompleted", "Connect socket NULL FAil");
                // TODO - convert extension
                this.MsgPumpConnectResultEvent?.Invoke(this,
                    new MsgPumpResults(MsgPumpResultCode.ConnectionFailure, args.SocketError.ToString()));
            }


            //if (args.SocketError == SocketError.Success) {
            //    this.log.Info("Args_ConnectCompleted", "Connection success");

            //    this.log.Info("Args_ConnectCompleted", () => string.Format("Connected Status:{0}", args.AcceptSocket.Connected));

            //    this.RaiseConnectOk();
            //}
            //else {
            //    // TODO - convert extension
            //    this.MsgPumpConnectResultEvent?.Invoke(this,
            //        new MsgPumpResults(MsgPumpResultCode.ConnectionFailure, args.SocketError.ToString()));
            //}
        }


        private void RaiseConnectOk() {
            this.LaunchReadThread();
            this.Connected = true;
            this.MsgPumpConnectResultEvent?.Invoke(this,
                new MsgPumpResults(MsgPumpResultCode.Connected));
        }


        public void Disconnect() {
            if (this.Connected) {
                this.doReading = false;
                // TODO replace with event wait
                //Thread.Sleep(1000);
                if (socket != null) {
                    if (socket.Connected) {
                        socket.Disconnect(false);
                    }
                    socket.Dispose();
                    socket = null;
                }
            }
        }


        public void WriteAsync(byte[] msg) {
            if (this.Connected) {
                try {
                    socket.BeginSend(
                        msg, 0, msg.Length, SocketFlags.None,
                        new AsyncCallback(this.SendCallback),
                        socket);
                    // No waiting
                }
                catch(Exception e) {
                    this.log.Exception(9999, "", e);
                }
            }
        }

        #region Private

        private bool doReading = false;
        SocketAsyncEventArgs receiveArgs = null;

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
                    // This is an abort so do not post error
                    this.log.Info("ProcessReceivedData", "Aborting the read thread");
                    (args.UserToken as AutoResetEvent).Set();
                    return;
                }

                this.log.Error(9999, "Error detected");
                // TODO - close down?
                this.MsgPumpConnectResultEvent?.Invoke(this,
                    new MsgPumpResults(
                        MsgPumpResultCode.ConnectionFailure,
                        args.SocketError.ToString()));
                // If there any events to set we can do it here
                (args.UserToken as AutoResetEvent).Set();
            }
            else if (receiveArgs.BytesTransferred > 0) {
                this.log.Info("ProcessReceivedData", ()=> string.Format("raise event for {0} bytes received", receiveArgs.BytesTransferred));



                this.RaiseReceivedData(args);
                (args.UserToken as AutoResetEvent).Set();
                this.StartReceive(args);
            }
            else {
                this.log.Info("ProcessReceivedData", "0 Bytes received. Do not raise");

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
                    AutoResetEvent done = new AutoResetEvent(false);
                    receiveArgs.SetBuffer(this.buff, 0, buffSize);
                    receiveArgs.Completed += this.ReceiveArgs_Completed;
                    receiveArgs.UserToken = done;
                    receiveArgs.AcceptSocket = socket;
                    receiveArgs.SocketFlags = SocketFlags.Partial;

                    this.log.InfoEntry("LaunchReadThread");
                    while (this.doReading) {
                        done.Reset();
                        this.log.Info("LaunchReadThread", "Calling StartReceive top of loop");
                        this.StartReceive(this.receiveArgs);
                        //(this.receiveArgs.UserToken as AutoResetEvent).WaitOne(5000);

                        this.log.Info("LaunchReadThread", "Calling StartReceive bottom of loop");
                    }
                    receiveArgs.Completed -= this.ReceiveArgs_Completed;
                    receiveArgs.Dispose();

                    this.log.InfoExit("LaunchReadThread");
                }
                catch(SocketException se) {
                    this.log.Exception(1222, "Exception on read thread", se);
                }
                catch (Exception e) {
                    this.log.Exception(1222, "Exception on read thread", e);
                }
            });
        }


        private void ReceiveArgs_Completed(object sender, SocketAsyncEventArgs args) {
            this.log.Info("ReceiveArgs_Completed", "Asynchronous data in handler - raise and set event");
            this.ProcessReceivedData(args);


            //this.RaiseReceivedData(args);
            //this.StartReceive(args);
        }


        private void RaiseReceivedData(SocketAsyncEventArgs args) {
            this.log.InfoEntry("RaiseReceivedData");
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
            this.log.InfoExit("RaiseReceivedData");
        }




        //private void ConnectCallback(IAsyncResult ar) {
        //    try {
        //        // Retrieve the socket from the state object.  
        //        Socket s = (Socket)ar.AsyncState;

        //        // Complete the connection.  
        //        s.EndConnect(ar);

        //        //Console.WriteLine("Socket connected to {0}",
        //        //    client.RemoteEndPoint.ToString());

        //        this.connectComplete.Set();
        //    }
        //    catch (Exception e) {
        //        this.log.Exception(9999, "", e);
        //    }
        //}

        private void SendCallback(IAsyncResult result) {
            Socket s = (Socket)result.AsyncState;
            SocketError err;
            s.EndSend(result, out err);
            if (err != SocketError.Success) {
                this.log.Error(999, () => string.Format("Send Failed:{0}", err));
                // TODO - raise error
            }
            else {
                this.log.Info("SendCallback", "Send OK");
            }
        }

        #endregion



    }
}
