using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFFitApka.Model
{
    public class UsersMeals
    {
        public User user;
        public List<Meal> Meals = new List<Meal>();
        public List<Meal> UsedMeal = new List<Meal>();
        public Meal[,] diet = new Meal[7, 5];


        public double BreakfastKcal()
        {
            return user.UserExpectation.KcalPerDay() * 0.25;
        }
        public double SecondBreakfastKcal()
        {
            return user.UserExpectation.KcalPerDay() * 0.15;
        }
        public double DinnerKcal()
        {
            return user.UserExpectation.KcalPerDay() * 0.3;
        }
        public double TeaKcal()
        {
            return user.UserExpectation.KcalPerDay() * 0.1;
        }
        public double SupperKcal()
        {
            return user.UserExpectation.KcalPerDay() * 0.2;
        }
        public double MealFat()
        {
            return user.FatPerDay() / 5;
        }
        public double MealProtein()
        {
            return user.ProteinPerDay() / 5;
        }
        public double MealCarbohydrate()
        {
            return user.CarbohydratePerDay() / 5;
        }
        public Meal GetBreakfast()
        {
            Meal meal = new Meal();
            bool foundMeal = false;
            double x = 1;
            double y = 1;
            if (Meals.Count == 0)
            {
                Meals = UsedMeal;
                UsedMeal.Clear();
            }
            else
            {
                while (!foundMeal)
                {
                    
                    foreach (var item in Meals)
                    {
                        
                        if (item.Category.ToLower() == "śniadanie")
                        {
                            
                            if (item.GetMealEnergy() <= (BreakfastKcal() * x) && (item.GetMealEnergy() >= (BreakfastKcal() * y)) && (!UsedMeal.Contains(item)))
                            {
                                
                                if (item.GetMealFat() <= (MealFat() * x) && (item.GetMealFat() >= (MealFat() * y)) && (item.GetMealProtein() <= (MealProtein() * x) && (item.GetMealProtein() >= (MealProtein() * y))) && (item.GetMealCarbohydrate() <= (MealCarbohydrate() * x) && (item.GetMealCarbohydrate() >= (MealCarbohydrate() * y))))
                                {
                                    UsedMeal.Add(item);
                                    meal = item;
                                    Meals.Remove(item);
                                    foundMeal = true;
                                    break;
                                }
                            }
                        }
                    }
                    x += 0.1;
                    y -= 0.1;
                }
            }
            return meal;
        }
        public Meal GetSecondBreakfast()
        {
            Meal meal = new Meal();
            bool foundMeal = false;
            double x = 1;
            double y = 1;
            if (Meals.Count == 0)
            {
                Meals = UsedMeal;
                UsedMeal.Clear();
            }
            else
            {
                while (!foundMeal)
                {
                    foreach (var item in Meals)
                    {
                        if (item.Category.ToLower() == "drugie śniadanie")
                        {
                            if (item.GetMealEnergy() <= (SecondBreakfastKcal() * x) && (item.GetMealEnergy() >= (SecondBreakfastKcal() * y)) && (!UsedMeal.Contains(item)))
                            {
                                if (item.GetMealFat() <= (MealFat() * x) && (item.GetMealFat() > (MealFat() * y)) && (item.GetMealProtein() <= (MealProtein() * x) && (item.GetMealProtein() > (MealProtein() * y))) && (item.GetMealCarbohydrate() <= (MealCarbohydrate() * x) && (item.GetMealCarbohydrate() > (MealCarbohydrate() * y))))
                                {
                                    UsedMeal.Add(item);
                                    meal = item;
                                    Meals.Remove(item);
                                    foundMeal = true;
                                    break;
                                }

                            }
                        }
                    }
                    x += 0.1;
                    y -= 0.1;
                }
            }
            return meal;
        }
        public Meal GetDinner()
        {
            Meal meal = new Meal();
            bool foundMeal = false;
            double x = 1;
            double y = 1;
            if (Meals.Count == 0)
            {
                Meals = UsedMeal;
                UsedMeal.Clear();
            }
            else
            {
                while (!foundMeal)
                {
                    foreach (var item in Meals)
                    {
                        if (item.Category.ToLower() == "obiad")
                        {
                            if (item.GetMealEnergy() <= (DinnerKcal() * x) && (item.GetMealEnergy() >= DinnerKcal() * y) && (!UsedMeal.Contains(item)))
                            {
                                if (item.GetMealFat() <= (MealFat() * x) && (item.GetMealFat() > (MealFat() * y)) && (item.GetMealProtein() <= (MealProtein() * x) && (item.GetMealProtein() > (MealProtein() * y))) && (item.GetMealCarbohydrate() <= (MealCarbohydrate() * x) && (item.GetMealCarbohydrate() > (MealCarbohydrate() * y))))
                                {
                                    UsedMeal.Add(item);
                                    meal = item;
                                    Meals.Remove(item);
                                    foundMeal = true;
                                    break;
                                }
                            }
                        }
                    }
                    x += 0.1;
                    y -= 0.1;
                }
            }
            return meal;
        }
        public Meal GetTea()
        {
            Meal meal = new Meal();
            bool foundMeal = false;
            double x = 1;
            double y = 1;
            if (Meals.Count == 0)
            {
                Meals = UsedMeal;
                UsedMeal.Clear();
            }
            else
            {
                while (!foundMeal)
                {
                    foreach (var item in Meals)
                    {
                        if (item.Category.ToLower() == "podwieczorek")
                        {
                            if (item.GetMealEnergy() <= (TeaKcal() * x) && (item.GetMealEnergy() >= TeaKcal() * y) && (!UsedMeal.Contains(item)))
                            {
                                if (item.GetMealFat() <= (MealFat() * x) && (item.GetMealFat() > (MealFat() * y)) && (item.GetMealProtein() <= (MealProtein() * x) && (item.GetMealProtein() > (MealProtein() * y))) && (item.GetMealCarbohydrate() <= (MealCarbohydrate() * x) && (item.GetMealCarbohydrate() > (MealCarbohydrate() * y))))
                                {
                                    UsedMeal.Add(item);
                                    meal = item;
                                    Meals.Remove(item);
                                    foundMeal = true;
                                    break;
                                }
                            }
                        }
                    }
                    x += 0.1;
                    y -= 0.1;
                }
            }
            return meal;
        }
        public Meal GetSupper()
        {
            Meal meal = new Meal();
            bool foundMeal = false;
            double x = 1;
            double y = 1;
            if (Meals.Count == 0)
            {
                Meals = UsedMeal;
                UsedMeal.Clear();
            }
            else
            {
                while (!foundMeal)
                {
                    foreach (var item in Meals)
                    {
                        if (item.Category.ToLower() == "kolacja")
                        {
                            if (item.GetMealEnergy() <= (SupperKcal() * x) && (item.GetMealEnergy() >= SupperKcal() * y) && (!UsedMeal.Contains(item)))
                            {
                                if (item.GetMealFat() <= (MealFat() * x) && (item.GetMealFat() >= (MealFat() * y)) && (item.GetMealProtein() <= (MealProtein() * x) && (item.GetMealProtein() >= (MealProtein() * y))) && (item.GetMealCarbohydrate() <= (MealCarbohydrate() * x) && (item.GetMealCarbohydrate() >= (MealCarbohydrate() * y))))
                                {
                                    UsedMeal.Add(item);
                                    meal = item;
                                    Meals.Remove(item);
                                    foundMeal = true;
                                    break;
                                }
                            }
                        }
                    }
                    x += 0.1;
                    y -= 0.1;
                }
            }
            return meal;
        }

        public void GenerateDiet()
        {
            for (int i = 0; i < 7; i++)
            {
                diet[i, 0] = GetBreakfast();
                diet[i, 1] = GetSecondBreakfast();
                diet[i, 2] = GetDinner();
                diet[i, 3] = GetTea();
                diet[i, 4] = GetSupper();
            }
        }

        public void WriteDiet()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Dzien " + (i + 1) + " | ");
                    Console.ResetColor();
                    Console.WriteLine("posilek " + (j + 1) + "\n");

                    Console.Write(diet[i, j].Recipe);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" | " + diet[i, j].Category + " | lista: \n");
                    Console.ResetColor();
                    diet[i, j].ProductList.ForEach(product =>
                    {

                        Console.Write(product.Name);
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write(" | ilosc: " + product.Weight * 100 + "g\n");
                        Console.ResetColor();

                    });
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Podsumowanie posilku: kcal: " + diet[i, j].GetMealEnergy() + " | węglowodany: " + diet[i, j].GetMealCarbohydrate() + " | tłuszcz: " + diet[i, j].GetMealFat() + " | białko: " + diet[i, j].GetMealProtein());
                    Console.ResetColor();
                    Console.WriteLine("--------------------");
                }
            }
        }

        
    }
}
