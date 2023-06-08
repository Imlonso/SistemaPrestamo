using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data
{
    public class PrestamoDbContext : DbContext 
    {
        public DbSet<EntityMarca>? Marcas { get; set; } 
        public DbSet<EntityPrestamo>? Prestamo { get; set;}
        public DbSet<EntityEquipo>? Equipo { get; set;}

        //Conexion a la base de datos
        private readonly IConfiguration configuration;

        public PrestamoDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
