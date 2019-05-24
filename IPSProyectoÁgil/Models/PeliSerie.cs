using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPSProyectoÁgil.Models
{
    public class PeliSerie
    {
        [Key]
        public int PeliSerieId { get; set; }
        public String Titulo { get; set; }
        public String CanalProductora { get; set; }
        public String Director { get; set; }
        public String Actores { get; set; }
        public int edadRecomendada { get; set; }
        public String PeliOSerie { get; set; }
        public String tipo { get; set; }
        public int anio { get; set; }
        public float precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}