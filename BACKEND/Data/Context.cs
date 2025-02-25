using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId);
        }
    }
}
