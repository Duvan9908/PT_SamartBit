using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ITipoGastoRepositorio TipoGasto { get; }
        IFondoMonetarioRepositorio FondoMonetario { get; }
        IPresupuestoRepositorio Presupuesto { get; }
        Task Guardar();
    }
}
