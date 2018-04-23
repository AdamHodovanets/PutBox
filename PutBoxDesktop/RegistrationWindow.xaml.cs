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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FtpController;
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

            var bitmap = Properties.Resources.pbIcon.ToBitmap();
            var hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap =
                Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            this.Icon = wpfBitmap;
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

        private void passwordRepeatInput_PasswordChanged(object sender, RoutedEventArgs e) => ValidateCredentials();



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fbd.Description = @"Choose empty folder or create new";
                (sender as System.Windows.Controls.Button).Content = "Selected";
                dirNameBlock.Text = "Selected!But you can change it";
                Properties.Settings.Default.PutBoxDirectory = fbd.SelectedPath;
                Properties.Settings.Default.Save();
                ValidateCredentials();
            }
        }

        private void loginInput_TextChanged(object sender, TextChangedEventArgs e) => ValidateCredentials();

        private void ValidateCredentials()
        {
                signUpBtn.IsEnabled = string.Equals(passwordInput.Password, passwordRepeatInput.Password)
                                      && passwordRepeatInput.Password.Length > 0 && IsValidEmail(loginInput.Text)
                                      && selectBtn.Content.ToString() == @"Selected";
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
