﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database1Entities12 : DbContext
    {
        public Database1Entities12()
            : base("name=Database1Entities12")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Admin> Admins { get; set; }
        public DbSet<app> apps { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<screen> screens { get; set; }
        public DbSet<uni> unis { get; set; }
        public DbSet<user> users { get; set; }
    }
}