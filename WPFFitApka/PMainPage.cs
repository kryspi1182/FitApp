using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Extensions.Configuration;
using WPFFitApka.Model;
using System.Collections.ObjectModel;
using FitApka.Models;
using FitApka.Controller;

namespace WPFFitApka
{
    public class PMainPage : Page
    {
        protected static UsersExpectation usersExpectation;
        protected static User user = new User("", "", 0, 0, 0, false, 0, 0) { UserExpectation = null };
        protected static IConfiguration _iconfiguration;
        protected static Collection<Meal> meals = new ObservableCollection<Meal>();
        protected static Collection<Product> userShoppingList = new ObservableCollection<Product>();
        protected static ShoppingList userShoppingListObject = new ShoppingList();
        protected static Meal[,] userDiet = new Meal[7, 5];
        protected static Collection<Training> userTraining = new ObservableCollection<Training>();
        protected static Collection<Training> allTraining = new ObservableCollection<Training>(); 
        public PMainPage()
        {
            //GetAppSettingsFile();
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }

        public static void Reset()
        {
            usersExpectation = null;
            user = new User("", "", 0, 0, 0, false, 0, 0) { UserExpectation = null };
            meals = new ObservableCollection<Meal>();
            userShoppingList = new ObservableCollection<Product>();
            userShoppingListObject = new ShoppingList();
            userDiet = new Meal[7, 5];
            userTraining = new ObservableCollection<Training>();
        }
    }
}
