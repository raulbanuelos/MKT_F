﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MKT.DataAccess.ServiceObjects
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesMKT : DbContext
    {
        public EntitiesMKT()
            : base("name=EntitiesMKT")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gerente> Gerente { get; set; }
        public virtual DbSet<SIMS> SIMS { get; set; }
        public virtual DbSet<SIMS_GERENTE> SIMS_GERENTE { get; set; }
        public virtual DbSet<Diario> Diario { get; set; }
    }
}
