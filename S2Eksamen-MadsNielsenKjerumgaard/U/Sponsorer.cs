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
    
    public partial class Sponsorer
    {
        public int SponsorerId { get; set; }
        public string Firmanavn { get; set; }
        public string Branche { get; set; }
        public Nullable<int> Spillerid { get; set; }
        public string Spillernavn { get; set; }
        public int Udgift { get; set; }
    
        public virtual Spillere Spillere { get; set; }
    }
}