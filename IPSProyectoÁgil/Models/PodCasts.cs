using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPSProyectoÁgil.Models
{
    public class PodCasts
    {
        [Key]

        public int Identificador { get; set; }
        public String emisora { get; set; }
        public String programa { get; set; }
        public int participantes { get; set; }
        public int duracion { get; set; }
        public int fecha { get; set; }
        public String tematica { get; set; }
        public float precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}