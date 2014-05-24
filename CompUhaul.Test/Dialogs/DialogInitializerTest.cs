///////////////////////////////////////
#region Namespace Directives

using CompUhaul.Dialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

#endregion
///////////////////////////////////////

namespace CompUhaul.Test.Dialogs
{
    [TestClass]
    public class DialogInitializerTest
    {
        ////////////////////////////////////////
        #region Constants

        const string _allFilesFilter = "All files (*.*)|*.*";
        const string _defaultTitle = "Please Select a File";

        #endregion

        ////////////////////////////////////////
        #region Generic Fields

        private static string _defaultDirectory;

        #endregion

        ////////////////////////////////////////
        #region Constructor

        /// <summary>
        /// Test initialization.
        /// </summary>
        public DialogInitializerTest()
        {
            _defaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        #endregion

        ////////////////////////////////////////
        #region Unit Tests (Methods)

        // OpenFileDialog InitializeOpenFromFileDialog(string _fileExtension, string _initialDirectory, string _title);

        [TestMethod]
        public void InitializeOpenFromFileDialog_NullFileExtension_FilterIsAllFileExtensions()
        {
            OpenFileDialog dialog = DialogInitializer.InitializeOpenFromFileDialog(null, null, "Kashyyk");
            Assert.AreEqual(dialog.Filter, _allFilesFilter);
        }

        [TestMethod]
        public void InitializeOpenFromFileDialog_EmptyFileExtension_FilterIsAllFileExtensions()
        {
            OpenFileDialog dialog = DialogInitializer.InitializeOpenFromFileDialog(String.Empty, null, "Arrakis");
            Assert.AreEqual(dialog.Filter, _allFilesFilter);
        }

        [TestMethod]
        public void InitializeOpenFromFileDialog_NullInitialDirectory_DefaultsToMyDocuments()
        {
            OpenFileDialog dialog = DialogInitializer.InitializeOpenFromFileDialog(null, null, "Omicron Persei");
            Assert.AreEqual(dialog.Filter, _allFilesFilter);
        }

        [TestMethod]
        public void InitializeOpenFromFileDialog_EmptyInitialDirectory_DefaultsToMyDocuments()
        {
            OpenFileDialog dialog = DialogInitializer.InitializeOpenFromFileDialog(String.Empty, String.Empty, "Romulus");
            Assert.AreEqual(dialog.Filter, _allFilesFilter);
        }

        [TestMethod]
        public void InitializeOpenFromFileDialog_NullTitle_DefaultTitle()
        {
            OpenFileDialog dialog = DialogInitializer.InitializeOpenFromFileDialog(null, null, null);
            Assert.AreEqual(dialog.Title, _defaultTitle);
        }

        [TestMethod]
        public void InitializeOpenFromFileDialog_EmptyTitle_DefaultTitle()
        {
            OpenFileDialog dialog = DialogInitializer.InitializeOpenFromFileDialog(String.Empty, String.Empty, String.Empty);
            Assert.AreEqual(dialog.Title, _defaultTitle);
        }

        // SaveFileDialog InitializeSaveToFileDialog(string _fileExtension, string _initialDirectory, string _title)

        [TestMethod]
        public void InitializeSaveToFileDialog_NullFileExtension_FilterIsAllFileExtensions()
        {
            SaveFileDialog dialog = DialogInitializer.InitializeSaveToFileDialog(null, null, "Corvo");
            Assert.AreEqual(dialog.InitialDirectory, _defaultDirectory);
        }

        [TestMethod]
        public void InitializeSaveToFileDialog_EmptyFileExtension_FilterIsAllFileExtensions()
        {
            SaveFileDialog dialog = DialogInitializer.InitializeSaveToFileDialog(String.Empty, null, "Altair");
            Assert.AreEqual(dialog.InitialDirectory, _defaultDirectory);
        }

        [TestMethod]
        public void InitializeSaveToFileDialog_NullInitialDirectory_DefaultsToMyDocuments()
        {
            SaveFileDialog dialog = DialogInitializer.InitializeSaveToFileDialog(null, null, "Fisher");
            Assert.AreEqual(dialog.InitialDirectory, _defaultDirectory);
        }

        [TestMethod]
        public void InitializeSaveToFileDialog_EmptyInitialDirectory_DefaultsToMyDocuments()
        {
            SaveFileDialog dialog = DialogInitializer.InitializeSaveToFileDialog(String.Empty, String.Empty, "Faith");
            Assert.AreEqual(dialog.InitialDirectory, _defaultDirectory);
        }

        [TestMethod]
        public void InitializeSaveToFileDialog_NullTitle_DefaultTitle()
        {
            SaveFileDialog dialog = DialogInitializer.InitializeSaveToFileDialog(null, null, null);
            Assert.AreEqual(dialog.Title, _defaultTitle);
        }

        [TestMethod]
        public void InitializeSaveToFileDialog_EmptyTitle_DefaultTitle()
        {
            SaveFileDialog dialog = DialogInitializer.InitializeSaveToFileDialog(String.Empty, String.Empty, String.Empty);
            Assert.AreEqual(dialog.Title, _defaultTitle);
        }

        #endregion

        ////////////////////////////////////////
        #region Child Classes (Used in Testing)



        #endregion
    }
}
