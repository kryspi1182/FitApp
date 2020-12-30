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
using WPFFitApka.Model;
using FitApka.Controller;
using FitApka.Models;

namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy UserLogin.xaml
    /// </summary>
    public partial class UserLogin : PMainPage
    {
        FitAplikacjaDBContext FitAplikacjaDBContext = FitAplikacjaDBContext.GetDBContext();
        public UserLogin()
        {
            InitializeComponent();
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            MealController mealController = new MealController();
            ShoppingListController shoppingListController = new ShoppingListController();
            if (LoginTextBox.Text != "" && PasswordTextBox.Password != "") //sprawdzenie czy wpisano cokolwiek w login i haslo
            {
                if (FitAplikacjaDBContext.Uzytkownik
                    .Where(u => u.Imie == LoginTextBox.Text)
                    .Any()) //sprawdzenie czy istnieje uzytkownik o takim loginie
                {
                    if (FitAplikacjaDBContext.Uzytkownik
                        .Where(us => us.Haslo == PasswordTextBox.Password && us.Imie == LoginTextBox.Text)
                        .Any()) //sprawdzenie czy haslo i login sie zgadzaja
                    {
                        var tmpuser = FitAplikacjaDBContext.Uzytkownik
                            .Where(us => us.Haslo == PasswordTextBox.Password && us.Imie == LoginTextBox.Text)
                            .First(); //pobranie encji i "mapowanie" jej na klase user

                        user.Id = (int)tmpuser.IdUzytkownik;
                        user.Name = tmpuser.Imie;
                        user.Email = tmpuser.Email;
                        user.Height = (float)tmpuser.Wzrost;
                        user.UserAge = (int)tmpuser.Wiek;
                        user.Password = tmpuser.Haslo;
                        user.Weight = (int)tmpuser.Waga;

                        if (tmpuser.Plec == 0)
                        {
                            user.Sex = false;
                        }
                        else
                        {
                            user.Sex = true;
                        }

                        UsersExpectation tmpUserExpectation = new UsersExpectation(user.Weight, user.Height, user.UserAge, user.Sex, (int)tmpuser.Cel, (double)tmpuser.Aktywnosc);
                        user.UserExpectation = tmpUserExpectation;
                        usersExpectation = tmpUserExpectation;

                        if (FitAplikacjaDBContext.UzytkownikPosilki
                            .Where(up => up.IdUzytkownik1 == user.Id)
                            .Any()) //sprawdzenie czy uzytkownik ma zapisana diete
                        {
                            var tmpUserMeals = FitAplikacjaDBContext.UzytkownikPosilki
                                .Where(tmpUp => tmpUp.IdUzytkownik1 == user.Id)
                                .ToList()
                                .OrderBy(u => u.Dzien); //pobranie diety

                            foreach (UzytkownikPosilki x in tmpUserMeals)
                            {
                                var tmpUserMeal = mealController.GetMeal((int)x.IdPosilki1); //pobranie posilku i "mapowanie" go na klase meal

                                switch (tmpUserMeal.Category) //umieszczenie posilku w tablicy diety
                                {
                                    case "śniadanie":
                                        userDiet[(int)x.Dzien, 0] = tmpUserMeal;
                                        break;
                                    case "drugie śniadanie":
                                        userDiet[(int)x.Dzien, 1] = tmpUserMeal;
                                        break;
                                    case "obiad":
                                        userDiet[(int)x.Dzien, 2] = tmpUserMeal;
                                        break;
                                    case "podwieczorek":
                                        userDiet[(int)x.Dzien, 3] = tmpUserMeal;
                                        break;
                                    case "kolacja":
                                        userDiet[(int)x.Dzien, 4] = tmpUserMeal;
                                        break;
                                    default:

                                        break;
                                }
                            }

                            for (int i = 0; i < 7; i++) //zapisanie posilkow z diety na observableList
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    meals.Add(userDiet[i, j]);
                                }
                            }
                        }

                        if (FitAplikacjaDBContext.ListaZakupow
                            .Where(list => list.IdUzytkownik1 == user.Id)
                            .Any()) //sprawdzenie czy uzytkownik ma zapisana liste zakupow
                        {
                            userShoppingListObject = shoppingListController.GetShoppingList(user.Id);
                        }

                        Window parentWindow = Window.GetWindow(this);
                        parentWindow.DialogResult = true;
                        parentWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błędne hasło");
                    }
                }

                else
                {
                    MessageBox.Show("Błędny login");
                }
            }
            else
            {
                MessageBox.Show("Niepoprawne dane", "Error");
                //DialogResult = false;
            }


        }

        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.DialogResult = false;
            parentWindow.Close();
        }
    }
}
