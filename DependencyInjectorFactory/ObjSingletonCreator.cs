﻿using ChkUtils.Net;

namespace DependencyInjectorFactory.Net {


    /// <summary>Returns a singleton of the object based on passed in constructor</summary>
    public class ObjSingletonCreator : ObjCreator {

        /// <summary>Holds the single instance created</summary>
        private object? singleton = null;


        public ObjSingletonCreator(Func<object> constructor) 
            : base(constructor) {
        }


        /// <summary>Return single instance of the object requested</summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <returns>A singleton of the requested object</returns>
        protected override T ReturnObj<T>() {
            if (this.singleton == null) {
                this.singleton = this.objBuilder();
                WrapErr.ChkVar(this.singleton, 9999, () => string.Format("Class {0} constructor returned a null object", typeof(T).Name));
            }
            T? result = this.singleton as T;
            WrapErr.ChkVar(result, 9999, () => string.Format("Singleton is type {0} rather than type {1}", 
                this.singleton.GetType().Name, typeof(T).Name));
            return result;
        }
    }
}
