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
    public class GastoEncabezadoConfiguracion : IEntityTypeConfiguration<GastoEncabezado>
    {
        public void Configure(EntityTypeBuilder<GastoEncabezado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Fecha).IsRequired();
            builder.Property(x => x.Observaciones).HasMaxLength(100);
            builder.Property(x => x.NombreComercio).IsRequired().HasMaxLength(60);
            builder.Property(x => x.TipoDocumento).IsRequired().HasMaxLength(60);
            builder.Property(x => x.FondoMonetarioId).IsRequired();

            //Configuración de las relaciones
            builder.HasOne(x => x.FondoMonetario).WithMany()
                .HasForeignKey(x => x.FondoMonetarioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
