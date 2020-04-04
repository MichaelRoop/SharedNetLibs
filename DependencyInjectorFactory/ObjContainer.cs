using ChkUtils.Net;
using DependencyInjectorFactory.interfaces;
using System;
using System.Collections.Generic;

namespace DependencyInjectorFactory {

    public abstract class ObjContainer : IObjContainer {

        #region Data

        /// <summary>Dictionary of multi instance object creators</summary>
        private Dictionary<Type, ObjCreator> instanceCreators = new Dictionary<Type, ObjCreator>();

        /// <summary>Dictionary of single instance object creators</summary>
        private Dictionary<Type, ObjCreator> singletonCreators = new Dictionary<Type, ObjCreator>();

        #endregion

        #region Constructors

        public ObjContainer() {}

        #endregion

        #region IObjContainer methods

        /// <summary>Initialise the object creator</summary>
        /// <param name="osObjCreators">List of OS specific object creators</param>
        /// <remarks>
        /// You can build a cross platform set with the abstract methods in 
        /// the derived class. Then you can use that derived class and pass
        /// in the OS specific extra types when compiling under that OS
        /// </remarks>
        public void Initialise(IObjExtraCreators osObjCreators = null) {
            // should only call once but will clear just in case
            this.instanceCreators.Clear();
            this.singletonCreators.Clear();

            // Load in any OS specific objects from derived container class constructors
            if (osObjCreators != null) {
                foreach (var o in osObjCreators.InstanceCreators) {
                    this.instanceCreators.Add(o.Key, o.Value);
                }
                foreach (var o in osObjCreators.SingletonCreators) {
                    this.singletonCreators.Add(o.Key, o.Value);
                }
            }
            // Load in classes from derived container classes.
            this.LoadCreators(this.instanceCreators, this.singletonCreators);
        }


        /// <summary>Get an instance of the requested object</summary>
        /// <typeparam name="T">The type of object requested</typeparam>
        /// <returns>An instance of the object</returns>
        public T GetObjInstance<T>() where T : class {
            WrapErr.ChkTrue(this.HasObjInstanceCreator<T>(), 9999, 
                () => string.Format("No class {0} in instance container", typeof(T).Name));
            return this.instanceCreators[typeof(T)].GetObj<T>();
        }


        /// <summary>Get a reference to the unique instance of the requested object</summary>
        /// <typeparam name="T">The type of object requested</typeparam>
        /// <returns>Reference to the unique instance of the object</returns>
        public T GetObjSingleton<T>() where T : class {
            WrapErr.ChkTrue(this.HasObjSingletonCreator<T>(), 9999,
                () => string.Format("No class {0} in singleton container", typeof(T).Name));
            return this.singletonCreators[typeof(T)].GetObj<T>();
        }

        #endregion

        #region Abstract methods

        /// <summary>Load all the instances</summary>
        /// <param name="instanceCreators">The instance creator dictionary</param>
        /// <param name="singletonCreators">The singleton creator dictionary</param>
        protected abstract void LoadCreators(
            Dictionary<Type, ObjCreator> instanceCreators, 
            Dictionary<Type, ObjCreator> singletonCreators);

        #endregion

        #region Private

        bool HasObjInstanceCreator<T>() {
            return this.instanceCreators.ContainsKey(typeof(T));
        }


        bool HasObjSingletonCreator<T>() {
            return this.singletonCreators.ContainsKey(typeof(T));
        }

        #endregion

    }
}
