using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PT_SmartBit.Modelos;

namespace PT_SmartBit.AccesoDatos.Repositorio.IRepositorio
{
    public interface IDepositoRepositorio : IRepositorio<Deposito>
    {
        void Actualizar(Deposito deposito);

        IEnumerable<SelectListItem> ObtenerTodosDropdownList(string obj);
    }
}
