﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClayReporting.DataAcces
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class clayreportingEntities : DbContext
    {
        public clayreportingEntities()
            : base("name=clayreportingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<composant> composant { get; set; }
        public virtual DbSet<couleur> couleur { get; set; }
        public virtual DbSet<data> data { get; set; }
        public virtual DbSet<etat> etat { get; set; }
        public virtual DbSet<rapport> rapport { get; set; }

        public System.Data.Entity.DbSet<ClayReporting.DataAcces.Modeles.DataExport> DataExports { get; set; }
    }
}
