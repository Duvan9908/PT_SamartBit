using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PT_SmartBit.AccesoDatos.Data;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;

namespace PT_SmartBit.AccesoDatos.Repositorio
{
    public class GastoDetalleRepositorio : Repositorio<GastoDetalle>, IGastoDetalleRepositorio
    {
        private readonly ApplicationDbContext _db;

        public GastoDetalleRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Actualizar(GastoDetalle gastoDetalle)
        {
            var gastoDetalleBD = _db.GastosDetalles.FirstOrDefault(x => x.Id == gastoDetalle.Id);
            if (gastoDetalleBD != null)
            {
                gastoDetalleBD.Monto = gastoDetalle.Monto;
                gastoDetalleBD.GastoEncabezadoId = gastoDetalle.GastoEncabezadoId;
                gastoDetalleBD.TipoGastoId = gastoDetalle.TipoGastoId;                

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownList(string obj)
        {
            if(obj == "GastoEncabezado")
            {
                return _db.GastosEncabezados.Select(x => new SelectListItem
                {
                    Text = x.Fecha.ToString(),
                    Value = x.Id.ToString()
                });
            }
            if (obj == "TipoGasto")
            {
                return _db.TipoGastos.Where(x => x.Activo == true).Select(x => new SelectListItem
                {
                    Text = x.Nombre.ToString(),
                    Value = x.Id.ToString()
                });
            }
            return null;
        }
    }
}
