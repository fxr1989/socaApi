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
    public class EspecialidadEstructura : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(500);
            builder.HasOne(x => x.Facultad)
                    .WithMany(x => x.Especialidades)
                    .HasForeignKey(x => x.FacultadId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
