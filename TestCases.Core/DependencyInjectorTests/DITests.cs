using DependencyInjectorFactory.Net;
using DependencyInjectorFactory.Net.interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestCaseSupport.Core;

namespace TestCases.DependencyInjectorTests {

    [TestFixture]
    public class DITests : TestCaseBase {

        #region Data

        public class TestInstClassBase {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public int InstanceID { get; protected set; }

            public static int InstanceIDCounter { get; set; }

            public TestInstClassBase() {
                this.InstanceID = (++InstanceIDCounter);
            }
        };

        public class TestSinglClassBase {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public int InstanceID { get; protected set; }

            public static int InstanceIDCounter { get; set; }

            public TestSinglClassBase() {
                this.InstanceID = (++InstanceIDCounter);
            }
        };

        #region Simple classes
        public class SingleFirst : TestSinglClassBase { 
            public SingleFirst() : base() {} 
        };
        public class SingleSecond : TestSinglClassBase { 
            public SingleSecond() : base() { } 
        };

        public class InstanceFirst : TestSinglClassBase { public InstanceFirst() : base() { } };
        public class InstanceSecond : TestSinglClassBase { public InstanceSecond() : base() { } };
        #endregion


        public class TstSinglWithIns {
            public InstanceFirst InstClass { get; private set; }
            public int InstanceID { get; protected set; }
            private static int InstanceIDCounter = 0;

            public TstSinglWithIns(InstanceFirst? cl) {
                if (cl == null) {
                    throw new ArgumentNullException();
                }
                this.InstClass = cl;
                this.InstanceID = (InstanceIDCounter++);
            }
        }

        public class TstInsWithSingl {
            public SingleFirst SinglClass { get; private set; }
            public int InstanceID { get; protected set; }
            private static int InstanceIDCounter = 0;

            public TstInsWithSingl(SingleFirst? cl) {
                if (cl == null) {
                    throw new ArgumentNullException();
                }
                this.SinglClass = cl;
                this.InstanceID = (InstanceIDCounter++);
            }
        }


        public class TestContainer : ObjContainer {
            protected override void LoadCreators(
                Dictionary<Type, ObjCreator> instanceCreators,
                Dictionary<Type, ObjCreator> singletonCreators) {

                // Instances can share singletons
                instanceCreators.Add(typeof(InstanceFirst), new ObjInstanceCreator(() => new InstanceFirst()));
                instanceCreators.Add(typeof(InstanceSecond), new ObjInstanceCreator(() => new InstanceSecond()));


                singletonCreators.Add(typeof(SingleFirst), new ObjSingletonCreator(() => new SingleFirst()));
                singletonCreators.Add(typeof(SingleSecond), new ObjSingletonCreator(() => new SingleSecond()));

                // Singletons can have other singletons or instances as parameters

                // instance with singleton parameter
                instanceCreators.Add(typeof(TstInsWithSingl), new ObjInstanceCreator(
                    () => new TstInsWithSingl(this.GetObjSingleton<SingleFirst>())));


                // singleton with instance parameter (always same object and same instance of parameter
                singletonCreators.Add(typeof(TstSinglWithIns), new ObjSingletonCreator(
                    () => new TstSinglWithIns(this.GetObjInstance<InstanceFirst>())));


            }
        }

#pragma warning disable CS8618
        IObjContainer container;
#pragma warning restore CS8618

        //var v = new TstInsWithSingl(new SingleFirst());


        #endregion

        #region Setup

        [OneTimeSetUp]
        public void SetupFileScope() {
            this.OneTimeSetup();
            this.container = new TestContainer();
            this.container.Initialise(null);
        }

        [OneTimeTearDown]
        public void TeardownFileScope() {
            this.OneTimeTeardown();
        }

        [SetUp]
        public void SetupPerTest() {
            
        }

        [TearDown]
        public void TeardownPerTest() {
        }

        #endregion

