﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcReserHotel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ctxHotel : DbContext
    {
        public ctxHotel()
            : base("name=ctxHotel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<estado_civil> estado_civil { get; set; }
        public virtual DbSet<habitacion> habitacion { get; set; }
        public virtual DbSet<recepcionista> recepcionista { get; set; }
        public virtual DbSet<reservacion> reservacion { get; set; }
        public virtual DbSet<tipo_habitacion> tipo_habitacion { get; set; }
    }
}
