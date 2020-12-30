using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFitApka.Model
{
    public class Training
    {
        public int Id { get; set; }
        public List<Exercise> Exercises { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "Nazwa treningu: " + Name + " | Czas: " + Duration;
        }
    }
}
