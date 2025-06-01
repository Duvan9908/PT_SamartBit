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
    public class DepositoConfiguracion : IEntityTypeConfiguration<Deposito>
    {
        public void Configure(EntityTypeBuilder<Deposito> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Fecha).IsRequired();
            builder.Property(x => x.Monto).IsRequired();
            builder.Property(x => x.FondoMonetarioId).IsRequired();

            //Configuración de las relaciones
            builder.HasOne(x => x.FondoMonetario).WithMany()
                .HasForeignKey(x => x.FondoMonetarioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
