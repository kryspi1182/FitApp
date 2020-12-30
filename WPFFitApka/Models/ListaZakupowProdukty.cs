using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class ListaZakupowProdukty
    {
        public decimal IdProdukty1 { get; set; }
        public decimal IdListaZakupow1 { get; set; }
        public decimal Ilosc { get; set; }

        public virtual ListaZakupow IdListaZakupow1Navigation { get; set; }
        public virtual Produkty IdProdukty1Navigation { get; set; }
    }
}
