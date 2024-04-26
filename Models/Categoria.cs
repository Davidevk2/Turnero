using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Siglas { get; set; }
        public string Nombre { get; set; }
        public int Contador { get; set; }
        public string Estado { get; set; }
    }
}