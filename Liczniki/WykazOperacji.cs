//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Liczniki
{
    using System;
    using System.Collections.Generic;
    
    public partial class WykazOperacji
    {
        public string NrLicznika { get; set; }
        public Nullable<System.DateTime> DataOperacji { get; set; }
        public Nullable<decimal> Obciazenie { get; set; }
        public Nullable<decimal> Uznanie { get; set; }
        public Nullable<decimal> ObciazenieSuma { get; set; }
        public Nullable<decimal> UznanieSuma { get; set; }
        public Nullable<decimal> Saldo { get; set; }
    }
}
