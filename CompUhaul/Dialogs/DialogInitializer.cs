///////////////////////////////////////
#region Namespace Directives

using System;
using System.IO;
using System.Windows.Forms;

#endregion
///////////////////////////////////////

namespace CompUhaul.Dialogs
{
    /// <summary>
    /// Implements methods that allow a developer to quickly initialize basic FileDialog objects.
    /// </summary>
    public class DialogInitializer
    {
        ////////////////////////////////////////
        #region Constants

        const string _allFilesFilter = "All files (*.*)|*.*";
        const string _defaultTitle = "Please Select a File";

        #endregion

        ////////////////////////////////////////
        #region Generic Fields

        private static string _defaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        #endregion

        ////////////////////////////////////////
        #region Initialization

        /// <summary>
        /// Initializes a basic FolderBrowserDialog object.
        /// </summary>
        /// <param name="_fileExtension"></param>
        /// <param name="_filter"></param>
        /// <param name="_initialDirectory"></param>
        /// <param name="_title"></param>
        /// <returns>A partially initialized file dialog object.</returns>
        public static FolderBrowserDialog InitializeFolderBrowserDialog(string _description, bool _showNewFolderButton)
        {
            FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
            _folderBrowserDialog.ShowNewFolderButton = _showNewFolderButton;
            _folderBrowserDialog.Description = _description;
            return _folderBrowserDialog;
        }

        /// <summary>
        /// Initializes a basic OpenFileDialog object.
        /// </summary>
        /// <param name="_fileExtension"></param>
        /// <param name="_filter"></param>
        /// <param name="_initialDirectory"></param>
        /// <param name="_title"></param>
        /// <returns>A partially initialized file dialog object.</returns>
        public static OpenFileDialog InitializeOpenFromFileDialog(string _fileExtension, string _initialDirectory, string _title)
        {
            OpenFileDialog _openFromFileDialog = new OpenFileDialog();
            _openFromFileDialog.DefaultExt = _fileExtension;
            _openFromFileDialog.Filter = CreateFileFilter(_fileExtension);
            _openFromFileDialog.InitialDirectory = CheckIfDirectoryExists(_initialDirectory);
            _openFromFileDialog.Title = CheckIfTitleIsValid(_title);
            return _openFromFileDialog;
        }

        /// <summary>
        /// Initializes a basic SaveFileDialog object.
        /// </summary>
        /// <param name="_fileExtension"></param>
        /// <param name="_filter"></param>
        /// <param name="_initialDirectory"></param>
        /// <param name="_title"></param>
        /// <returns>A partially initialized file dialog object.</returns>
        public static SaveFileDialog InitializeSaveToFileDialog(string _fileExtension, string _initialDirectory, string _title)
        {
            SaveFileDialog _saveToFileDialog = new SaveFileDialog();
            _saveToFileDialog.DefaultExt = _fileExtension;
            _saveToFileDialog.Filter = CreateFileFilter(_fileExtension);
            _saveToFileDialog.InitialDirectory = CheckIfDirectoryExists(_initialDirectory);
            _saveToFileDialog.Title = CheckIfTitleIsValid(_title);
            return _saveToFileDialog;
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        /// <summary>
        /// Checks whether or not the specified directory is valid. If it isn't, it inserts an Environment.SpecialFolder path.
        /// </summary>
        /// <param name="_directory"></param>
        /// <returns></returns>
        private static string CheckIfDirectoryExists(string _directory)
        {
            return (Directory.Exists(_directory)) ? _directory : _defaultDirectory;
        }

        /// <summary>
        /// Checks whether or not the specified title is valid.  If it isn't, it inserts a default one.
        /// </summary>
        /// <param name="_title"></param>
        /// <returns></returns>
        private static string CheckIfTitleIsValid(string _title)
        {
            return (!String.IsNullOrEmpty(_title)) ? _title : _defaultTitle;
        }

        /// <summary>
        /// Creates a file filter string for use with file dialogs.
        /// </summary>
        /// <param name="_extension"></param>
        /// <returns>A properly formatted file filter.</returns>
        private static string CreateFileFilter(string _extension)
        {
            return (!String.IsNullOrEmpty(_extension)) ? ("(*" + _extension + ")|*" + _extension) : (_allFilesFilter);
        }

        #endregion
    }
}
