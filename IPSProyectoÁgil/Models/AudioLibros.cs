using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPSProyectoÁgil.Models
{
    public class Audiolibros
    {
        [Key]
        public int Identificador { get; set; }
        public String titulo { get; set; }
        public String autorDoblaje { get; set; }
        public int duracion { get; set; }
        public int ano { get; set; }
        public String tipo { get; set; }
        public float precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}