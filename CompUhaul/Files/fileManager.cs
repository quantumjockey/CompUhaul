///////////////////////////////////////
#region Namespace Directives

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

#endregion
///////////////////////////////////////

namespace CompUhaul.Files
{
    /// <summary>
    /// Implements a file management framework for an application with path names either specified by the 
    /// developer or generated from assembly data. Since only functionality common to most file management 
    /// systems is implemented, this class must be inherited as a base so that A more complete framework of
    /// application files and folders can be built on top.
    /// </summary>
    /// <remarks>
    /// Before making use of the single argument constructor for this class, make sure that the assembly 
    /// information for the application you're developing is filled in. You can access the dialog associated 
    /// with this by right-clicking the project file, then going through the context menu to: 
    /// Properties > Application (tab) > Assembly Information (button)
    /// </remarks>
    public abstract class fileManager : IfileManager
    {
        ////////////////////////////////////////
        #region Constants

        const string _defaultCompanyFolderName = "(Company Unspecified)";
        const string _pathPrefix = "\\";

        #endregion

        ////////////////////////////////////////
        #region Application Path Components

        // App file folders
        protected string _applicationFolder;
        protected string _companyFolder;

        // Generic app files path
        protected string _appDataPath;

        #endregion

        ////////////////////////////////////////
        #region Members

        /// <summary>
        /// Indicates the generic folder dedicated to storing application data on the user's machine (operating system dependent).
        /// </summary>
        public string AppDataPath
        {
            get
            {
                return _appDataPath;
            }
        }

        /// <summary>
        /// The application-named folder and prefix.
        /// </summary>
        public string ApplicationFolder
        {
            get
            {
                return _pathPrefix + _applicationFolder;
            }
        }

        /// <summary>
        /// The full path of the application-named folder.
        /// </summary>
        public string ApplicationFolderPath
        {
            get
            {
                string path = _appDataPath + CompanyFolder + ApplicationFolder;
                EnsureDirectoryExists(path);
                return path;
            }
        }

        /// <summary>
        /// The company-named folder and prefix.
        /// </summary>
        public string CompanyFolder
        {
            get
            {
                return _pathPrefix + _companyFolder;
            }
        }

        /// <summary>
        /// The full path of the company-named folder.
        /// </summary>
        public string CompanyFolderPath
        {
            get
            {
                string path = _appDataPath + CompanyFolder;
                EnsureDirectoryExists(path);
                return path;
            }
        }

        /// <summary>
        /// String representing the directory separator in C#.
        /// </summary>
        public string PathSeparator
        {
            get
            {
                return _pathPrefix;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructor

        /// <summary>
        /// Creates a new file manager for the calling application.
        /// </summary>
        public fileManager() : this(Assembly.GetCallingAssembly()) { }

        /// <summary>
        /// Creates a new file manager for the specified application.
        /// </summary>
        /// <param name="_appAssembly">The application assembly for which file management is needed.</param>
        public fileManager(Assembly _appAssembly)
        {
            _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _companyFolder = GetCompanyFolderName(_appAssembly);
            _applicationFolder = GetApplicationFolderName(_appAssembly);
        }

        /// <summary>
        /// Creates a new file manager with the specified components.
        /// </summary>
        /// <param name="companyFolderName">The name of the company or organization developing the associated application.</param>
        /// <param name="applicationFolderName">The name of the associated application.</param>
        public fileManager(string companyFolderName, string applicationFolderName)
            : this(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), companyFolderName, applicationFolderName) { }

        /// <summary>
        /// Creates a new file manager with the specified components.
        /// </summary>
        /// <param name="genericAppDataPath">The name of the path withi which all other application files are being stored.</param>
        /// <param name="companyFolderName">The name of the company or organization developing the associated application.</param>
        /// <param name="applicationFolderName">The name of the associated application.</param>
        public fileManager(string genericAppDataPath, string companyFolderName, string applicationFolderName)
        {
            _appDataPath = (!String.IsNullOrEmpty(genericAppDataPath)) ? genericAppDataPath : Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _companyFolder = (!String.IsNullOrEmpty(companyFolderName)) ? companyFolderName : _defaultCompanyFolderName;
            _applicationFolder = (!String.IsNullOrEmpty(applicationFolderName)) ? applicationFolderName : GenerateApplicationFolderFromGuid();
        }

        #endregion

        ////////////////////////////////////////
        #region Folder Retrieval

        /// <summary>
        /// Generates the application folder path associated with the specified assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public string GetApplicationFolderName(Assembly assembly)
        {
            string temp = assembly.GetName().Name.Trim();
            if (String.IsNullOrEmpty(temp))
            {
                throw new InvalidOperationException("Application name invalid. Please add a valid application name to the assembly manifest.");
            }
            else
            {
                return temp;
            }
        }

        /// <summary>
        /// Generates the company folder path associated with the specified assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public string GetCompanyFolderName(Assembly assembly)
        {
            string temp = FileVersionInfo.GetVersionInfo(assembly.Location).CompanyName.Trim();
            if (String.IsNullOrEmpty(temp))
            {
                throw new InvalidOperationException("No company name on record. Please add a valid company name to the assembly manifest.");
            }
            else
            {
                return temp;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        /// <summary>
        /// Checks whether or not the specified path exists, and creates it if it doesn't.
        /// </summary>
        /// <param name="_path">Path to check.</param>
        protected void EnsureDirectoryExists(string _path)
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }

        /// <summary>
        /// Retrieves the explicitly defined System.Guid object for this class.
        /// </summary>
        /// <returns>A string containing the explicitly defined System.Guid object.</returns>
        private string GenerateApplicationFolderFromGuid()
        {
            GuidAttribute assemblyGuidInfo = (GuidAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true))[0];
            return assemblyGuidInfo.Value;
        }

        #endregion
    }
}
