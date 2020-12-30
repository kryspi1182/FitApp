using WPFFitApka.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FitApka.Models;
using WPFFitApka;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace FitApka.DAL
{
    public class MealDAL
    {
        private FitAplikacjaDBContext FitAplikacjaDBContext = FitAplikacjaDBContext.GetDBContext();

        public MealDAL() { }
        public List<Meal> GetList() //pobranie posilkow i "mapowanie" na liste obiektow klasy meal
        {
            //ProductDAL productDAL = new ProductDAL(configuration);
            var listMeal = new List<Meal>();

            var testMeals = FitAplikacjaDBContext.Posilki
                .Select(enMeal => new Meal()
                {
                    Id = (int)enMeal.IdPosilki,
                    Name = enMeal.Przepis,
                    Recipe = enMeal.Przepis,
                    Category = enMeal.Kategoria
                }).ToList();

            foreach (Meal x in testMeals)
            {
                var productIdList = FitAplikacjaDBContext.ProduktyPosilki
                    .Where(pp => pp.IdPosilki1 == x.Id)
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
                    x.ProductList.Add(tmp);
                }
                listMeal.Add(x);
            }
            return listMeal;
        }

        public Meal GetMeal(int idMeal) //pobranie pojedynczego posilku o konkretnym id i "mapowanie" go na klase meal
        {
            var testMeal = FitAplikacjaDBContext.Posilki
                .Where(x => x.IdPosilki == idMeal)
                .Select(enMeal => new Meal()
                {
                    Id = (int)enMeal.IdPosilki,
                    Name = enMeal.Przepis,
                    Recipe = enMeal.Przepis,
                    Category = enMeal.Kategoria
                }).FirstOrDefault();

            var productIdList = FitAplikacjaDBContext.ProduktyPosilki
            .Where(pp => pp.IdPosilki1 == idMeal)
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
                testMeal.ProductList.Add(tmp);
            }
            return testMeal;
        }
    }
}
