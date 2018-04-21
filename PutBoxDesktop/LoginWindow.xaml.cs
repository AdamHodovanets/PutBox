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
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool AccessGranted { get; private set; }
        public bool AccessToRegistration { get; private set; }
        public UserInfo currentUser { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
            AccessGranted = false;
            AccessToRegistration = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new PutBoxServiceClient();
            currentUser = new UserInfo() { Email = loginInput.Text, Password = passwordInput.Password };
            AccessGranted = client.Registration(currentUser);
            if (AccessGranted)
            {
                loginMessage.Content = "Success";
                this.Close();
            }
            else
            {
                loginMessage.Content = "Check your credentials";
                loginInput.Text = string.Empty;
                passwordInput.Password = string.Empty;
            }
        }

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            AccessToRegistration = true;
            this.Close();
        }
    }
}
