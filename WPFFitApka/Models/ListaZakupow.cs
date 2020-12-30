using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class ListaZakupow
    {
        public ListaZakupow()
        {
            ListaZakupowProdukty = new HashSet<ListaZakupowProdukty>();
        }

        public decimal IdListaZakupow { get; set; }
        public string Nazwa { get; set; }
        public decimal IdUzytkownik1 { get; set; }

        public virtual Uzytkownik IdUzytkownik1Navigation { get; set; }
        public virtual ICollection<ListaZakupowProdukty> ListaZakupowProdukty { get; set; }
    }
}
