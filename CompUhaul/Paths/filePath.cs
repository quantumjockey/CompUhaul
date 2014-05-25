///////////////////////////////////////
#region Namespace Directives

using System.IO;

#endregion
///////////////////////////////////////

namespace CompUhaul.Paths
{
    public class filePath : path
    {
        ////////////////////////////////////////
        #region Constructor

        public filePath(string specifiedPath) : base(specifiedPath) { }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        protected override bool CheckIfPathExists(string path)
        {
            return File.Exists(path);
        }

        #endregion
    }
}
