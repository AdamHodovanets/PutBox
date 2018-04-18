using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PutBoxDesktop.PutBoxSvc;

namespace PutBoxDesktop
{
    public partial class RegistrationWindow : Window
    {
        public bool Registered;
        public RegistrationWindow()
        {
            InitializeComponent();
            Registered = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new PutBoxServiceClient();
            Registered = client.Registration(
                new UserInfo() { Email = loginInput.Text, Password = passwordInput.Password });
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
    }
}
