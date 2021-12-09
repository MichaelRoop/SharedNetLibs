using ChkUtils.Net;

namespace DependencyInjectorFactory.Net {

    /// <summary>Uses the stored pointer to the constructor to build an object</summary>
    public class ObjInstanceCreator : ObjCreator {

        /// <summary>Constructor</summary>
        /// <param name="constructor">Pointer to the constructor</param>
        public ObjInstanceCreator(Func<object> constructor) : base(constructor) {
        }


        /// <summary>Use pointer to constructor to build a new instance</summary>
        /// <typeparam name="T">The type of object to return</typeparam>
        /// <returns>Returns an instance of the object</returns>
        protected override T ReturnObj<T>() {
            // TODO - need to revisit this
            T? result = this.objBuilder.Invoke() as T;
            WrapErr.ChkVar(result, 9999, () => string.Format("Class {0} constructor returned a null object", typeof(T).Name));
            return result;
        }
    }
}
