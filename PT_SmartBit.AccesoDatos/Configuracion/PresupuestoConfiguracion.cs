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
    public class PresupuestoConfiguracion : IEntityTypeConfiguration<Presupuesto>
    {
        public void Configure(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Mes).IsRequired();
            builder.Property(x => x.Monto).IsRequired();
            builder.Property(x => x.FechaCreacion).IsRequired();
            builder.Property(x => x.TipoGastoId).IsRequired();

            //Configuración de las relaciones
            builder.HasOne(x => x.TipoGasto).WithMany()
                .HasForeignKey(x => x.TipoGastoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
