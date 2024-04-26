using Microsoft.EntityFrameworkCore;
using Models;


namespace Data
{
    public  class TurnosContext: DbContext{
        //constructror de conexion db 
        public TurnosContext(DbContextOptions<TurnosContext> options): base(options){}

        //modelos a utilizar
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Turno> Turnos {get; set;}
        public DbSet<Recepcion> Usuarios {get; set;}
        public DbSet<Modulo> Modulos {get; set;}
    }
}