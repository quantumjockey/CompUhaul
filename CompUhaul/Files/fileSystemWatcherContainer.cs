///////////////////////////////////////
#region Namespace Directives

using System;
using System.IO;
using System.Security.Permissions;

#endregion
///////////////////////////////////////

namespace CompUhaul.Files
{
    /// <summary>
    /// Implements a wrapper for System.IO.FileSystemWatcher event handlers that allows a user to map functions to
    /// event handlers in one line of code.
    /// </summary>
    /// <remarks>
    /// Most of the code in this wrapper is either taken directly or derived from examples articulated within
    /// < http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher(v=vs.110).aspx > as last accessed on 4/20/2014, 
    /// and is an attempt at encapsulating them in a manner that makes their implementations faster and simpler.
    /// </remarks>
    public class fileSystemWatcherContainer
    {
        ////////////////////////////////////////
        #region Constants

        const string _defaultFilter = "All files (*.*)|*.*";

        #endregion

        ////////////////////////////////////////
        #region Generic Fields

        private Action<string, string> _onChangedFunction;
        private Action<string, string> _onRenamedFunction;
        private FileSystemWatcher _watcher;

        #endregion

        ////////////////////////////////////////
        #region Members

        /// <summary>
        /// Indicates the file extension(s) filtered for changes within the target directory.
        /// </summary>
        public string ExtensionsFiltered
        {
            get
            {
                return _watcher.Filter;
            }
        }

        /// <summary>
        /// The full path of the directory being monitored by the application
        /// </summary>
        public string FullPath
        {
            get
            {
                return _watcher.Path;
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Constructor

        /// <summary>
        /// Creates a new container within which to monitor changes to a target directory.
        /// </summary>
        /// <param name="watcherPath">The target directory monitored by the FileSystemWatcher.</param>
        /// <param name="filter">Specifies filters used to detect changes to specific file types within the target directory.</param>
        /// <param name="OnChangedFunction">Method called when files are Changed, Created, or Deleted within the specified target directory.</param>
        /// <param name="OnRenamedFunction">Method called when files are Renamed within the specified target directory.</param>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public fileSystemWatcherContainer(string watcherPath, string filter, Action<string, string> OnChangedFunction, Action<string, string> OnRenamedFunction)
        {
            if (!Directory.Exists(watcherPath))
                throw new ArgumentException("Watcher target path invalid. Please specify a valid directory.");

            _watcher = new FileSystemWatcher();
            _watcher.Path = watcherPath;
            _onChangedFunction = OnChangedFunction;
            _onRenamedFunction = OnRenamedFunction;
            InitializeFilters(filter, NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName);
            InitializeEventHandlers();
            _watcher.EnableRaisingEvents = true;
        }

        #endregion

        ////////////////////////////////////////
        #region Event Methods

        /// <summary>
        /// Handler for the FileSystemWatcher.OnChanged (and similar) event(s).
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (_onChangedFunction != null)
            {
                _onChangedFunction(e.FullPath, e.ChangeType.ToString().Trim());
            }
        }

        /// <summary>
        /// Handler for the FileSystemWatcher.OnRenamed event.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            if (_onRenamedFunction != null)
            {
                _onRenamedFunction(e.OldFullPath, e.FullPath);
            }
        }

        #endregion

        ////////////////////////////////////////
        #region Supporting Methods

        /// <summary>
        /// Attach file-related events associated with this handler.
        /// </summary>
        private void InitializeEventHandlers()
        {
            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.Created += new FileSystemEventHandler(OnChanged);
            _watcher.Deleted += new FileSystemEventHandler(OnChanged);
            _watcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        /// <summary>
        /// Initialize the file and notification filters associated with this watcher.
        /// </summary>
        /// <param name="genericFilter"></param>
        /// <param name="notificationFilters"></param>
        private void InitializeFilters(string genericFilter, NotifyFilters notificationFilters)
        {
            _watcher.Filter = (!String.IsNullOrEmpty(genericFilter)) ? genericFilter : _defaultFilter;
            _watcher.NotifyFilter = notificationFilters;
        }

        #endregion
    }
}
