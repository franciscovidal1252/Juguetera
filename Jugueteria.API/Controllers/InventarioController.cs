using Jugueteria.API.Models;
using Jugueteria.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioService inventarioService;

        public InventarioController(IInventarioService inventarioService)
        {
            this.inventarioService = inventarioService;
        }
        // GET api/Inventario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listInventario = await inventarioService.GetAll();
                return Ok(listInventario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/Inventario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var byIdInventario = await inventarioService.GetById(id);
                return Ok(byIdInventario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/Inventario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inventario inventario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inventario = await inventarioService.Insert(inventario);
                }
                return Ok(inventario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/Inventario/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int? id)
        //{
        //    try
        //    {
        //        if (id == null) return Ok();
        //        var editInventario = await inventarioService.GetById(id.Value);

        //        if (editInventario == null) return Ok();

        //        return Ok(editInventario);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> Put(Inventario inventario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inventario = await inventarioService.Update(inventario);
                    
                }
                return Ok(inventario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/Inventario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return Ok();

                await inventarioService.Delete(id.Value);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
