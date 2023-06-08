using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class EntityPrestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        [MaxLength(50)]
        public string? NombrePersona { get; set; }

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool EstadoPrestamo { get; set; }



        [ForeignKey(nameof(Marca))]
        public int IdMarca { get; set; }
        public EntityMarca? Marca { get; set; }




    }

}
