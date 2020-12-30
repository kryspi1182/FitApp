using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFitApka.Model
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Repetition { get; set; }

        public override string ToString()
        {
            return "ID: "+Id+ " | Nazwa: " + Name + " | Opis: " + Description + " | Powtorzenia: " + Repetition;
        }
    }
}
