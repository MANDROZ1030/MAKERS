using BACKEND.Data;
using BACKEND.Interfaces;
using BACKEND.Models;

namespace BACKEND.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly Context _context;

        public PrestamoRepository(Context context)
        {
            _context = context;
        }

        public Prestamo Add(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
            return prestamo;
        }

        public Prestamo GetById(int id)
        {
            return _context.Prestamos.Find(id);
        }

        public void Update(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            _context.SaveChanges();
        }

        public IEnumerable<Prestamo> GetByUsuarioId(int usuarioId)
        {
            return _context.Prestamos.Where(p => p.UsuarioId == usuarioId).ToList();
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _context.Prestamos.ToList();
        }
    }
}
