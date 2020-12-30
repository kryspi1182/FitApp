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
    /// Logika interakcji dla klasy PAccount.xaml
    /// </summary>
    public partial class PAccount : PMainPage
    {
        public PAccount()
        {
            InitializeComponent();

        }
        private void Menu_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PMainAfterLogin());
        }

        private void ShoppingList_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PShoppingList());
        }

        private void MealsGenerator_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PGenerateMeals());
        }

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wyloguj",
             MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;
            user = null;
            user = new Model.User("", "", 0, 0, 0, false, 0, 0) { UserExpectation = null };
            this.NavigationService.Navigate(new P1MainWindow());
            Reset();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userName.Text = user.Name;
            if (user.Sex)
                userSex.Text = "Mężczyzna";
            else
                userSex.Text = "Kobieta";
            userAge.Text = user.UserAge.ToString();
            userWeight.Text = user.Weight.ToString();
            userHeight.Text = user.Height.ToString();
            userBMI.Text = Math.Round(user.BMI(),2).ToString();
            userKcal.Text = Math.Round(usersExpectation.KcalPerDay()).ToString();
            userFat.Text = Math.Round(user.FatPerDay(), 2).ToString();
            userCarbohydrate.Text = Math.Round(user.CarbohydratePerDay(), 2).ToString();
            userProtein.Text = Math.Round(user.ProteinPerDay(), 2).ToString();
        }

        private void Trainings_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PTraining());
        }
    }
}
