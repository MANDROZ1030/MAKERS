namespace BACKEND.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public int Plazo { get; set; }
        public string Estado { get; set; } 
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
