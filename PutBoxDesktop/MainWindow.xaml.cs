using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FtpController;
using PutBoxDesktop.Properties;
using PutBoxDesktop.PutBoxSvc;
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PutBoxDesktop
{
    public partial class MainWindow : Window
    {
        private readonly UserInfo currentUser;
        private FileSystemWatcher watcher;
        private FtpManager ftpManager;
        private readonly PutBoxServiceClient client;
        private string relatiavePath;

        public MainWindow()
        {
            InitializeComponent();
            Hide();
            client = new PutBoxServiceClient();
            taskBar.Icon = Properties.Resources.pbIcon;
            var bitmap = Properties.Resources.pbIcon.ToBitmap();
            var hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            Icon = wpfBitmap;
            var registrationWnd = new RegistrationWindow();
            var loginWnd = new LoginWindow();
            loginWnd.ShowDialog();
            if (loginWnd.AccessToRegistration)
            {
                registrationWnd.ShowDialog();
                if (registrationWnd.Registered)
                {
                    currentUser = registrationWnd.currentUser;
                    currentUser.Path = Settings.Default.PutBoxDirectory;
                }
            }
            else if (loginWnd.AccessGranted)
            {
                currentUser = loginWnd.currentUser;
                currentUser.Path = Settings.Default.PutBoxDirectory;
            }
            else
            {
                Close();
            }

            Watch();
        }

        private void Watch()
        {
            if (!Directory.Exists(currentUser.Path)) Directory.CreateDirectory(currentUser.Path);
            relatiavePath = client.GetUserDir();
            ftpManager = new FtpManager(client.GetFtpHost(), client.GetFtpUser(), client.GetFtpPassword());
            ftpManager.CreateDirectory($@"UserDirectories{client.GetPath(currentUser)}");
            var url = "UserDirectories/28";
            ftpManager.DownloadFtpDirectory(url, Properties.Settings.Default.PutBoxDirectory);
            watcher = new FileSystemWatcher
            {
                IncludeSubdirectories = true,
                Path = currentUser.Path,
                NotifyFilter =
                    NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName
                    | NotifyFilters.DirectoryName,
                Filter = "*.*",
                EnableRaisingEvents = true
            };
            watcher.Renamed += OnRenamed;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
        }

        private void RecursiveDirectory(string dirPath, string uploadPath)
        {
            var files = Directory.GetFiles(dirPath, "*.*");
            var subDirs = Directory.GetDirectories(dirPath);
            foreach (var file in files) ftpManager.Upload(uploadPath + "/" + Path.GetFileName(file), file);
            foreach (var subDir in subDirs)
            {
                ftpManager.CreateDirectory(uploadPath + "/" + Path.GetFileName(subDir));
                RecursiveDirectory(subDir, uploadPath + "/" + Path.GetFileName(subDir));
            }
        }

        private void OnRenamed(object source, FileSystemEventArgs e)
        {
            ftpManager.DeleteFtpDirectoryAndContent($@"UserDirectories{client.GetPath(currentUser)}");
            RecursiveDirectory($@"{currentUser.Path}", $@"UserDirectories{client.GetPath(currentUser)}");
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            ftpManager.DeleteFtpDirectoryAndContent($@"UserDirectories{client.GetPath(currentUser)}");
            RecursiveDirectory($@"{currentUser.Path}", $@"UserDirectories{client.GetPath(currentUser)}");
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            ftpManager.DeleteFtpDirectoryAndContent($@"UserDirectories{client.GetPath(currentUser)}");
            RecursiveDirectory($@"{currentUser.Path}", $@"UserDirectories{client.GetPath(currentUser)}");
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            switch((sender as MenuItem).Header.ToString())
            {
                case "Synchronization":
                    var url = $@"UserDirectories{client.GetPath(currentUser)}";
                    ftpManager.DownloadFtpDirectory(url, Properties.Settings.Default.PutBoxDirectory);
                    break;
                case "Options":
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        fbd.Description = @"Choose empty folder or create new";
                        Properties.Settings.Default.PutBoxDirectory = fbd.SelectedPath;
                        Properties.Settings.Default.Save();
                    }
                    break;
                case "Sign Out":
                    this.Close();
                    break;
            }
        }
    }
}