//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Keywords
    {
        public Keywords()
        {
            this.LawSectors = new HashSet<LawSectors>();
            this.Lawyers = new HashSet<Lawyers>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
    
        public virtual ICollection<LawSectors> LawSectors { get; set; }
        public virtual ICollection<Lawyers> Lawyers { get; set; }
    }
}