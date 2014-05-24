///////////////////////////////////////
#region Namespace Directives

using CompUhaul.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

#endregion
///////////////////////////////////////

namespace CompUhaul.Test.Files
{
    [TestClass]
    public class fileManager_spec
    {
        ////////////////////////////////////////
        #region Constants

        const string _defaultApplicationFolder = "\\79fc21c2-767e-43da-aff1-48068d80de55";
        const string _defaultCompanyFolder = "\\(Company Unspecified)";
        const string _expectedCompanyFolder = "\\Nicola B. DiPalma";
        const string _expectedApplicationFolder = "\\CompUhaul";

        #endregion

        ////////////////////////////////////////
        #region Generic Fields

        private static string _defaultAppDataDirectory;

        #endregion

        ////////////////////////////////////////
        #region Constructor

        /// <summary>
        /// Test initialization.
        /// </summary>
        public fileManager_spec()
        {
            _defaultAppDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        #endregion

        ////////////////////////////////////////
        #region Unit Tests (Methods)

        // Constructor

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void SingleArgumentConstructor_NullAssembly_ExceptionThrown()
        {
            microManager manager = new microManager(null);
        }

        [ExpectedException(typeof(InvalidOperationException))] // from company folder since it's being retrieved first.
        [TestMethod]
        public void SingleArgumentConstructor_UnFilledAssemblyInfo_ExceptionThrown()
        {
            // initializes the file manager with the [unpopulated] assembly information for this test project.
            microManager manager = new microManager();
        }

        [TestMethod]
        public void SingleArgumentConstructor_FilledAssemblyInfo_ApplicationFolderGenerated()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager(Assembly.GetAssembly(typeof(fileManager)));
            string _expectedPath = _defaultAppDataDirectory + _expectedCompanyFolder + _expectedApplicationFolder;
            Assert.AreEqual(_expectedPath, manager.ApplicationFolderPath);
        }

        [TestMethod]
        public void SingleArgumentConstructor_FilledAssemblyInfo_CompanyFolderGenerated()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager(Assembly.GetAssembly(typeof(fileManager)));
            string _expectedPath = _defaultAppDataDirectory + _expectedCompanyFolder;
            Assert.AreEqual(_expectedPath, manager.CompanyFolderPath);
        }

        [TestMethod]
        public void TwoArgumentConstructor_NullApplicationFolder_ApplicationFolderNameIsAssemblyGuid()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager("Yesh", null);
            string _expectedPath = _defaultAppDataDirectory + "\\Yesh" + _defaultApplicationFolder;
            Assert.AreEqual(_expectedPath, manager.ApplicationFolderPath);
        }

        [TestMethod]
        public void TwoArgumentConstructor_NullCompanyFolder_CompanyFolderGenerated()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager(null, "Schtuff");
            string _expectedPath = _defaultAppDataDirectory + _defaultCompanyFolder;
            Assert.AreEqual(_expectedPath, manager.CompanyFolderPath);
        }

        [TestMethod]
        public void TwoArgumentConstructor_EmptyApplicationFolder_ApplicationFolderNameIsAssemblyGuid()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager("Yesh", String.Empty);
            string _expectedPath = _defaultAppDataDirectory + "\\Yesh" + _defaultApplicationFolder;
            Assert.AreEqual(_expectedPath, manager.ApplicationFolderPath);
        }

        [TestMethod]
        public void TwoArgumentConstructor_EmptyCompanyFolder_CompanyFolderGenerated()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager(String.Empty, "Schtuff");
            string _expectedPath = _defaultAppDataDirectory + _defaultCompanyFolder;
            Assert.AreEqual(_expectedPath, manager.CompanyFolderPath);
        }

        [TestMethod]
        public void ThreeArgumentConstructor_NullAppDataFolder_UseDefault()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager(null, "Schtuff", null);
            string _expectedPath = _defaultAppDataDirectory;
            Assert.AreEqual(_expectedPath, manager.AppDataPath);
        }

        [TestMethod]
        public void ThreeArgumentConstructor_EmptyAppDataFolder_UseDefault()
        {
            // initializes the file manager with the [populated] assembly information for the CompUhaul project.
            microManager manager = new microManager(String.Empty, "Schtuff", String.Empty);
            string _expectedPath = _defaultAppDataDirectory;
            Assert.AreEqual(_expectedPath, manager.AppDataPath);
        }

        #endregion

        ////////////////////////////////////////
        #region Child Classes (Used in Testing)

        class microManager : fileManager
        {
            public microManager() : base() { }
            public microManager(Assembly _assembly) : base(_assembly) { }
            public microManager(string company, string appName) : base(company, appName) { }
            public microManager(string appData, string company, string appName) : base(appData, company, appName) { }
        }

        #endregion
    }
}
