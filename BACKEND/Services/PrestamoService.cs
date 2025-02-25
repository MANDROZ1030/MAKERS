using BACKEND.Data;
using BACKEND.Dtos;
using BACKEND.Interfaces;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly Context _context;
        public PrestamoService(IPrestamoRepository prestamoRepository, IUsuarioRepository usuarioRepository, Context context)
        {
            _prestamoRepository = prestamoRepository;
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        public Prestamo SolicitarPrestamo(SolicitudPrestamoDto solicitud)
        {
            var prestamo = new Prestamo
            {
                Monto = solicitud.Monto,
                Plazo = solicitud.Plazo,
                Estado = "Pendiente"
            };
            return _prestamoRepository.Add(prestamo);
        }

        public bool AprobarPrestamo(int id)
        {
            using var transaction = _context.Database.BeginTransaction(); 
            try
            {
                var prestamo = _prestamoRepository.GetById(id);
                if (prestamo == null) return false;

                prestamo.Estado = "Aprobado";
                _prestamoRepository.Update(prestamo);
                _context.SaveChanges(); 

                transaction.Commit(); 
                return true;
            }
            catch
            {
                transaction.Rollback(); 
                throw; 
            }
        }

        public IEnumerable<Prestamo> VerEstadoPrestamos(int usuarioId)
        {
            return _prestamoRepository.GetByUsuarioId(usuarioId);
        }

        public IEnumerable<Prestamo> ObtenerTodosLosPrestamos()
        {
            return _prestamoRepository.GetAll();
        }
    }

}

