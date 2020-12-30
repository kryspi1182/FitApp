using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFFitApka.Model;
using FitApka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy PGenerateMeals.xaml
    /// </summary>
    public partial class PGenerateMeals : PMainPage
    {
        MealController mealController = new MealController();
        
        public PGenerateMeals()
        {
            InitializeComponent();
            MealList.ItemsSource = meals;
        }
        private void ShoppingList_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PShoppingList());
        }

        private void Menu_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PMainAfterLogin());
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
            this.NavigationService.Navigate(new PAccount());
        }

        private void GetMeals(object sender, RoutedEventArgs e)
        {
            FitAplikacjaDBContext fitAplikacjaDBContext = FitAplikacjaDBContext.GetDBContext();
            //meals = new ObservableCollection<Meal>();
            meals.Clear();
            UsersMeals usersMeals = new UsersMeals();
            usersMeals.user = user;
            
            usersMeals.Meals = mealController.GetList();
            usersMeals.GenerateDiet();
            userDiet = usersMeals.diet;
            for(int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    meals.Add(usersMeals.diet[i, j]);
                    
                    UzytkownikPosilki uzytkownikPosilki = new UzytkownikPosilki()
                    {
                        Dzien = i,
                        IdPosilki1 = usersMeals.diet[i, j].Id,
                        IdUzytkownik1 = user.Id
                    };
                    if (!(fitAplikacjaDBContext.UzytkownikPosilki.Where(x => x.IdPosilki1 == uzytkownikPosilki.IdPosilki1 && x.IdUzytkownik1 == uzytkownikPosilki.IdUzytkownik1 && x.Dzien == uzytkownikPosilki.Dzien).Any()))
                        fitAplikacjaDBContext.Add(uzytkownikPosilki);
                }
            }
            fitAplikacjaDBContext.SaveChanges();
        }

        private void MealDetails(object sender, MouseButtonEventArgs e)
        {
            if (MealList.SelectedIndex >= 0)
            {
                MealDetails mealDetails = new MealDetails();
                Meal tmp = meals[MealList.SelectedIndex];
                mealDetails.MealName.Text = tmp.Recipe;
                mealDetails.MealRecipe.Text = tmp.Recipe;
                mealDetails.MealCategory.Text = tmp.Category;
                mealDetails.MealEnergy.Text = tmp.GetMealEnergy().ToString();
                mealDetails.MealCarbohydrate.Text = tmp.GetMealCarbohydrate().ToString();
                mealDetails.MealProtein.Text = tmp.GetMealProtein().ToString();
                mealDetails.MealFat.Text = tmp.GetMealFat().ToString();
                mealDetails.MealFibre.Text = tmp.GetMealFibre().ToString();
                mealDetails.MealSalt.Text = tmp.GetMealSalt().ToString();
                mealDetails.ShowDialog();
                
            }
        }

        private void Trainings_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PTraining());
        }
    }
}
