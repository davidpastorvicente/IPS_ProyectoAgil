using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPSProyectoÁgil.Models
{
    public class Videojuegos
    {
        [Key]
        public int identificador { get; set; }
        public String nombre { get; set; }
        public String creador { get; set; }
        public int edad { get; set; }
        public String tipo { get; set; }
        public float precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}