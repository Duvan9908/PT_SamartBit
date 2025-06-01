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
    public class GastoEncabezadoRepositorio : Repositorio<GastoEncabezado>, IGastoEncabezadoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public GastoEncabezadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Actualizar(GastoEncabezado gastoEncabezado)
        {
            var gastoEncabezadoBD = _db.GastosEncabezados.FirstOrDefault(x => x.Id == gastoEncabezado.Id);
            if (gastoEncabezadoBD != null)
            {
                gastoEncabezadoBD.Fecha = gastoEncabezado.Fecha;
                gastoEncabezadoBD.Observaciones = gastoEncabezado.Observaciones;
                gastoEncabezadoBD.NombreComercio = gastoEncabezado.NombreComercio;
                gastoEncabezadoBD.TipoDocumento = gastoEncabezado.TipoDocumento;
                gastoEncabezadoBD.FondoMonetarioId = gastoEncabezado.FondoMonetarioId;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownList(string obj)
        {
            if(obj == "FondoMonetario")
            {
                return _db.FondosMonetarios.Where(x => x.Activo == true).Select(x => new SelectListItem
                {
                    Text = x.Nombre.ToString(),
                    Value = x.Id.ToString()
                });
            }
            return null;
        }
    }
}
