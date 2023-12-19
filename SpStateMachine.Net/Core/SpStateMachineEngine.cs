using ChkUtils.Net;
using LogUtils.Net;
using SpStateMachine.Net.EventListners;
using SpStateMachine.Net.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SpStateMachine.Net.Core {

    /// <summary>
    /// Combines different elements of the State Machine architecture to 
    /// drive events and behavior
    /// <summary>
    /// <author>Michael Roop</author>
    /// <copyright>July 2019 Michael Roop Used by permission</copyright> 
    public sealed class SpStateMachineEngine : IDisposable {

        #region Data

        readonly ISpPeriodicTimer timer;

        readonly ISpStateMachine stateMachine;

        readonly ISpEventStore msgStore;

        readonly ISpEventListner msgListner;

        readonly ISpBehaviorOnEvent eventBehavior;

        readonly Action wakeUpAction;

        private bool terminateThread = false;

        private readonly Thread driverThread;

        private readonly CancellationTokenSource cancelToken;

        readonly ClassLog log = new (typeof(SpStateMachineEngine).Name);

        #endregion

        #region Constructors

        ///// <summary>Default constructor in private scope to prevent usage</summary>
        //private SpStateMachineEngine() {
        //}


        /// <summary>Constructor</summary>
        /// <param name="msgListner">The event listner object that receives events</param>
        /// <param name="msgStore">The object that stores the messages</param>
        /// <param name="eventBehavior">The behavior object that interacts with incoming events</param>
        /// <param name="stateMachine">The state machine that interprets the events</param>
        /// <param name="timer">The periodic timer</param>
        public SpStateMachineEngine(
            [NotNull]ISpEventListner? msgListner,
            [NotNull] ISpEventStore? msgStore,
            [NotNull] ISpBehaviorOnEvent? eventBehavior,
            [NotNull] ISpStateMachine? stateMachine,
            [NotNull] ISpPeriodicTimer? timer) {

            WrapErr.ChkParam(msgListner, "msgListner", 50050);
            WrapErr.ChkParam(msgStore, "msgStore", 50051);
            WrapErr.ChkParam(eventBehavior, "eventBehavior", 50052);
            WrapErr.ChkParam(stateMachine, "stateMachine", 50053);
            WrapErr.ChkParam(timer, "timer", 50054);

            try {
                this.msgListner = msgListner;
                this.msgStore = msgStore;
                this.eventBehavior = eventBehavior;
                this.stateMachine = stateMachine;
                this.timer = timer;
                this.cancelToken = new CancellationTokenSource(1000);
                this.cancelToken.Token.ThrowIfCancellationRequested();

                this.driverThread = new Thread(new ThreadStart(this.DriverThread));
                this.driverThread.Start();

                // Initalise events that will be raised and connect them to objects that will raise them
                this.wakeUpAction = new Action(this.Timer_OnWakeup);
                this.msgListner.MsgReceived += this.EventListner_MsgReceived;
                this.timer.OnWakeup += this.wakeUpAction;
            }
            catch (Exception ex) {
                this.log.Exception(50055, "", ex);
                throw;
            }
        }


        /// <summary>Finalizer</summary>
        ~SpStateMachineEngine() {
            Dispose(false);
        }

        #endregion

        #region Public Methods

        /// <summary>Start up the Engine</summary>
        public void Start() {
            WrapErr.ChkDisposed(this.disposed, 50056);
            this.timer.Start();
        }


        /// <summary>Stop the Engine</summary>
        public void Stop() {
            WrapErr.ChkDisposed(this.disposed, 50057);
            this.timer.Stop();
        }

        #endregion

        #region Private Thread Methods

        /// <summary>
        /// Thread to drive the state machine
        /// </summary>
        private void DriverThread() {
            this.log.DebugEntry("DriverThread");

            while (!this.terminateThread) {
                WrapErr.ToErrReport(50058, () => {
                    if (this.cancelToken.IsCancellationRequested) {
                        return;
                    }

                    if (!this.terminateThread) {
                        this.eventBehavior.WaitOnEvent();
                    }
                    if (!this.terminateThread) {
                        this.msgListner.PostResponse(this.stateMachine.Tick(this.msgStore.Get()));
                    }
                });
            }
            this.log.DebugExit("DriverThread");
        }

        #endregion

        #region Private Methods

        /// <summary>Action fired on timer wakeup</summary>
        void Timer_OnWakeup() {
            this.eventBehavior.EventReceived(BehaviorResponseEventType.PeriodicWakeup);
        }


        /// <summary>Event from the event listner gets stuffed in the store</summary>
        /// <param name="msg"></param>
        void EventListner_MsgReceived(object? sender, EventArgs e) {
            this.msgStore.Add(((SpMessagingArgs)e).Payload);
            this.eventBehavior.EventReceived(BehaviorResponseEventType.MsgArrived);
        }


        /// <summary>Stop the timer and tick thread        /// </summary>
        private void ShutDownThread() {
            this.log.DebugEntry("ShutDownThread");

            WrapErr.ToErrReport(50059, () => {
                if (this.timer != null) {
                    WrapErr.SafeAction(() => this.timer.Stop());
                }
                this.terminateThread = true;
                if (this.eventBehavior != null) {
                    WrapErr.SafeAction(() =>
                        this.eventBehavior.EventReceived(BehaviorResponseEventType.TerminateRequest));
                }

                if (this.driverThread != null) {
                    if (this.driverThread.IsAlive) {
                        if (!this.driverThread.Join(1000)) {
                            WrapErr.SafeAction(this.cancelToken.Cancel);
                        }
                    }
                }
            });
            this.log.DebugExit("ShutDownThread");
        }

        #endregion

        #region IDisposable

        private bool disposed = false;

        public void Dispose() {
            Dispose(true);

            // Prevent finalizer call if already released
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Dispose resources
        /// </summary>
        /// <param name="disposeManagedResources">
        /// If true it was called by the Dispose method rather than finalizer
        /// </param>
        private void Dispose(bool disposeManagedResources) {
            this.log.Info("Dispose", String.Format("Disposed:{0} diposeManagedResources:{1}", this.disposed, disposeManagedResources));

            if (!disposed) {
                ShutDownThread();

                if (disposeManagedResources) {
                    DisposeManagedResources();
                }
                DisposeNativeResources();
            }
            this.disposed = true;
        }


        /// <summary>Dispose managed resources (those with Dispose methods)</summary>
        private void DisposeManagedResources() {
            this.log.DebugEntry("DisposeManagedResources");

            // Disconnect event handling
            WrapErr.SafeAction(() => { this.msgListner.MsgReceived -= this.EventListner_MsgReceived; });
            WrapErr.SafeAction(() => { this.timer.OnWakeup -= this.wakeUpAction; });

            DisposeObject(this.timer, "timer");
            DisposeObject(this.eventBehavior, "eventBehavior");
            DisposeObject(this.stateMachine, "stateMachine");
            DisposeObject(this.msgStore, "msgStore");
            DisposeObject(this.msgListner, "msgListner");
        }


        /// <summary>Factor out the disposal of objects</summary>
        /// <param name="disposableObject">object to dispose</param>
        /// <param name="name">Name of object for error logging</param>
        private static void DisposeObject(IDisposable disposableObject, string name) {
            WrapErr.ToErrReport(50060, String.Format("Error Disposing Object:{0}", name), () => {
                disposableObject?.Dispose();
            });
        }


        /// <summary>Dispose unmanaged native resources (InPtr, file handles)</summary>
        private static void DisposeNativeResources() {
            // Nothing to cleanup
        }

        #endregion
    }
}
