using BACKEND.Dtos;
using BACKEND.Models;

namespace BACKEND.Services
{
    public interface IPrestamoService
    {
        Prestamo SolicitarPrestamo(SolicitudPrestamoDto solicitud);
        bool AprobarPrestamo(int id);
        IEnumerable<Prestamo> VerEstadoPrestamos(int usuarioId);
        IEnumerable<Prestamo> ObtenerTodosLosPrestamos();
    }
}
