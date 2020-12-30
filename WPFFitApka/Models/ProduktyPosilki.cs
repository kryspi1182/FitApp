using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class ProduktyPosilki
    {
        public decimal IdPosilki1 { get; set; }
        public decimal IdProdukty1 { get; set; }
        public decimal Ilosc { get; set; }
        public string Jednostka { get; set; }

        public virtual Posilki IdPosilki1Navigation { get; set; }
        public virtual Produkty IdProdukty1Navigation { get; set; }
    }
}
