using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Client
    {
        public Client()
        {
           
        }

        public int IdClient { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Cel { get; set; } = null!;
        public string IdentificationType { get; set; } = null!;
        public string IdentificationNumber { get; set; } = null!;

    }
}
