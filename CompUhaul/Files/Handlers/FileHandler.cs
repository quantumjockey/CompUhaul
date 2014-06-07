///////////////////////////////////////
#region Namespace Directives

using CompUhaul.Paths;

#endregion
///////////////////////////////////////

namespace CompUhaul.Files.Handlers
{
    public abstract class FileHandler
    {
        ////////////////////////////////////////
        #region Fields

        protected filePath _dataFile;

        #endregion

        ////////////////////////////////////////
        #region Constructor

        public FileHandler(string _fullPath)
        {
            _dataFile = new filePath(_fullPath);
        }

        #endregion
    }
}
