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
    public class EquipoRepository : BaseRepository<EntityEquipo>, IEquipoRepository
    {
        public EquipoRepository(PrestamoDbContext dbContext) : base(dbContext)
        {
    
        }

        public override async Task<EntityEquipo> Update(EntityEquipo entity)
        {
            var existingMarca = await dbContext.Marcas.FindAsync(entity.IdMarca);
            if (existingMarca == null)
            {
                throw new Exception("La marca especificada no existe.");
            }

            var existingEntity = await dbContext.Set<EntityEquipo>().FindAsync(entity.IdEquipo);
            if (existingEntity != null)
            {
                existingEntity.IdMarca = entity.IdMarca;
                existingEntity.Marca = existingMarca;
                await dbContext.SaveChangesAsync();
                return existingEntity;
            }
            else
            {
                throw new Exception("El equipo especificado no existe.");
            }
        }


    }

}
