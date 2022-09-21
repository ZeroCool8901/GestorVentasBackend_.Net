using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class BankAccount
    {
        public int IdBankAccount { get; set; }
        public string Name { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public int IdContractor { get; set; }

        public virtual Contractor IdContractorNavigation { get; set; } = null!;
    }
}
