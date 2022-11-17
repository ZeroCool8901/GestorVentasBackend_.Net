using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Archivo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Extension { get; set; }
        public double? Tamanio { get; set; }
        public string? Ubicacion { get; set; }
    }
}
