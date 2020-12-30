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
    /// Logika interakcji dla klasy PTraining.xaml
    /// </summary>
    public partial class PTraining : PMainPage
    {
        public PTraining()
        {
            this.InitializeComponent();
            MyTrainingsListBox.ItemsSource = userTraining;
        }

        private void AddTraining(object sender, RoutedEventArgs e)
        {
            AllTrainings allTrainings = new AllTrainings();
            allTrainings.AllTrainingsListBox.ItemsSource = allTraining;
            // if(allTrainings.Show() == true)
            // {
            //}
            if(allTrainings.ShowDialog()==true)
            {
                userTraining.Add(allTraining[allTrainings.index]);
            }
        }

        private void DeleteTraining(object sender, RoutedEventArgs e)
        {
            if(MyTrainingsListBox.SelectedIndex>-1)
            {
                userTraining.RemoveAt(MyTrainingsListBox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Wybierz trening do usunięcia");
            }
        }

        /*private void RandomTraining(object sender, RoutedEventArgs e)
        {

        }*/

        private void Menu_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PMainAfterLogin());
        }

        private void MealsGenerator_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PGenerateMeals());
        }

        private void ShoppingList_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PShoppingList());
        }

        private void Account_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PAccount());
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

        private void TrainingDetails(object sender, MouseButtonEventArgs e)
        {
            if (MyTrainingsListBox.SelectedIndex >= 0)
            {
                TrainingDetails trainingDetails = new TrainingDetails();
                Training tmp = userTraining[MyTrainingsListBox.SelectedIndex];
                trainingDetails.TrainingName.Text = tmp.Name;
                trainingDetails.TrainingDuration.Text = tmp.Duration + " minut";
                trainingDetails.TrainingExercises.ItemsSource = tmp.Exercises;
                trainingDetails.ShowDialog();

            }
        }
    }
}
