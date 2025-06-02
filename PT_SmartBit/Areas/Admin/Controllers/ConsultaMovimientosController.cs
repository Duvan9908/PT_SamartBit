using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;
using PT_SmartBit.Modelos.ViewModels;

namespace PT_SmartBit.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ConsultaMovimientosController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public ConsultaMovimientosController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime? fechaInicial, DateTime? fechaFinal)
        {            
            if(fechaInicial != null && fechaFinal != null)
            {
                return RedirectToAction("Consultar", new { fechaInicial, fechaFinal });                
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Consultar(DateTime? fechaInicial, DateTime? fechaFinal)
        {
            ConsultaMovimientosVM consultaMovimientosVM = new ConsultaMovimientosVM();
            if (fechaInicial != null && fechaFinal != null)
            {
                var gastoEncabezados = await _unidadTrabajo.GastoEncabezado.ObtenerTodos(incluirPropiedades: "FondoMonetario");
                consultaMovimientosVM.GastoDetalles = await _unidadTrabajo.GastoDetalle.ObtenerTodos(f => f.GastoEncabezado.Fecha >= fechaInicial
                                                                                  && f.GastoEncabezado.Fecha <= fechaFinal,
                                                                                  incluirPropiedades: "GastoEncabezado,TipoGasto");
                consultaMovimientosVM.Depositos = await _unidadTrabajo.Deposito.ObtenerTodos(f => f.Fecha >= fechaInicial
                                                                                && f.Fecha <= fechaFinal,
                                                                                incluirPropiedades: "FondoMonetario");
                return View(consultaMovimientosVM);
            }
            else
            {
                return View();
            }
        }
    }
}
