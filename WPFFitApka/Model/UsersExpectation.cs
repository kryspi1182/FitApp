/*using System;
using System.Collections.Generic;
using System.Text;

namespace FitApka.Model
{
    public class UsersExpectation
    {
        // public string[] expectations = { "Schudnąć", "Utrzymać wagę", "Przytyć" };
        float weight;
        float height;
        int age;
        bool sex;
       // public User user;
        public float activity; //aktywność =1.2 brak aktywnosci, 1.3-1.4 niska aktywnosc, 1.5-1.6 srednia aktywnosc, 1.7-1.8 duza aktywnosc 
        public UsersExpectation(float weight, float height, int age, bool sex)
        {
            this.weight = weight;
            this.height = height;
            this.age = age;
            this.sex = sex;
        }
        public double TotalMetabolicRate(double activity)
        {
            if (height < 3) height *= 100;
            if(sex) //chłop
            {
                return (((9.99 * weight) + (6.25 * height) - (4.95 * age) + 5) * activity);
            }
            //baba
            return ((9.99 * weight) + (6.25 * height) - (4.92 * age) - 161) * activity;
        }
        public double KcalPerDay(string expectation, double activity)
        {
            
                if(expectation.ToLower() == "schudnąć")
                {
                    return TotalMetabolicRate(activity) * 0.8;
                }
                else if (expectation.ToLower() == "utrzymać wagę")
                {
                    return TotalMetabolicRate(activity);
                }
                else
                {
                    return TotalMetabolicRate(activity) * 1.15;
                }
            
           
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFitApka.Model
{
    public class UsersExpectation
    {
        // public string[] expectations = { "Schudnąć", "Utrzymać wagę", "Przytyć" };
        float weight;
        float height;
        int age;
        bool sex;
        // public User user;
        public double Activity { get; set; } //aktywność =1.2 brak aktywnosci, 1.3-1.4 niska aktywnosc, 1.5-1.6 srednia aktywnosc, 1.7-1.8 duza aktywnosc 
        public string Expectation { get; set; }
        public int ExpectInt { get; set; }
        public UsersExpectation(float weight, float height, int age, bool sex, int exp, double act)
        {
            this.weight = weight;
            this.height = height;
            this.age = age;
            this.sex = sex;
            this.Activity = act;
            this.ExpectInt = exp;
            switch (exp)
            {
                case 1:
                    Expectation = "schudnąć";
                    break;
                case 2:
                    Expectation = "przytyć";
                    break;
                default:
                    Expectation = "utrzymać wagę";
                    break;
            }
        }
        public double TotalMetabolicRate()
        {
            if (height < 3) height *= 100;
            if (sex) //chłop
            {
                return (((9.99 * weight) + (6.25 * height) - (4.95 * age) + 5) * Activity);
            }
            //baba
            return ((9.99 * weight) + (6.25 * height) - (4.92 * age) - 161) * Activity;
        }
        public double KcalPerDay()
        {

            if (Expectation.ToLower() == "schudnąć")
            {
                return TotalMetabolicRate() * 0.9;
            }
            else if (Expectation.ToLower() == "przytyć")
            {
                return TotalMetabolicRate() * 1.15;
            }
            return TotalMetabolicRate();
        }


    }
}
