using Business.Interfaces;
using Data;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class EquipoRepository : BaseRepository<EntityEquipo>, IEquipoRepository
    {
        public EquipoRepository(PrestamoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
