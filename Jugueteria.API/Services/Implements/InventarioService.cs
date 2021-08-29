using Jugueteria.API.Models;
using Jugueteria.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.API.Services.Implements
{
    public class InventarioService : GenericService<Inventario>, IInventarioService
    {
        private IInventarioRepository inventarioRepository;
        public InventarioService(IInventarioRepository inventarioRepository) : base(inventarioRepository)
        {
            this.inventarioRepository = inventarioRepository;
        }
    }
}