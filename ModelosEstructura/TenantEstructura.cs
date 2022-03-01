using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos;

namespace ModelosEstructura
{
    public class TenantEstructura : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(500);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();            
        }
    }
}
