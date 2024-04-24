using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turnos.Models
{
    public class Recepcion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string  Password { get; set; }

        public DateTime FechaRegistro {get; set;}
    }
}