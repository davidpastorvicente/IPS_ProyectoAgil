using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPSProyectoÁgil.Models
{
    public class Albums
    {
        [Key]
        public int Identificador { get; set; }
        public String nombre { get; set; }
        public String artista { get; set; }
        public String discografica { get; set; }
        public String genero { get; set; }
        public int ano { get; set; }
        public int numCanciones { get; set; }
        public float precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}