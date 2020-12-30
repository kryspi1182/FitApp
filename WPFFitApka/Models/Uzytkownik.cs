using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class Uzytkownik
    {
        public Uzytkownik()
        {
            ListaZakupow = new HashSet<ListaZakupow>();
            UzytkownikPosilki = new HashSet<UzytkownikPosilki>();
        }

        public decimal IdUzytkownik { get; set; }
        public string Imie { get; set; }
        public string Email { get; set; }
        public decimal Plec { get; set; }
        public decimal Waga { get; set; }
        public decimal Wzrost { get; set; }
        public decimal Wiek { get; set; }
        public decimal Cel { get; set; }
        public string Haslo { get; set; }
        public decimal Aktywnosc { get; set; }

        public virtual ICollection<ListaZakupow> ListaZakupow { get; set; }
        public virtual ICollection<UzytkownikPosilki> UzytkownikPosilki { get; set; }
    }
}
