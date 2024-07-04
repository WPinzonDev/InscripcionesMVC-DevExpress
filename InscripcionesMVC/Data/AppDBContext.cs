using InscripcionesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace InscripcionesMVC.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Aspirante> Aspirantes { get; set; }
        public DbSet<TipoAspirante> TipoAspirante { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Programa> Programas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
