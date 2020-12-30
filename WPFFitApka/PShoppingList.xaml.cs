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
using WPFFitApka.Model;
using FitApka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy PShoppingList.xaml
    /// </summary>
    public partial class PShoppingList : PMainPage
    {
        //ShoppingListController shoppingListController = new ShoppingListController(_iconfiguration);
        public PShoppingList()
        {
            InitializeComponent();
            ShoppingListBox.ItemsSource = userShoppingList;
            ShoppingListToList();
        }

        private void Menu_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PMainAfterLogin());
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
            this.NavigationService.Navigate(new PAccount());
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            if(ShoppingListBox.SelectedIndex>-1)
            {
                newProduct.ProductName.Text = userShoppingListObject.ShoppingListProducts[ShoppingListBox.SelectedIndex].Name;
            }
            if(newProduct.ShowDialog()==true)
            {
                Product product = new Product();
                product.Name = newProduct.ProductName.Text;
                int weight;
                if(Int32.TryParse(newProduct.ProductWeight.Text, out weight))
                {
                    product.Weight = weight/100;
                    userShoppingListObject.AddProduct(product);
                    ShoppingListToList();
                }
                else
                {
                    MessageBox.Show("W ilości podano niepoprawne dane");
                }
            }
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if(ShoppingListBox.SelectedIndex>-1)
            {
                userShoppingList.RemoveAt(ShoppingListBox.SelectedIndex);
                //userShoppingListObject.ShoppingListProducts.RemoveAt(ShoppingListBox.SelectedIndex);
                //ShoppingListToList();
            }
            else
            {
                MessageBox.Show("Wybierz produkt do usunięcia");
            }
        }

        private void GenerateProducts(object sender, RoutedEventArgs e)
        {
            ShoppingList shoppingList = new ShoppingList();
            //shoppingList.ShoppingListProducts.Clear();
            shoppingList.CreateShoppingList(userDiet);
            //userShoppingListObject.ShoppingListProducts.Clear();
            //userShoppingListObject = shoppingList;
            foreach(var x in shoppingList.ShoppingListProducts)
            {
                userShoppingListObject.ShoppingListProducts.Add(x);
            }
            ShoppingListToList();
        }

        private void ShoppingListToList()
        {
            userShoppingList.Clear();
            //FitAplikacjaDBContext fitAplikacjaDBContext = FitAplikacjaDBContext.GetDBContext(); //dodawanie listy zakupow do bazy - wylaczone, poniewaz uzytkownik moglby probowac dodawac do bazy produkty ktorych tam nie ma
            foreach (Product x in userShoppingListObject.ShoppingListProducts)
            {
                userShoppingList.Add(x);
                /*ListaZakupowProdukty tmp = new ListaZakupowProdukty();
                if (fitAplikacjaDBContext.ListaZakupowProdukty.Where(list => list.IdListaZakupow1 == userShoppingListObject.Id && list.IdProdukty1 == x.Id).Any())
                {
                    tmp = fitAplikacjaDBContext.ListaZakupowProdukty.Where(list => list.IdListaZakupow1 == userShoppingListObject.Id && list.IdProdukty1 == x.Id).FirstOrDefault();
                    if(tmp.Ilosc != x.Weight)
                    {
                        tmp.Ilosc = x.Weight;
                        fitAplikacjaDBContext.Update(tmp);
                    }
                }
                else
                {
                    tmp.IdProdukty1 = x.Id;
                    tmp.IdListaZakupow1 = userShoppingListObject.Id;
                    tmp.Ilosc = x.Weight;
                    fitAplikacjaDBContext.Add(tmp);
                }*/
            }
            //fitAplikacjaDBContext.SaveChanges();
        }

        private void Trainings_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PTraining());
        }
    }
}
