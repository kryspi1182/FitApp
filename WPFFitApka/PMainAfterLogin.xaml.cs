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
using FitApka.Controller;

namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy PMainAfterLogin.xaml
    /// </summary>
    public partial class PMainAfterLogin : PMainPage
    {
        private string userName;
        TrainingController trainingController = new TrainingController();
        public PMainAfterLogin()
        {
            this.InitializeComponent();
            allTraining = trainingController.GetTrainings();
        }
        public PMainAfterLogin(string name)
        {
           this.InitializeComponent();
            userName = name;
           
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

        private void Account_Button(object sender, RoutedEventArgs e)
        {
            //Window window = Window.GetWindow(this);
            this.NavigationService.Navigate(new PAccount());
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //mainTextBlock.Text = userName;
        }

        private void Trainings_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PTraining());
        }
    }
}
