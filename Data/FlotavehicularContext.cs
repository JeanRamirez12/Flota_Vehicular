using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Flota_Vehicular.Data
{
    public class FlotavehicularContext : DbContext
    {
        public FlotavehicularContext(DbContextOptions options) : base(options) 
        {
        }

     

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Registro_de_uso> Registro_de_usos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        
    }
}
