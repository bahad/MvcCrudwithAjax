﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcCalisan.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcExampleEntities : DbContext
    {
        public MvcExampleEntities()
            : base("name=MvcExampleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calisan> Calisans { get; set; }
        public virtual DbSet<Departman> Departmen { get; set; }
        public virtual DbSet<Pozisyon> Pozisyons { get; set; }
    }
}
