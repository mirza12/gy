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
    
    public partial class comment
    {
        public int Id { get; set; }
        public string comment1 { get; set; }
        public int uid { get; set; }
        public int appid { get; set; }
    
        public virtual app app { get; set; }
        public virtual user user { get; set; }
    }
}
