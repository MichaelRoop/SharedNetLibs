
namespace DependencyInjectorFactory.Net.interfaces {

    /// <summary>
    /// Interface for a simple multi-platform Dependency injector
    /// </summary>
    public interface IObjContainer {

        /// <summary>Initialise the object creator</summary>
        /// <param name="osObjCreators">
        /// The list of OS specific object creators from derived classes
        /// </param>
        void Initialise(IObjExtraCreators osObjCreators = null);


        /// <summary>Get an instance of the requested object</summary>
        /// <typeparam name="T">The type of object requested</typeparam>
        /// <returns>An instance of the object</returns>
        T GetObjInstance<T>() where T : class;


        /// <summary>Get a reference to the unique instance of the requested object</summary>
        /// <typeparam name="T">The type of object requested</typeparam>
        /// <returns>Reference to the unique instance of the object</returns>
        T GetObjSingleton<T>() where T : class;

    }
}
