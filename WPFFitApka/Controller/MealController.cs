using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using FitApka.DAL;
using WPFFitApka.Model;

namespace FitApka.Controller
{
    class MealController
    {
        MealDAL mealDAL = new MealDAL();
        public List<Meal> GetList()
        {
            return mealDAL.GetList();
        }

        public Meal GetMeal(int idMeal)
        {
            return mealDAL.GetMeal(idMeal);
        }
    }
}
