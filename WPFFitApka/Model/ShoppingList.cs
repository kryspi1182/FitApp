using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFitApka.Model
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public List<Product> ShoppingListProducts { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public ShoppingList()
        {
            ShoppingListProducts = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            int index = ShoppingListProducts.FindIndex(item => item.Name == product.Name);
            if (index >= 0)
            {
                ShoppingListProducts[index].Weight += product.Weight;
            }
            else
            {
                ShoppingListProducts.Add(product);
            }
        }

        public void AddMeal(Meal meal)
        {
            meal.ProductList.ForEach(product => AddProduct(product));
        }

        public void CreateShoppingList(Meal[,] diet)
        {
            //ShoppingListProducts.Clear();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    AddMeal(diet[i, j]);
                }
            }
        }


    }
}
