//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TermProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class uni
    {
        public uni()
        {
            this.users = new HashSet<user>();
        }
    
        public int Id { get; set; }
        public string uname { get; set; }
        public Nullable<int> ranking { get; set; }
        public string ufile { get; set; }
    
        public virtual ICollection<user> users { get; set; }
    }
}