using WPFFitApka.Model;
using System;
using System.Collections.Generic;
using System.Text;
using FitApka.DAL;
using Microsoft.Extensions.Configuration;

namespace FitApka.Controller
{
    class ShoppingListController
    {
        ShoppingListDAL shoppingListDAL = new ShoppingListDAL();

        public ShoppingList GetShoppingList(int idUser)
        {
            return shoppingListDAL.GetShoppingList(idUser);
        }
    }
}
