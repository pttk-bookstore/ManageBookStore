//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill_Detail
    {
        public int Detail_ID { get; set; }
        public int Bill_ID { get; set; }
        public int Book_ID { get; set; }
        public int Book_Count { get; set; }
        public double Book_Price { get; set; }
        public double Book_Promotion { get; set; }
        public double Book_InPrice { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Book Book { get; set; }
    }
}
