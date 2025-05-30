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
    public class FondoMonetarioRepositorio : Repositorio<FondoMonetario>, IFondoMonetarioRepositorio 
    {
        private readonly ApplicationDbContext _db;

        public FondoMonetarioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(FondoMonetario fondoMonetario)
        {
            var fondoMonBD = _db.FondosMonetarios.FirstOrDefault(x => x.Id == fondoMonetario.Id);
            if(fondoMonBD != null)
            {
                fondoMonBD.Nombre = fondoMonetario.Nombre;
                fondoMonBD.Tipo = fondoMonetario.Tipo;
                fondoMonBD.Descripcion = fondoMonetario.Descripcion;
                fondoMonBD.Activo = fondoMonetario.Activo;
                _db.SaveChanges();
            }
        }
    }
}
