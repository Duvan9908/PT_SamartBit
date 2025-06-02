using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.Modelos.ViewModels
{
    public class ConsultaMovimientosVM
    {
        public IEnumerable<GastoDetalle> GastoDetalles { get; set; }

        public IEnumerable<Deposito> Depositos { get; set; }
        //public GastoDetalle GastoDetalle { get; set; }
        //public Deposito Deposito { get; set; }
    }
}
