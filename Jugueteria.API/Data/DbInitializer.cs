using Jugueteria.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.API.Data
{
    public class DbInitializer
    {
        public static void Initializer(JugueteriaDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.inventarios.Any())
            {
                return;
            }
            var inventario = new List<Inventario>
            {
            new Inventario{Nombre="Lego McQueen y Mate",Descripcion="Set de juego 2 en 1 con el Rayo McQueen y Mate",RestriccionEdad=10,Compania="Matel",Precio= Decimal.Parse("350.70")},
            new Inventario{Nombre="Muñeca Disney Princess Party Time",Descripcion="Viene con un cono de helado con función de sonido Vestido con un traje característico",RestriccionEdad=10,Compania="Cindy Tolly Tots",Precio= Decimal.Parse("579.99")},
            new Inventario{Nombre="Pax Mi Cachorro",Descripcion="Incluye una Mascota, Correa, 9 Premios y 1 Bolsa",RestriccionEdad=10,Compania="FurReal Friends",Precio= Decimal.Parse("869.99")},
            new Inventario{Nombre="Pista Hot Wheels",Descripcion="Lanza un coche para golpear su mandíbula y derrota al tiburón",RestriccionEdad=10,Compania="Hot Wheels",Precio= Decimal.Parse("679.00")},
            new Inventario{Nombre="Acelerador de curva",Descripcion="Lanza tus autos por cualquir curva",RestriccionEdad=10,Compania="Hot Wheels",Precio= Decimal.Parse("349.00")}
            };

            inventario.ForEach(s => context.inventarios.Add(s));
            context.SaveChanges();
        }
    }
}
