///////////////////////////////////////
#region Namespace Directives

using System;
using System.Reflection;

#endregion
///////////////////////////////////////

namespace CompUhaul.Files
{
    /// <summary>
    /// Template for implementing an application-specific file management framework.
    /// </summary>
    interface IfileManager
    {
        // Member Signatures
        string AppDataPath { get; }
        string ApplicationFolder { get; }
        string ApplicationFolderPath { get; }
        string CompanyFolder { get; }
        string CompanyFolderPath { get; }
        string PathSeparator { get; }

        // Method Signatures
        string GetApplicationFolderName(Assembly assembly);
        string GetCompanyFolderName(Assembly assembly);
    }
}
