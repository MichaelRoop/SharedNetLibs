
namespace Common.Net.Network.interfaces {

    /// <summary>Cross platform property keys</summary>
    public interface INetPropertyKeys {
        string IsConnected { get; }
        string IsConnectable { get; }
        string CanPair { get; }
        string IsPaired { get; }
        string ContainerId { get; }
        string IconPath { get; }
        string GlyphIconPath { get; }
        string ItemNameDisplay { get; }

    }

}
