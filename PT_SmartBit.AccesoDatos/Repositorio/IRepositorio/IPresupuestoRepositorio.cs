using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PT_SmartBit.Modelos;

namespace PT_SmartBit.AccesoDatos.Repositorio.IRepositorio
{
    public interface IPresupuestoRepositorio : IRepositorio<Presupuesto>
    {
        void Actualizar(Presupuesto presupuesto);

        IEnumerable<SelectListItem> ObtenerTodosDropdownList(string obj);
    }
}
