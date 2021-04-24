using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaApi.Entities
{
    public class BrujasMagos
    {
        [Key]
        public int identificacion {get ; set;}
        public string nombre {get ; set;}
        public string apellido {get ; set;}
        public int edad {get ; set;}
        public string casa {get ; set;}
    }
}
