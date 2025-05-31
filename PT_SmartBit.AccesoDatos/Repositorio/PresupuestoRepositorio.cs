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
    public class PresupuestoRepositorio : Repositorio<Presupuesto>, IPresupuestoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PresupuestoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Actualizar(Presupuesto presupuesto)
        {
            var presupuestoBD = _db.Presupuestos.FirstOrDefault(x => x.Id == presupuesto.Id);
            if (presupuestoBD != null)
            {
                presupuestoBD.Mes = presupuesto.Mes;
                presupuestoBD.Monto = presupuesto.Monto;
                presupuestoBD.FechaCreacion = presupuesto.FechaCreacion;
                presupuestoBD.TipoGastoId = presupuesto.TipoGastoId;
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownList(string obj)
        {
            if(obj == "TipoGasto")
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
