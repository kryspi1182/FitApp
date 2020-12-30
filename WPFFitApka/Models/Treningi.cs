using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class Treningi
    {
        public Treningi()
        {
            CwiczeniaTrening = new HashSet<CwiczeniaTrening>();
        }

        public decimal IdTreningi { get; set; }
        public decimal Czas { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<CwiczeniaTrening> CwiczeniaTrening { get; set; }
    }
}
