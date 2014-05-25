///////////////////////////////////////
#region Namespace Directives

// none

#endregion
///////////////////////////////////////

namespace CompUhaul.Paths
{
    /// <summary>
    /// Template for constructing path validation classes.
    /// </summary>
    public interface Ipath
    {
        // Member Signatures
        bool Exists { get; }
        string FullPath { get; }

        // Method Signatures
        string[] GetHeirarchy();
    }
}
