//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace U
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tuneringer
    {
        public int TurneringsId { get; set; }
        public string Tuneringsnavn { get; set; }
        public Nullable<int> Spillerid { get; set; }
        public string Spillernavn { get; set; }
        public Nullable<int> Spillertelefon { get; set; }
        public Nullable<int> Dommerid { get; set; }
        public string Dommernavn { get; set; }
        public string Dommertelefon { get; set; }
        public string Dommerlevel { get; set; }
    
        public virtual Ansatte Ansatte { get; set; }
        public virtual Spillere Spillere { get; set; }
    }
}
