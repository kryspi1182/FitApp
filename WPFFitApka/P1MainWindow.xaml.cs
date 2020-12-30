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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy P1MainWindow.xaml
    /// </summary>
    public partial class P1MainWindow : Page
    {
        private Login Login;
        private Registration registration;
        //protected string userName;
        public P1MainWindow()
        {
            InitializeComponent();
        }

        private void Registration_Button(object sender, RoutedEventArgs e)
        {
            registration = new Registration();
            if (registration.ShowDialog() == true)
            {
                if (registration.DialogResult == true)
                {
                    this.NavigationService.Navigate(new PMainAfterLogin());
                }
            }
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            Login = new Login();
            if (Login.ShowDialog() == true)
            {
                if (Login.DialogResult == true)
                {
                    //userName = Login.LoginTextBox.Text;
                    this.NavigationService.Navigate(new PMainAfterLogin());
                }
            }
        }
    }
}
