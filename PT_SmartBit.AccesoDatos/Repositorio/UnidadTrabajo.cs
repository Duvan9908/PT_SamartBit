using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT_SmartBit.AccesoDatos.Data;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;

namespace PT_SmartBit.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ITipoGastoRepositorio TipoGasto { get; private set; }
        public IFondoMonetarioRepositorio FondoMonetario { get; private set; }
        public IPresupuestoRepositorio Presupuesto { get; private set; }
        public IGastoEncabezadoRepositorio GastoEncabezado { get; private set; }
        public IGastoDetalleRepositorio GastoDetalle { get; private set; }
        public IDepositoRepositorio Deposito { get; private set; }
        public IUsuarioAppRepositorio UsuarioApp {  get; private set; }
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            TipoGasto = new TipoGastoRepositorio(_db);
            FondoMonetario = new FondoMonetarioRepositorio(_db);
            Presupuesto = new PresupuestoRepositorio(_db);
            GastoEncabezado = new GastoEncabezadoRepositorio(_db);
            GastoDetalle = new GastoDetalleRepositorio(_db);
            Deposito = new DepositoRepositorio(_db);
            UsuarioApp = new UsuarioAppRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
