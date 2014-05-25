///////////////////////////////////////
#region Namespace Directives

using CompUhaul.Paths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

#endregion
///////////////////////////////////////

namespace CompUhaul.Test.Paths
{
    [TestClass]
    public class path_spec
    {
        ////////////////////////////////////////
        #region Constants

        const string testDirectory = @"D:\Visual C# Application Source\Libraries\CompUhaul\CompUhaul\Paths";
        const string testFile = @"D:\Visual C# Application Source\Libraries\CompUhaul\CompUhaul\Paths\path.cs";

        #endregion

        ////////////////////////////////////////
        #region Unit Tests (Methods)

        // Constructor

        [TestMethod]
        public void Constructor_PathInvalid_ExistsIsFalse()
        {
            path stuff = new path(null);
            Assert.IsFalse(stuff.Exists);
        }

        [TestMethod]
        public void Constructor_ValidDirectory_ExistsIsTrue()
        {
            path stuff = new path(testDirectory);
            Assert.IsTrue(stuff.Exists);
        }

        [TestMethod]
        public void Constructor_ValidFile_ExistsIsTrue()
        {
            path stuff = new path(testFile);
            Assert.IsTrue(stuff.Exists);
        }

        // GetHeirarchy

        [TestMethod]
        public void GetHeirarchy_ValidDirectory_PathParsed()
        {
            string[] parsed = new string[]{
                @"D:",
                @"D:\Visual C# Application Source",
                @"D:\Visual C# Application Source\Libraries",
                @"D:\Visual C# Application Source\Libraries\CompUhaul",
                @"D:\Visual C# Application Source\Libraries\CompUhaul\CompUhaul",
                @"D:\Visual C# Application Source\Libraries\CompUhaul\CompUhaul\Paths"
            };

            path stuff = new path(testDirectory);
            CollectionAssert.AreEqual(parsed, stuff.GetHeirarchy());
        }

        [TestMethod]
        public void GetHeirarchy_ValidFile_PathParsed()
        {
            string[] parsed = new string[]{
                @"D:",
                @"D:\Visual C# Application Source",
                @"D:\Visual C# Application Source\Libraries",
                @"D:\Visual C# Application Source\Libraries\CompUhaul",
                @"D:\Visual C# Application Source\Libraries\CompUhaul\CompUhaul",
                @"D:\Visual C# Application Source\Libraries\CompUhaul\CompUhaul\Paths",
                @"D:\Visual C# Application Source\Libraries\CompUhaul\CompUhaul\Paths\path.cs"
            };

            path stuff = new path(testFile);
            CollectionAssert.AreEqual(parsed, stuff.GetHeirarchy());
        }

        #endregion
    }
}
