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
    public class FacultadEstructura : IEntityTypeConfiguration<Facultad>
    {
        public void Configure(EntityTypeBuilder<Facultad> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(500);
            

        }
    }
}
