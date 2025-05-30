using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT_SmartBit.AccesoDatos.Data;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;

namespace PT_SmartBit.AccesoDatos.Repositorio
{
    public class TipoGastoRepositorio : Repositorio<TipoGasto>, ITipoGastoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public TipoGastoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }        

        public void Actualizar(TipoGasto tipoGasto)
        {
            var tipoGastoBD = _db.TipoGastos.FirstOrDefault(x => x.Id == tipoGasto.Id);
            if(tipoGastoBD != null)
            {
                tipoGastoBD.Codigo = tipoGasto.Codigo;
                tipoGastoBD.Nombre = tipoGasto.Nombre;
                tipoGasto.Descripcion = tipoGasto.Descripcion;
                tipoGastoBD.Activo = tipoGasto.Activo;
                _db.SaveChanges();
            }
        }
    }
}
