using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class Posilki
    {
        public Posilki()
        {
            ProduktyPosilki = new HashSet<ProduktyPosilki>();
            UzytkownikPosilki = new HashSet<UzytkownikPosilki>();
        }

        public decimal IdPosilki { get; set; }
        public string Przepis { get; set; }
        public string Kategoria { get; set; }

        public virtual ICollection<ProduktyPosilki> ProduktyPosilki { get; set; }
        public virtual ICollection<UzytkownikPosilki> UzytkownikPosilki { get; set; }

        public override string ToString()
        {
            return "ID: " + IdPosilki + " | Przepis: " + Przepis + " | Kategoria: " + Kategoria;
        }
    }
}
