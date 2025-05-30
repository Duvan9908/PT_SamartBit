using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT_SmartBit.Modelos;

namespace PT_SmartBit.AccesoDatos.Repositorio.IRepositorio
{
    public interface ITipoGastoRepositorio : IRepositorio<TipoGasto>
    {
        void Actualizar(TipoGasto tipoGasto);
    }
}
