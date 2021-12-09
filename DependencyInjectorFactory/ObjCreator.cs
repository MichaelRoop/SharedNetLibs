using ChkUtils.Net;

namespace DependencyInjectorFactory.Net {

    /// <summary>Base class to create and object from its stored constructor</summary>
    public abstract class ObjCreator {

        /// <summary>pointer to the object constructor</summary>
        protected Func<object> objBuilder;

        #region Constructors

        public ObjCreator(Func<object> constructor) {
            WrapErr.ChkVar(constructor, 9999, "Constructor passed in is null");
            this.objBuilder = constructor;
        }

        #endregion

        #region Public

        public T GetObj<T>() where T : class {
            T? obj = WrapErr.ToErrorReportException(9999,
                () => string.Format("Constructor for class {0} failed", typeof(T).Name),
                () => { return this.ReturnObj<T>(); });
            return obj;
        }

        #endregion

        #region Abstract

        /// <summary>Returns the object singleton or instance depending on override</summary>
        /// <typeparam name="T">The object to return</typeparam>
        /// <returns>The object corresponding to the constructor pointer passed in</returns>
        protected abstract T ReturnObj<T>() where T : class;

        #endregion




    }
}
