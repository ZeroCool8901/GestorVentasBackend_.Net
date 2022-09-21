using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Service
    {
        public Service()
        {
            Sales = new HashSet<Sale>();
        }

        public int IdService { get; set; }
        public string Type { get; set; } = null!;
        public bool State { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
