using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PT_SmartBit.Modelos;

namespace PT_SmartBit.AccesoDatos.Configuracion
{
    public class FondoMonetarioConfiguracion : IEntityTypeConfiguration<FondoMonetario>
    {
        public void Configure(EntityTypeBuilder<FondoMonetario> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Descripcion).HasMaxLength(100);
            builder.Property(x => x.Activo).IsRequired();
        }
    }
}
