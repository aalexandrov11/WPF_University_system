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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginCheck()
        {
            foreach (var student in UserLogin.UserData.testUsers)
            {
                if (usernameTextBox.Text.ToString() == student.username && passwordTextBox.Text.ToString() == student.password)
                {
                    //MainWindow mainwindow = new MainWindow();
                    //this.NavigationService.Navigate(mainwindow);

                    MainWindow mainwindow = new MainWindow();
                    App.Current.MainWindow = mainwindow;
                    this.Close();
                    mainwindow.Show();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginCheck();
        }
    }
}
