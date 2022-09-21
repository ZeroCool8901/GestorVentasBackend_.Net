using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Article
    {
        public Article()
        {
            Sales = new HashSet<Sale>();
        }

        public int IdArticle { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;
        public int Cant { get; set; }
        public int SerialNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
