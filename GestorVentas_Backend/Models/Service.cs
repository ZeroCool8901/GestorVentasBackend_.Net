using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Service
    {
        public Service()
        {
            
        }

        public int IdService { get; set; }
        public string Type { get; set; } = null!;
        public bool State { get; set; }

    }
}
