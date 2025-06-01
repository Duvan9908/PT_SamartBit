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
    public class GastoDetalleConfiguracion : IEntityTypeConfiguration<GastoDetalle>
    {
        public void Configure(EntityTypeBuilder<GastoDetalle> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Monto).IsRequired();
            builder.Property(x => x.GastoEncabezadoId).IsRequired();
            builder.Property(x => x.TipoGastoId).IsRequired();

            //Configuración de las relaciones
            builder.HasOne(x => x.GastoEncabezado).WithMany()
                .HasForeignKey(x => x.GastoEncabezadoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.TipoGasto).WithMany()
                .HasForeignKey(x => x.TipoGastoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
