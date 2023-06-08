using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class EntityMarca
    {
        [Key]
        public int IdMarca { get; set; }

        public string? Marca { get; set; }
        [MaxLength(250)]
        public string? Descripcion { get; set; }
        public TipoHerramienta Tipo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Exactitud { get; set; }


        public virtual ICollection<EntityPrestamo>? Prestamos { get; set; }
        public virtual ICollection<EntityEquipo>? Equipo { get; set; }

    }

    public enum TipoHerramienta
    {
        TodosLosTipos,
        Registradores,
        Pinzas,
        Cableado
    }
}
