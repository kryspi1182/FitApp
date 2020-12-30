using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFitApka.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public NutritionalValue NutritionalValue { get; set; }

        public int GetEnergy()
        {
            return this.NutritionalValue.Energy * this.Weight;
        }
        public int GetFat()
        {
            return this.NutritionalValue.Fat * this.Weight;
        }
        public int GetCarbohydrate()
        {
            return this.NutritionalValue.Carbohydrate * this.Weight;
        }
        public int GetSugar()
        {
            return this.NutritionalValue.Sugar * this.Weight;
        }
        public int GetFibre()
        {
            return this.NutritionalValue.Fibre * this.Weight;
        }
        public int GetProtein()
        {
            return this.NutritionalValue.Protein * this.Weight;
        }
        public int GetSalt()
        {
            return this.NutritionalValue.Salt * this.Weight / 100;
        }

        public override string ToString()
        {
            return "Nazwa: " + Name + " | Waga: " + Weight*100 + "g";
        }
    }
}
