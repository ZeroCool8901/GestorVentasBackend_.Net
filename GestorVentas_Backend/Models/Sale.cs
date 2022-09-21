using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Sale
    {
        public int IdSale { get; set; }
        public string Code { get; set; } = null!;
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string Approved { get; set; } = null!;
        public int IdContractor { get; set; }
        public int IdService { get; set; }
        public int IdArticle { get; set; }
        public int IdClient { get; set; }

        public virtual Article IdArticleNavigation { get; set; } = null!;
        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Contractor IdContractorNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
    }
}
