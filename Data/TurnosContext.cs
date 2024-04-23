using Microsoft.EntityFrameworkCore;

namespace Data
{
    public  class TurnosContext: DbContext{
        //constructror de conexion db 
        public TurnosContext(DbContextOptions<TurnosContext> options): base(options){}

        //modelos a utilizar
    }
}