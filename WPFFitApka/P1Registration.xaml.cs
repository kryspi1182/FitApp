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
using WPFFitApka.Model;
namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy P1Registration.xaml
    /// </summary>
    public partial class P1Registration : PMainPage
    {
       // private User user1;
        public P1Registration()
        {
            InitializeComponent();
           // this.user1 = user;
        }

        private void NextFitGoal(object sender, RoutedEventArgs e)
        {
            user.Name = userName.Text;
            user.Email = emailTextBox.Text;
            user.Password = passwordTextBox.Password;
            user.Weight = int.Parse(weightTextBox.Text);
           // user.Height = float.Parse(heightTextBox.Text);
            user.UserAge = int.Parse(userAge.Text);
            if (cm.IsChecked == true)
            {
                //heightTextBoxcm.Visibility = Visibility.Visible;
                //heightTextBoxm.Visibility = Visibility.Hidden;
                user.Height = float.Parse(heightTextBoxcm.Text);
            }
            if (m.IsChecked == true)
            {
                //heightTextBoxm.Visibility = Visibility.Visible;
                //heightTextBoxcm.Visibility = Visibility.Hidden;
                user.Height = float.Parse(heightTextBoxm.Text);
            }
            //user = user1;
            //nowe
            this.NavigationService.Navigate(new P2Registration());
        }

        private void ChooseSex(object sender, RoutedEventArgs e)
        {
            if (Female.IsChecked == true)
                user.Sex = false;
            if (Male.IsChecked == true)
                user.Sex = true;
        }

        private void createUser(object sender, DependencyPropertyChangedEventArgs e)
        {
            user.Name = userName.Text;
            user.Email = emailTextBox.Text;
            user.Password = passwordTextBox.Password;
            user.Weight = int.Parse(weightTextBox.Text);
            
            // user.Height = float.Parse(heightTextBox.Text);
        }

        private void ChooseHeight(object sender, RoutedEventArgs e)
        {
            if(cm.IsChecked == true)
            {
                heightTextBoxcm.Visibility = Visibility.Visible;
                heightTextBoxm.Visibility = Visibility.Hidden;
                //user.Height = float.Parse(heightTextBoxcm.Text);
            }
            if(m.IsChecked == true)
            {
                heightTextBoxm.Visibility = Visibility.Visible;
                heightTextBoxcm.Visibility = Visibility.Hidden;
                //user.Height = float.Parse(heightTextBoxm.Text);
            }
        }

        private void Registration_Loaded(object sender, RoutedEventArgs e)
        {
            cm.IsChecked = true;
        }
    }
}
