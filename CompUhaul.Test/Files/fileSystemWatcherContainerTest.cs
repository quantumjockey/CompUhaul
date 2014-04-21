///////////////////////////////////////
#region Namespace Directives

using CompUhaul.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

#endregion
///////////////////////////////////////

namespace CompUhaul.Test.Files
{
    /// <summary>
    /// Unit tests addressing functionality within the "CompUhaul.Files.fileSystemWatcherContainer" class.
    /// </summary>
    [TestClass]
    public class fileSystemWatcherContainerTest
    {
        ////////////////////////////////////////
        #region Constants

        const string _allFilesFilter = "All files (*.*)|*.*";

        #endregion

        ////////////////////////////////////////
        #region Generic Fields

        private string _testPath;

        #endregion

        ////////////////////////////////////////
        #region Constructor

        /// <summary>
        /// Initialize test conditions.
        /// </summary>
        public fileSystemWatcherContainerTest()
        {
            _testPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        #endregion

        ////////////////////////////////////////
        #region TestContext Components (Auto-Generated)

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Unit Tests (Methods)

        // Constructor

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Constructor_NullPath_ExceptionThrown()
        {
            fileSystemWatcherContainer container =
                new fileSystemWatcherContainer(null, "Text Files | *.txt", (x, y) => WorkinOnTheRailroad(x, y), (x, y) => AllTheLiveLongDay(x, y));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Constructor_EmptyPath_ExceptionThrown()
        {
            fileSystemWatcherContainer container =
                new fileSystemWatcherContainer(String.Empty, "Text Files | *.txt", (x, y) => WorkinOnTheRailroad(x, y), (x, y) => AllTheLiveLongDay(x, y));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Constructor_InvalidPath_ExceptionThrown()
        {
            fileSystemWatcherContainer container = new fileSystemWatcherContainer("X:\\", "Text Files | *.txt", (x, y) => WorkinOnTheRailroad(x, y), (x, y) => AllTheLiveLongDay(x, y));
        }

        [TestMethod]
        public void Constructor_FilterIsNull_DefaultFilterToAllFiles()
        {
            fileSystemWatcherContainer container = new fileSystemWatcherContainer(_testPath, null, (x, y) => WorkinOnTheRailroad(x, y), (x, y) => AllTheLiveLongDay(x, y));
            Assert.AreEqual(_allFilesFilter, container.ExtensionsFiltered);
        }

        [TestMethod]
        public void Constructor_FilterIsEmpty_DefaultFilterToAllFiles()
        {
            fileSystemWatcherContainer container = new fileSystemWatcherContainer(_testPath, String.Empty, (x, y) => WorkinOnTheRailroad(x, y), (x, y) => AllTheLiveLongDay(x, y));
            Assert.AreEqual(_allFilesFilter, container.ExtensionsFiltered);
        }

        #endregion

        ////////////////////////////////////////
        #region Dummy Methods

        private void WorkinOnTheRailroad(string path, string changeType)
        {
            // Sounds tiring.
        }

        private void AllTheLiveLongDay(string oldPath, string newPath)
        {
            // No Dinah here.
        }

        #endregion
    }
}
