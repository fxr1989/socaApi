using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos;

namespace ModelosEstructura
{
    public class UsuarioTenantEstructura : IEntityTypeConfiguration<UsuarioTenant>
    {
        public void Configure(EntityTypeBuilder<UsuarioTenant> builder)
        {
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.TenantId).IsRequired();
            builder.HasOne(x => x.Tenant)
                    .WithMany()
                    .HasForeignKey(x => x.TenantId)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Usuario)
                    .WithMany()
                    .HasForeignKey(x => x.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
