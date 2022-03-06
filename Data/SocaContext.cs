using Microsoft.EntityFrameworkCore;
using Modelos;
using ModelosEstructura;

namespace Data
{
    public class SocaContext : DbContext
    {
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public SocaContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TenantEstructura());
            modelBuilder.ApplyConfiguration(new FacultadEstructura());
            modelBuilder.ApplyConfiguration(new EspecialidadEstructura());
            modelBuilder.ApplyConfiguration(new AsignaturaEstructura());
        }
        
    }
}
