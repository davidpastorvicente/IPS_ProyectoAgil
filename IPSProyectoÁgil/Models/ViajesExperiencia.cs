using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPSProyectoÁgil.Models
{
    public class ViajesExperiencia
    {
        [Key]
        public int Identificador { get; set; }
        public string nombre { get; set; }
        public string autores { get; set; }
        public string destino { get; set; }
        public string alojamiento { get; set; }
        public string transporte { get; set; }
        public string lugarInteres { get; set; }
        public float presupuesto { get; set; }
        public int duracionVideo { get; set; }
        public float precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}