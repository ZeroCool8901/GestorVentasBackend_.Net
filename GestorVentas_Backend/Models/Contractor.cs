using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            BankAccounts = new HashSet<BankAccount>();
            Sales = new HashSet<Sale>();
        }

        public int IdContractor { get; set; }
        public string Nit { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Cel { get; set; } = null!;
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
