using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FtpController;
using Hardcodet.Wpf.TaskbarNotification;
using PutBoxDesktop.PutBoxSvc;
using Syncfusion.UI.Xaml.Gauges;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PutBoxDesktop
{
    public partial class MainWindow : Window
    {
        private UserInfo currentUser;
        private FileSystemWatcher watcher;
        private FtpManager ftpManager;
        public MainWindow()
        {
            InitializeComponent();
            var tbi = new TaskbarIcon
            {
                Icon = Properties.Resources.pbIcon,
                ToolTipText = "hello world"
            };
            var bitmap = Properties.Resources.pbIcon.ToBitmap();
            var hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap =
                Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            this.Icon = wpfBitmap;
            var registrationWnd = new RegistrationWindow();
            var loginWnd = new LoginWindow();
            loginWnd.ShowDialog();
            if (loginWnd.AccessToRegistration)
            {
                registrationWnd.ShowDialog();
                if (registrationWnd.Registered)
                {
                    currentUser = registrationWnd.currentUser;
                    currentUser.Path = Properties.Settings.Default.PutBoxDirectory;
                }
            }
            else if (loginWnd.AccessGranted)
            {
                currentUser = loginWnd.currentUser;
                currentUser.Path = Properties.Settings.Default.PutBoxDirectory;
            }
            else
                this.Close();

            Watch();


        }
        

        private void Watch()
        {
            if (!Directory.Exists(currentUser.Path))
                Directory.CreateDirectory(currentUser.Path);
            watcher = new FileSystemWatcher
            {
                IncludeSubdirectories = true,
                Path = currentUser.Path,
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                                        | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.*",
                EnableRaisingEvents = true
            };
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            MessageBox.Show($"OnChanged{e.FullPath}");
        }

        private void OnRenamed(object source, FileSystemEventArgs e)
        {
            MessageBox.Show($"OnRenamed{e.FullPath}");
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            MessageBox.Show($"OnCreated{e.FullPath}");
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            MessageBox.Show($"OnDeleted{e.FullPath}");
        }

    }
}
