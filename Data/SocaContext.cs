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

            modelBuilder.Entity<Facultad>()
                .HasOne(p => p.Tenant)
                .WithMany(x => x.Facultades)
                .HasForeignKey(y => y.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.ApplyConfiguration(new TenantEstructura());
            modelBuilder.ApplyConfiguration(new FacultadEstructura());

            modelBuilder.Entity<Especialidad>()
                .HasOne(p => p.Facultad)
                .WithMany(x => x.Especialidades)
                .HasForeignKey(y => y.FacultadId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.ApplyConfiguration(new EspecialidadEstructura());


        }
        
    }
}
