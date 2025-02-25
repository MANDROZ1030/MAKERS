using BACKEND.Models;

namespace BACKEND.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<Usuario> GetByEmailAsync(string email);
    }
}
