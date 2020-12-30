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
using FitApka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy P2Registration.xaml
    /// </summary>
    public partial class P2Registration : PMainPage
    {
        private int exp;
        private double act;
        public P2Registration()
        {
            InitializeComponent();
           // usersExpectation = new Model.UsersExpectation(user.Weight, user.Height, user.UserAge, user.Sex)
        }
       /* public P2Registration(User user)
        {

        } */
        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new P1Registration());
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            /* var parentWindow = this.Parent as Window;

             if (parentWindow != null)
             {
                 parentWindow.Close();
             } */
            usersExpectation = new UsersExpectation(user.Weight, user.Height, user.UserAge, user.Sex, exp, act);
            user.UserExpectation = usersExpectation;
            Window parentWindow = Window.GetWindow(this);
            parentWindow.DialogResult = true;
            FitAplikacjaDBContext fitAplikacjaDBContext = FitAplikacjaDBContext.GetDBContext();
            if(!fitAplikacjaDBContext.Uzytkownik.Where(u => u.Imie == user.Name).Any())
            {
                user.Id = (int)fitAplikacjaDBContext.Uzytkownik.Select(us => us.IdUzytkownik).Max() + 1;
                Uzytkownik uzytkownik = new Uzytkownik();

                uzytkownik.IdUzytkownik = user.Id;
                uzytkownik.Imie = user.Name;
                uzytkownik.Email = user.Email;
                uzytkownik.Waga = user.Weight;
                uzytkownik.Wiek = user.UserAge;
                uzytkownik.Wzrost = (decimal)user.Height;
                uzytkownik.Cel = user.UserExpectation.ExpectInt;
                uzytkownik.Haslo = user.Password;
                uzytkownik.Aktywnosc = (decimal)user.UserExpectation.Activity;
                if(user.Sex)
                {
                    uzytkownik.Plec = 1;
                }
                else
                {
                    uzytkownik.Plec = 0;
                }
                fitAplikacjaDBContext.Add(uzytkownik);
                fitAplikacjaDBContext.SaveChanges();

            }
            parentWindow.Close();
        }

        private void YourAim(object sender, RoutedEventArgs e)
        {
            if (loseWeight.IsChecked == true) 
                exp = 1;
            if (putOnWeight.IsChecked == true)
                exp = 2;
            if (maintainWeight.IsChecked == true)
                exp = 3;
        }

        private void ActivityType(object sender, RoutedEventArgs e)
        {
            if (noActivity.IsChecked == true)
                act = 1.2;
            if (smallActivity.IsChecked == true)
                act = 1.3;
            if (avgActivity.IsChecked == true)
                act = 1.5;
            if (largeActivity.IsChecked == true)
                act = 1.7;
        }
    }
}
