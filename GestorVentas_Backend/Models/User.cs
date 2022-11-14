using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class User
    {
        public User()
        {
            
        }

        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public bool State { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
