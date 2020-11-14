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
        ClassLog log = new ClassLog("NetSocketMsgPump");
        //        Task connectTask = null;
        //Task readTask = null;
        //ManualResetEvent connectComplete = new ManualResetEvent(false);
        //ManualResetEvent readThreadStarted = new ManualResetEvent(false);
        //ManualResetEvent readThreadEnded = new ManualResetEvent(false);

        //CancellationTokenSource readCancelation = new CancellationTokenSource();

        //SocketAsyncEventArgs receiveArgs = new SocketAsyncEventArgs();

        //private bool connecting = false;


        private static Socket stSocket = null;


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
                Thread.Sleep(1000);

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



        private void LaunchReadThread() {
            Task.Run(()=>{
                this.doReading = true;
                int count = 0;
                AutoResetEvent done = new AutoResetEvent(false);
                SocketAsyncEventArgs receiveArgs = new SocketAsyncEventArgs();
                receiveArgs.SetBuffer(this.buff, 0, buffSize);
                receiveArgs.Completed += this.ReceiveArgs_Completed;
                receiveArgs.UserToken = done;
                receiveArgs.SetBuffer(this.buff, 0, buffSize);

                this.log.InfoEntry("LaunchReadThread");
                while (this.doReading) {


                    if (!socket.ReceiveAsync(receiveArgs)) {
                        if (receiveArgs.SocketError != SocketError.Success) {
                            this.log.Error(1234, "Error detected on read thread. Exiting");
                            this.MsgPumpConnectResultEvent?.Invoke(this,
                                new MsgPumpResults(
                                    MsgPumpResultCode.ConnectionFailure,
                                    receiveArgs.SocketError.ToString()));
                            break;
                        }
                        else {
                            if (receiveArgs.Count > 0) {
                                // When false it did it synchronously and we must check here
                                this.log.Info("Read Thread", "Sync");
                                this.RaiseReceivedData(receiveArgs);
                            }
                            else {
                                if ((count++ % 100) == 0) {
                                    this.log.Info("Read Thread", "Sync - 0 bytes");
                                    Thread.Sleep(100);
                                }

                            }
                        }

                    }
                    else {
                        // Wake up every half second to exit on cancel
                        this.log.Info("Read Thread", "Async");
                        if (done.WaitOne(500)) {
                            done.Reset();
                        }                        
                    }
                }
                receiveArgs.Completed -= this.ReceiveArgs_Completed;
                receiveArgs.Dispose();

                this.log.InfoExit("LaunchReadThread");
            });
        }

        private void ReceiveArgs_Completed(object sender, SocketAsyncEventArgs args) {
            this.RaiseReceivedData(args);
            (args.UserToken as AutoResetEvent).Set();
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
        }

        #endregion



    }
}
