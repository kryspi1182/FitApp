using System;
using System.Collections.Generic;

namespace FitApka.Models
{
    public partial class CwiczeniaTrening
    {
        public decimal IdTreningi1 { get; set; }
        public decimal IdCwiczenia1 { get; set; }

        public virtual Cwiczenia IdCwiczenia1Navigation { get; set; }
        public virtual Treningi IdTreningi1Navigation { get; set; }
    }
}
