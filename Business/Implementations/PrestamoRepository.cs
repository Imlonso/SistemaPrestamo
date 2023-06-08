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
    public class PrestamoRepository : BaseRepository<EntityPrestamo>, IPrestamoRepository
    {
        public PrestamoRepository(PrestamoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
 