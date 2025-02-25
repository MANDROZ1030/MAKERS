using BACKEND.Models;

namespace BACKEND.Interfaces
{
    public interface IPrestamoRepository
    {
        Prestamo Add(Prestamo prestamo);
        Prestamo GetById(int id);
        void Update(Prestamo prestamo);
        IEnumerable<Prestamo> GetByUsuarioId(int usuarioId);
        IEnumerable<Prestamo> GetAll();
    }
}
