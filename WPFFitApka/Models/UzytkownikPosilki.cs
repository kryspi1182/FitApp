using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class UzytkownikPosilki
    {
        public decimal Dzien { get; set; }
        public decimal IdUzytkownik1 { get; set; }
        public decimal IdPosilki1 { get; set; }

        public virtual Posilki IdPosilki1Navigation { get; set; }
        public virtual Uzytkownik IdUzytkownik1Navigation { get; set; }
    }
}
