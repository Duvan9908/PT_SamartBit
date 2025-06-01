using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PT_SmartBit.Modelos.ViewModels
{
    public class DepositoVM
    {
        public Deposito Deposito { get; set; }
        public IEnumerable<SelectListItem> FondoMonetarioLista { get; set; }
    }
}
