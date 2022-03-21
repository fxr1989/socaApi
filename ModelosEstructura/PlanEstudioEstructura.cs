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
    public class PlanEstudioEstructura : IEntityTypeConfiguration<PlanEstudio>
    {
        public void Configure(EntityTypeBuilder<PlanEstudio> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(500);
            builder.HasOne(x => x.Especialidad)
                .WithMany(x => x.PlanEstudios)
                .HasForeignKey(x => x.EspecialidadId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Turno)
                .WithMany(x => x.PlanEstudios)
                .HasForeignKey(x => x.TurnoId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
