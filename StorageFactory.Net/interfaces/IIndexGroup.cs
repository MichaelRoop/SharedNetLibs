namespace StorageFactory.Net.interfaces {


    /// <summary>An object to encapsulate the index file</summary>
    /// <typeparam name="TExtraInfo">The ExtraInfo</typeparam>
    public interface IIndexGroup<TExtraInfo> where TExtraInfo : class {

        List<IIndexItem<TExtraInfo>> Items { get; set; }

    }


}
