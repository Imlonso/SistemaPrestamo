using Entities;
using Microsoft.EntityFrameworkCore;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= IMLONSO\\LONSOSQL ; Database=DbPrestamo; User Id=sa; Password= alonso1699");
            }
        }

    }
}