        [Test]
        public void CheckInstanceTest() {
            InstanceFirst? f = null;
            InstanceFirst? s = null;

            TestHelpers.CatchUnexpected(() => {
                f = this.container.GetObjInstance<InstanceFirst>();
                s = this.container.GetObjInstance<InstanceFirst>();

            });

            Assert.IsNotNull(f);
            Assert.IsNotNull(s);
#pragma warning disable CS8602,CS8602
            Assert.AreNotEqual(f.InstanceID, s.InstanceID);
#pragma warning restore CS8602,CS8602
        }


        [Test]
        public void CheckSingleton_MultipleCallsForSameInstance() {
            SingleFirst? f = null;
            SingleFirst? s = null;
            TestHelpers.CatchUnexpected(() => {
                f = this.container.GetObjSingleton<SingleFirst>();
                s = this.container.GetObjSingleton<SingleFirst>();
            });
            Assert.IsNotNull(f);
            Assert.IsNotNull(s);
#pragma warning disable CS8602,CS8602
            Assert.AreEqual(f.InstanceID, s.InstanceID);
#pragma warning restore CS8602,CS8602
        }


        [Test]
        public void CheckSingleton_CallsForDiffSingletons() {
            SingleFirst? f1 = null;
            SingleFirst? f2 = null;
            SingleSecond? s1 = null;
            SingleSecond? s2 = null;


            TestHelpers.CatchUnexpected(() => {
                f1 = this.container.GetObjSingleton<SingleFirst>();
                f2 = this.container.GetObjSingleton<SingleFirst>();
                s1 = this.container.GetObjSingleton<SingleSecond>();
                s2 = this.container.GetObjSingleton<SingleSecond>();
            });
            Assert.IsNotNull(f1);
            Assert.IsNotNull(f2);
            Assert.IsNotNull(s1);
            Assert.IsNotNull(s2);

#pragma warning disable CS8602,CS8602
            Assert.AreEqual(f1.InstanceID, f2.InstanceID);
            Assert.AreEqual(s1.InstanceID, s2.InstanceID);
            Assert.AreNotEqual(f1.InstanceID, s2.InstanceID, "instance id of diff singletons");
#pragma warning restore CS8602,CS8602
        }


        [Test]
        public void CheckInstacesWithSingletonParamTest() {
            TstInsWithSingl? f = null;
            TstInsWithSingl? s = null;
            TestHelpers.CatchUnexpected(() => {
                f = this.container.GetObjInstance<TstInsWithSingl>();
                s = this.container.GetObjInstance<TstInsWithSingl>();
            });
            Assert.IsNotNull(f);
            Assert.IsNotNull(s);
#pragma warning disable CS8602,CS8602
            // Instance should have different instance count
            Assert.AreNotEqual(f.InstanceID, s.InstanceID);
            // They share a singleton parameter
            Assert.AreEqual(f.SinglClass.InstanceID, s.SinglClass.InstanceID);
#pragma warning restore CS8602,CS8602
        }


        [Test]
        public void CheckSingletonWithInstanceParamTest() {
            TstSinglWithIns? f = null;
            TstSinglWithIns? s = null;
            TestHelpers.CatchUnexpected(() => {
                f = this.container.GetObjSingleton<TstSinglWithIns>();
                s = this.container.GetObjSingleton<TstSinglWithIns>();
            });
            Assert.IsNotNull(f);
            Assert.IsNotNull(s);
#pragma warning disable CS8602,CS8602
            // Singletons should have same instance id
            Assert.AreEqual(f.InstanceID, s.InstanceID);
            // Although the parameter is instance, that secondary constructor only
            // called once on intantiation of parent singleton class
            Assert.AreEqual(f.InstClass.InstanceID, s.InstClass.InstanceID);
#pragma warning restore CS8602,CS8602
        }



        //TstSinglWithIns
        //TstInsWithSingl






    }





}

