using Jugueteria.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.API.Data
{
    public class JugueteriaDbContext : DbContext
    {
        public JugueteriaDbContext(DbContextOptions<JugueteriaDbContext> options) : base(options)
        {

        }
        public DbSet<Inventario> inventarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventario>().ToTable("Inventario");
        }
    }
}