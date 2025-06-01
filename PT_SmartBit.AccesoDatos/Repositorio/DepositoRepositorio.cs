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
    public class DepositoRepositorio : Repositorio<Deposito>, IDepositoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public DepositoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Actualizar(Deposito deposito)
        {
            var depositoBD = _db.Depositos.FirstOrDefault(x => x.Id == deposito.Id);
            if (depositoBD != null)
            {
                depositoBD.Fecha = deposito.Fecha;
                depositoBD.Monto = deposito.Monto;
                depositoBD.FondoMonetarioId = deposito.FondoMonetarioId;

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
