using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosEstructura
{
    public class TurnoEstructura : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(500);
            builder.HasOne(x => x.Tenant)
                .WithMany(x => x.Turnos)
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
