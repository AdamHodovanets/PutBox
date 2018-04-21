using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;
using PutBoxDesktop.PutBoxSvc;
using Syncfusion.UI.Xaml.Gauges;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PutBoxDesktop
{
    public partial class MainWindow : Window
    {
        private UserInfo currentUser;
        public MainWindow()
        {
            InitializeComponent();
            TaskbarIcon tbi = new TaskbarIcon();
            tbi.Icon = Properties.Resources.pbIcon;
            tbi.ToolTipText = "hello world";
            var registrationWnd = new RegistrationWindow();
            var loginWnd = new LoginWindow();
            loginWnd.ShowDialog();
            if (loginWnd.AccessToRegistration)
            {
                registrationWnd.ShowDialog();
                if (registrationWnd.Registered)
                    currentUser = registrationWnd.currentUser;
            }
            else if (loginWnd.AccessGranted)
                currentUser = loginWnd.currentUser;
            else
                this.Close();


            var watcher = new FileSystemWatcher();
        }
    }
}
