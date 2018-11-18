using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Coordenadas
    {
        [Key]
        public int id { get; set; }
        public string coordenadas { get; set; }
        public string palabra { get; set; }
    }
}