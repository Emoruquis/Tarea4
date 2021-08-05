using System;
using System.Collections.Generic;

#nullable disable

namespace CargarDatos.Models
{
    public partial class EntidadFederativa
    {
        public int EntidadId { get; set; }
        public string Nombre { get; set; }
        public string NombreAbreviado { get; set; }
        public int? PoblacionTotal { get; set; }
        public int? TotalDeViviendasHabitadas { get; set; }
        public int? PoblacionMasculina { get; set; }
        public int? PoblacionFemenina { get; set; }
    }
}
