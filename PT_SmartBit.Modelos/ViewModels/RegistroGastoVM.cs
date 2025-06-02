using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PT_SmartBit.Modelos.ViewModels
{
    public class RegistroGastoVM
    {
        public GastoEncabezado GastoEncabezado { get; set; }

        public IEnumerable<SelectListItem> FondoMonetarioLista { get; set; }


        //public List<GastoDetalle> GastoDetalles { get; set; } = new();
        public GastoDetalle GastoDetalle { get; set; }

        //public IEnumerable<SelectListItem> GastoEncabezadoLista { get; set; }
        public IEnumerable<SelectListItem> TipoGastoLista { get; set; }
    }
}
