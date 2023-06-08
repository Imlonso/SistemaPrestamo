using Business.Interfaces;
using Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class MarcaRepository : BaseRepository<EntityMarca>, IMarcaRepository
    {
        public MarcaRepository(PrestamoDbContext dbContext) : base(dbContext)
        {
            
        }





    }
}
