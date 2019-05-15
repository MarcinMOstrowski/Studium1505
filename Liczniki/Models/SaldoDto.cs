using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liczniki.Models
{
    public class SaldoDto
    {
            public int Id { get; set; }
            public string NrLicznika { get; set; }
            public Nullable<System.DateTime> DataOperacji { get; set; }
            public Nullable<decimal> Obciazenie { get; set; }
            public Nullable<decimal> Uznanie { get; set; }
            public Nullable<decimal> ObciazenieSuma { get; set; }
            public Nullable<decimal> UznanieSuma { get; set; }
            public Nullable<decimal> Saldo { get; set; }
            public Nullable<decimal> Odczyt { get; set; }
            public Nullable<decimal> Wplata { get; set; }
            public Nullable<decimal> StanSalda { get; set; }

    }
}