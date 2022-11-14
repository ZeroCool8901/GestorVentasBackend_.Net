namespace GestorVentas_Backend.ModelsView
{
    public class UsuarioLoginMV
    {

        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Rol { get; set; } = null!;

    }
}
