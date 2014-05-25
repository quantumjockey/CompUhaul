///////////////////////////////////////
#region Namespace Directives

using System.IO;

#endregion
///////////////////////////////////////

namespace CompUhaul.Paths
{
    public class folderPath : path
    {
        ////////////////////////////////////////
        #region Constructor

        public folderPath(string specifiedPath) : base(specifiedPath) { }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        protected override bool CheckIfPathExists(string path)
        {
            return Directory.Exists(path);
        }

        #endregion
    }
}
