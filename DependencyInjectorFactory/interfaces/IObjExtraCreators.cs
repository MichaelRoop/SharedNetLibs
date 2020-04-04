using System;
using System.Collections.Generic;

namespace DependencyInjectorFactory.interfaces {

    /// <summary>Holds extra creators with OS specific class implementations</summary>
    public interface IObjExtraCreators {

        /// <summary>Dictionary of instance creators</summary>
        Dictionary<Type,ObjCreator> InstanceCreators { get; }


        /// <summary>Dictionary of singleton creators</summary>
        Dictionary<Type, ObjCreator> SingletonCreators { get; }

    }
}
