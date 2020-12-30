/*using System;
using System.Collections.Generic;
using System.Text;

namespace FitApka.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Sex { get; set; } // 0 baba, 1 chłop
        
        public int Weight { get; set; }
        public float Height { get; set; }
        public int Age { get; set; }
        public UsersExpectation UserExpectation ;
        public string Password { get; set; }
        public User ( int id, string name, string email, bool sex, int weight, float height, int age, string password )
        {
            Id = id;
            Name = name;
            Email = email;
            Weight = weight;
            Height = height;
            Weight = weight;
            Age = age;

            UserExpectation = new UsersExpectation(weight, height, age, sex);
            Password = password;
        }
        public double BMI() 
        {
            if (this.Height > 3)
                this.Height /= 100;
            return (this.Weight) / (Math.Pow(this.Height, 2));
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPFFitApka.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email obowiązkowy")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hasło obowiązkowe")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 charcters required")]
        public string Password { get; set; }
        //DateTime DateOfBirth { get; set; }
        
        public bool Sex { get; set; } // 0 baba, 1 chłop

        public int Weight { get; set; }
        public float Height { get; set; }
        public int UserAge { get; set; }
        //public int Age { get; set; }
        public UsersExpectation UserExpectation;
        public User(string name, string email, int weight, float height, int age, bool sex, int exp, double act)
        {
            Name = name;
            Email = email;
            Weight = weight;
            Height = height;
            Weight = weight;
            UserAge = age;
            Sex = sex;

            UserExpectation = new UsersExpectation(weight, height, age, sex, exp, act);
        }
        public User() { }
        /*public int Age()
        {
            int age = 0;
            age = (DateTime.Now.Year - this.DateOfBirth.Year);
            return age;
        }*/
        public double BMI()
        {
            if (this.Height > 3)
                this.Height /= 100;
            return (this.Weight) / (Math.Pow(this.Height, 2));
        }
        public double FatPerDay()
        {
            return (UserExpectation.KcalPerDay() * 0.25 / 9);
        }
        public double ProteinPerDay()
        {
            if (UserExpectation.Activity == 1.2)
                return 1.5 * Weight;
            else if (UserExpectation.Activity == 1.3 || UserExpectation.Activity == 1.4)
                return 2 * Weight;
            return 2.5 * Weight;
        }
        public double CarbohydratePerDay()
        {
            return ((UserExpectation.KcalPerDay() - FatPerDay() * 9 - ProteinPerDay() * 4) / 4);
        }
    }
}
