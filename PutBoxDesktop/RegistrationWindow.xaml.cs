using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using PutBoxDesktop.PutBoxSvc;

namespace PutBoxDesktop
{
    public partial class RegistrationWindow : Window
    {

        public bool Registered { get; private set; }
        public UserInfo currentUser { get; private set; }

        public RegistrationWindow()
        {
            InitializeComponent();
            Registered = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new PutBoxServiceClient();
            currentUser = new UserInfo() { Email = loginInput.Text, Password = passwordInput.Password };
            Registered = client.Registration(currentUser);
            if (Registered)
            {
                registrationMessage.Content = "Success";
                this.Close();
            }
            else
            {
                registrationMessage.Content = "Already exist";
                loginInput.Text = string.Empty;
                passwordInput.Password = string.Empty;
                passwordRepeatInput.Password = string.Empty;
            }
        }

        private void passwordRepeatInput_PasswordChanged(object sender, RoutedEventArgs e) => 
            signUpBtn.IsEnabled = string.Equals(passwordInput.Password, passwordRepeatInput.Password) && passwordRepeatInput.Password.Length > 0;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            fbd.Description = @"Choose empty folder or create new";
            Properties.Settings.Default.PutBoxDirectory = fbd.SelectedPath;
            Properties.Settings.Default.Save();
        }
    }
}
