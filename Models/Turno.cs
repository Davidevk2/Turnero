using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turnos.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }

        public string Categoria {get; set;}
        public string TipoDocumento {get; set;}
        public string Identificacion {get; set;}
        public string Ficho {get; set;}
        public DateTime FechaIngreso {get; set;}
        public DateTime FechaSalida {get; set;}
        public string Estado {get; set;}
        
        [ForeignKey ("Modulos")]
        public int IdModulo { get; set; }


        
    }
}