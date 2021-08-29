using Jugueteria.API.Data;
using Jugueteria.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.API.Repositories.Implements
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventarioRepository
    {
        public InventarioRepository(JugueteriaDbContext jugueteriaDbContext) : base(jugueteriaDbContext)
        {

        }
    }
}
