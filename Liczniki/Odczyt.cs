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
    
    public partial class Odczyt
    {
        public int Id { get; set; }
        public int LicznikId { get; set; }
        public Nullable<decimal> StanPoczatkowy { get; set; }
        public Nullable<decimal> StanKoncowy { get; set; }
        public Nullable<decimal> Zuzycie { get; set; }
        public Nullable<System.DateTime> DataOdczytu { get; set; }
        public Nullable<decimal> CenaM3 { get; set; }
    
        public virtual Licznik Licznik { get; set; }
    }
}