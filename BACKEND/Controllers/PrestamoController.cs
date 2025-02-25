namespace BACKEND.Controllers
{
    using BACKEND.Dtos;
    using BACKEND.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamosController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpPost("solicitar")]
        public IActionResult SolicitarPrestamo([FromBody] SolicitudPrestamoDto solicitud)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario desde el token
            var prestamo = _prestamoService.SolicitarPrestamo(solicitud, usuarioId);
            return CreatedAtAction(nameof(SolicitarPrestamo), new { id = prestamo.Id }, prestamo);
        }

        [HttpPut("aprobar/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult AprobarPrestamo(int id)
        {
            var resultado = _prestamoService.AprobarPrestamo(id);
            if (resultado)
                return NoContent();
            return NotFound();
        }

        [HttpGet("estado/{usuarioId}")]
        public IActionResult VerEstadoPrestamos(int usuarioId)
        {
            var prestamos = _prestamoService.VerEstadoPrestamos(usuarioId);
            return Ok(prestamos);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ObtenerTodosLosPrestamos()
        {
            var prestamos = _prestamoService.ObtenerTodosLosPrestamos();
            return Ok(prestamos);
        }
    }
}
