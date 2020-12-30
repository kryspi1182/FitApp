/*using System;
using System.Collections.Generic;
using System.Text;

namespace FitApka.Model
{
   public class Meal
    {
        public int Id { get; set; }
        public List<Product> ProductList {get; set;}
        public string Recipe { get; set; }
        public string Category { get; set; }
        
    }
}*/

using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFitApka.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> ProductList = new List<Product>();
        public string Recipe { get; set; }
        public string Category { get; set; }
        public List<Product> GetProducts()
        {
            return ProductList;
        }
        public int GetMealEnergy()
        {
            int fullEnergy = 0;
            foreach (var item in ProductList)
            {
                fullEnergy += item.GetEnergy();
            }
            return fullEnergy;
        }
        public int GetMealFat()
        {
            int fullFat = 0;
            foreach (var item in ProductList)
            {
                fullFat += item.GetFat();
            }
            return fullFat;
        }
        public int GetMealCarbohydrate()
        {
            int fullCarbohydrate = 0;
            foreach (var item in ProductList)
            {
                fullCarbohydrate += item.GetCarbohydrate();
            }
            return fullCarbohydrate;
        }
        public int GetMealSugar()
        {
            int fullSugar = 0;
            foreach (var item in ProductList)
            {
                fullSugar += item.GetSugar();
            }
            return fullSugar;
        }
        public int GetMealFibre()
        {
            int fullFibre = 0;
            foreach (var item in ProductList)
            {
                fullFibre += item.GetFibre();
            }
            return fullFibre;
        }
        public int GetMealProtein()
        {
            int fullProtein = 0;
            foreach (var item in ProductList)
            {
                fullProtein += item.GetProtein();
            }
            return fullProtein;
        }
        public int GetMealSalt()
        {
            int fullSalt = 0;
            foreach (var item in ProductList)
            {
                fullSalt += item.GetSalt();
            }
            return fullSalt;
        }

        public override string ToString()
        {
            return "Przepis: " + Recipe + " | Danie: " + Category +" | Kcal: " + this.GetMealEnergy() + " | W: " + this.GetMealCarbohydrate() + " | B: " + this.GetMealProtein() + " | T: " + this.GetMealFat();
        }
    }
}
