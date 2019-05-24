using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPSProyectoÁgil.Models
{
    public class RevistasLibros
    {
        [Key]
        public int Identificador { get; set; }
        public String titulo { get; set; }
        public String autor { get; set; }
        public int numPaginas { get; set; }
        public int anio { get; set; }
        public String revista_libro { get; set; }
        public String tipo { get; set; }
        public float precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}