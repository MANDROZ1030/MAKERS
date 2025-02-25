namespace BACKEND.Services
{
    using BACKEND.Dtos;
    using BACKEND.Interfaces;
    using BACKEND.Models;
    using System.Threading.Tasks;

    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(loginDto.Email);
            if (usuario == null || usuario.Password != loginDto.Password) 
            {
                return null; 
            }
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
