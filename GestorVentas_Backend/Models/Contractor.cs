using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            
        }

        public int IdContractor { get; set; }
        public string Nit { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Cel { get; set; } = null!;
        public int IdUser { get; set; }

 
    }
}
