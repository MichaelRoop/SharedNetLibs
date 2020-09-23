using DependencyInjectorFactory.Net;
using DependencyInjectorFactory.Net.interfaces;
using LogUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCases.Core;

namespace TestCases.DependencyInjectorTests {

    [TestFixture]
    public class DITests : TestCaseBase {

        #region Data

        public class TestInstClassBase {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public int Count { get; protected set; }

            public static int Counter { get; set; }

            public TestInstClassBase() {
                this.Count = (Counter++);
            }
        };

        public class TestSinglClassBase {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public int Count { get; protected set; }

            public static int Counter { get; set; }

            public TestSinglClassBase() {
                this.Count = (Counter++);
            }
        };

        #region Simple classes
        public class SingleFirst : TestInstClassBase { };
        public class SingleSecond : TestInstClassBase { };

        public class InstanceFirst : TestSinglClassBase { public InstanceFirst() : base() { } };
        public class InstanceSecond : TestSinglClassBase { public InstanceSecond() : base() { } };
        #endregion


        public class TstSinglWithIns {
            public InstanceFirst InstClass { get; private set; } = null;
            public int Count { get; protected set; }
            private static int counter = 0;

            public TstSinglWithIns(InstanceFirst cl) {
                this.InstClass = cl;
                this.Count = (counter++);
            }
        }

        public class TstInsWithSingl {
            public SingleFirst SinglClass { get; private set; } = null;
            public int Count { get; protected set; }
            private static int counter = 0;

            public TstInsWithSingl(SingleFirst cl) {
                this.SinglClass = cl;
                this.Count = (counter++);
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

        IObjContainer container = null;

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
            InstanceFirst f = null;
            InstanceFirst s = null;

            TestHelpersNet.CatchUnexpected(() => {
                f = this.container.GetObjInstance<InstanceFirst>();
                s = this.container.GetObjInstance<InstanceFirst>();

            });
            Assert.AreNotEqual(f.Count, s.Count);
        }


        [Test]
        public void CheckSingletonTest() {
            SingleFirst f = null;
            SingleFirst s = null;
            TestHelpersNet.CatchUnexpected(() => {
                f = this.container.GetObjSingleton<SingleFirst>();
                s = this.container.GetObjSingleton<SingleFirst>();
            });
            Assert.AreEqual(f.Count, s.Count);
        }


        [Test]
        public void CheckInstacesWithSingletonParamTest() {
            TstInsWithSingl f = null;
            TstInsWithSingl s = null;
            TestHelpersNet.CatchUnexpected(() => {
                f = this.container.GetObjInstance<TstInsWithSingl>();
                s = this.container.GetObjInstance<TstInsWithSingl>();
            });
            // Instance should have different instance count
            Assert.AreNotEqual(f.Count, s.Count);
            // They share a singleton parameter
            Assert.AreEqual(f.SinglClass.Count, s.SinglClass.Count);
        }


        [Test]
        public void CheckSingletonWithInstanceParamTest() {
            TstSinglWithIns f = null;
            TstSinglWithIns s = null;
            TestHelpersNet.CatchUnexpected(() => {
                f = this.container.GetObjSingleton<TstSinglWithIns>();
                s = this.container.GetObjSingleton<TstSinglWithIns>();
            });
            // Singletons should have different instance count
            Assert.AreEqual(f.Count, s.Count);
            // Although the parameter is instance, that secondary constructor only
            // called once on intantiation of parent singleton class
            Assert.AreEqual(f.InstClass.Count, s.InstClass.Count);
        }



        //TstSinglWithIns
        //TstInsWithSingl






    }





}

