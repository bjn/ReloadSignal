using System;
using System.IO;

namespace ReloadSignal
{
    public delegate void ChangedEventHandler(object sender, FileSystemEventArgs e);

    public class Watch : IDisposable
    {
        private readonly FileSystemWatcher _watcher;

        public Watch(string directory, string filter)
        {
            _watcher = new FileSystemWatcher(directory, filter);
            _watcher.IncludeSubdirectories = true;
            _watcher.Changed += (sender, args) => OnChanged(args);
            
            _watcher.EnableRaisingEvents = true;
        }

        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(FileSystemEventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}