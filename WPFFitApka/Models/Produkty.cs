using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class Produkty
    {
        public Produkty()
        {
            ListaZakupowProdukty = new HashSet<ListaZakupowProdukty>();
            ProduktyPosilki = new HashSet<ProduktyPosilki>();
        }

        public decimal IdProdukty { get; set; }
        public decimal Kcal { get; set; }
        public decimal Tluszcz { get; set; }
        public decimal Weglowodany { get; set; }
        public decimal? Cukier { get; set; }
        public decimal Blonnik { get; set; }
        public decimal Bialko { get; set; }
        public decimal Sol { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<ListaZakupowProdukty> ListaZakupowProdukty { get; set; }
        public virtual ICollection<ProduktyPosilki> ProduktyPosilki { get; set; }
    }
}
