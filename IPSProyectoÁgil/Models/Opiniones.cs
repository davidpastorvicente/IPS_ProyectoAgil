using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPSProyectoÁgil.Models
{
    public class Opiniones
    {
        [Key]
        public int Identificador { get; set; }
        public String nombre_ocio { get; set; }
        public String tipo_ocio { get; set; }
        public String voto { get; set; }
    }
}