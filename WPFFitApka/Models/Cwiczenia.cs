using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class Cwiczenia
    {
        public Cwiczenia()
        {
            CwiczeniaTrening = new HashSet<CwiczeniaTrening>();
        }

        public decimal IdCwiczenia { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Powtorzenia { get; set; }

        public virtual ICollection<CwiczeniaTrening> CwiczeniaTrening { get; set; }
    }
}
