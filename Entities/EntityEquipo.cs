using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityEquipo 
    {
        [Key]
        public int IdEquipo { get; set; }

        public string? Nombre { get; set; }
        public string? NumeroSerie { get; set; }
        public string? Descripcion { get; set; }

        [ForeignKey(nameof(Marca))]
        public int IdMarca { get; set; }
        public EntityMarca? Marca { get; set; }

        public virtual EntityPrestamo? Prestamo { get; set; }

    }
}
