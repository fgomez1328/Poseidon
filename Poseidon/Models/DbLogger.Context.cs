﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Poseidon.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class poseidon_dbEntities : DbContext
    {
        public poseidon_dbEntities()
            : base("name=poseidon_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Company> Company { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<zones> zones { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Logger> Logger { get; set; }
    }
}
