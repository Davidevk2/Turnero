using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Data
{
    public  class TurnosContext: DbContext{
        //constructror de conexion db 
        public TurnosContext(DbContextOptions<TurnosContext> options): base(options){}

        //modelos a utilizar
        public DbSet<Categoria> Categorias {get; set;}
    }
}