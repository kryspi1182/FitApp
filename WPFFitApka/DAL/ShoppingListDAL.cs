using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WPFFitApka.Model;
using FitApka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace FitApka.DAL
{
    class ShoppingListDAL
    {
        FitAplikacjaDBContext FitAplikacjaDBContext = FitAplikacjaDBContext.GetDBContext();

        public ShoppingListDAL() { }

        public ShoppingList GetShoppingList(int idUser) //do poprawy - nie dziala
        {
            ShoppingList testList = new ShoppingList();
            if (FitAplikacjaDBContext.ListaZakupow
                .Where(x => x.IdUzytkownik1 == idUser)
                .Any())
            {
                testList = FitAplikacjaDBContext.ListaZakupow
                    .Where(x => x.IdUzytkownik1 == idUser)
                    .Select(enList => new ShoppingList()
                    {
                        Id = (int)enList.IdListaZakupow,
                        IdUser = (int)enList.IdUzytkownik1,
                        Name = ""
                    }).FirstOrDefault();

                var productIdList = FitAplikacjaDBContext.ListaZakupowProdukty
                    .Where(pp => pp.IdListaZakupow1 == testList.Id)
                    .Select(p => new { p.IdProdukty1, p.Ilosc })
                    .ToList();
                foreach (var y in productIdList)
                {
                    Product tmp = FitAplikacjaDBContext.Produkty
                        .Where(product => product.IdProdukty == y.IdProdukty1)
                        .Select(pro => new Product()
                        {
                            Id = (int)pro.IdProdukty,
                            Name = pro.Nazwa,
                            Weight = (int)y.Ilosc,
                            NutritionalValue = new NutritionalValue()
                            {
                                Energy = (int)pro.Kcal,
                                Carbohydrate = (int)pro.Weglowodany,
                                Protein = (int)pro.Bialko,
                                Fat = (int)pro.Tluszcz,
                                Fibre = (int)pro.Blonnik,
                                Sugar = (int)pro.Cukier,
                                Salt = (int)pro.Sol
                            }
                        }).FirstOrDefault();
                    testList.ShoppingListProducts.Add(tmp);
                }
            }
            else
                testList.Id = (int)FitAplikacjaDBContext.ListaZakupow.Max(x => x.IdListaZakupow) + 1;

            return testList;
        }
    }
}
