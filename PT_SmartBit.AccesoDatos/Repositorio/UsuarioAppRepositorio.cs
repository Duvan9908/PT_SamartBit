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
    public class UsuarioAppRepositorio : Repositorio<UsuarioApp>, IUsuarioAppRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioAppRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }               
    }
}
