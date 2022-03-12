using ChkUtils.Net;
using LogUtils.Net;
using System.Diagnostics.CodeAnalysis;

namespace VariousUtils.Net {

    public class TaskWrap {

        #region Data

        private readonly ClassLog log = new("TaskWrap");
        //private readonly Action taskAction;
        private readonly ManualResetEvent taskFinishedEvent = new(false);
        //private bool continueAction = false;
        private CancellationTokenSource? token = new(1);

        #endregion

        #region Constructors

        public TaskWrap([NotNull] Action action) {
            WrapErr.ChkVar(action, 9999, "Null action");
            //this.taskAction = action;
        }


        public void Start() {
            this.Abort();
            this.Setup();

            Task.Run(() => {
                this.log.InfoEntry("Start +++");

                if (this.token != null) {
                    //        while (this.continueReading) {
                    //            try {
                    //                int count = (int)await this.reader.LoadAsync(this.readBufferMaxSizer).AsTask(this.readCancelationToken.Token);
                    //                this.log.Error(9, "received");
                    //                if (count > 0) {
                    //                    byte[] tmpBuff = new byte[count];
                    //                    this.reader.ReadBytes(tmpBuff);
                    //                    this.HandlerMsgReceived(this, tmpBuff);
                    //                }
                    //            }
                    //            catch (TaskCanceledException) {
                    //                this.log.Info("DoReadTask", "Cancelation");
                    //                break;
                    //            }
                    //            catch (Exception e) {
                    //                this.log.Exception(9999, "", e);
                    //                break;
                    //            }
                    //        }
                    //    }
                    //    else {
                    //        this.log.Error(9999, "Reader or token null");
                }
                //    this.log.InfoExit("DoReadTask ---");
                //    this.readFinishedEvent.Set();
                this.taskFinishedEvent.Set();
            });




        }


        public void Abort() {
            //this.continueAction = true;
            if (this.token != null) {
                this.token.Cancel();
                this.token.Dispose();
                this.token = null;



                // Some kind of manual event
            }

            // Wait on finished event


        }


        private void Setup() {
            //this.continueAction = true;
            this.taskFinishedEvent.Reset();
            this.token = new CancellationTokenSource(1);

        }






        #endregion

    }
}
