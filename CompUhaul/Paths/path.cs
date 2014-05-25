///////////////////////////////////////
#region Namespace Directives

using System.Collections.Generic;
using System.IO;

#endregion
///////////////////////////////////////

namespace CompUhaul.Paths
{
    public class path
    {
        ////////////////////////////////////////
        #region Generic Fields

        string _fullPath;

        #endregion

        ////////////////////////////////////////
        #region Properties

        public bool Exists
        {
            get { return CheckIfPathExists(_fullPath); }
        }

        public string FullPath
        {
            get { return _fullPath; }
            private set { _fullPath = value; }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructor

        public path(string specifiedPath)
        {
            FullPath = specifiedPath;
        }

        #endregion

        ////////////////////////////////////////
        #region Public Methods

        /// <summary>
        /// Returns the complete heiarchy from the file or directory specified down to the drive path.
        /// </summary>
        /// <returns>Array containing sequential paths leading to the specified path.</returns>
        public string[] GetHeirarchy()
        {
            char pathSeparator = '\\';
            List<string> heirarchy = new List<string>();

            string[] partials = FullPath.Split(pathSeparator);

            for (int i = 0; i < partials.Length; i++)
                if (i > 0)
                    heirarchy.Add(heirarchy[i - 1] + pathSeparator + partials[i]);
                else
                    heirarchy.Add(partials[i]);

            return heirarchy.ToArray();
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        private bool CheckIfPathExists(string path)
        {
            if (File.Exists(path) || Directory.Exists(path))
                return true;
            else
                return false;
        }

        #endregion
    }
}
