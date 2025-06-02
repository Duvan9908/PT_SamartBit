using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PT_SmartBit.AccesoDatos.Data;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;
using PT_SmartBit.Modelos.ViewModels;
using PT_SmartBit.Utilidades;

namespace PT_SmartBit.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RegistroGastoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly ApplicationDbContext _context;

        public RegistroGastoController(IUnidadTrabajo unidadTrabajo, ApplicationDbContext context)
        {
            _unidadTrabajo = unidadTrabajo;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            RegistroGastoVM registroGastoVM = new RegistroGastoVM()
            {
                GastoEncabezado = new GastoEncabezado(),
                FondoMonetarioLista = _unidadTrabajo.GastoEncabezado.ObtenerTodosDropdownList("FondoMonetario"),              
                GastoDetalle = new GastoDetalle(),
                TipoGastoLista = _unidadTrabajo.GastoDetalle.ObtenerTodosDropdownList("TipoGasto")
            };
            //Crear un registro
            if (Id == null)
            {
                registroGastoVM.GastoEncabezado.Fecha = DateTime.Now;                
                return View(registroGastoVM);
            }
            //Actualizar el registro
            else
            {
                registroGastoVM.GastoEncabezado = await _unidadTrabajo.GastoEncabezado.Obtener(Id.GetValueOrDefault());
                if (registroGastoVM.GastoEncabezado == null)
                {
                    return NotFound();
                }
                return View(registroGastoVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(RegistroGastoVM registroGastoVM)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if(registroGastoVM.GastoDetalle == null)
                {
                    TempData[DS.Error] = "Debe agregar el detalle del gasto.";
                    return View(registroGastoVM);
                }
                var mes = registroGastoVM.GastoEncabezado.Fecha.Month;
                var año = registroGastoVM.GastoEncabezado.Fecha.Year;

                await _unidadTrabajo.GastoEncabezado.Agregar(registroGastoVM.GastoEncabezado);
                await _unidadTrabajo.Guardar();
                var gastoEncabezados = await _unidadTrabajo.GastoEncabezado.ObtenerTodos();
                var idGE = gastoEncabezados.LastOrDefault();
                registroGastoVM.GastoDetalle.GastoEncabezadoId = idGE.Id;
                await _unidadTrabajo.GastoDetalle.Agregar(registroGastoVM.GastoDetalle);
                await _unidadTrabajo.Guardar();
                await transaction.CommitAsync();
                return RedirectToAction(nameof(Index));
                               
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return View(registroGastoVM);
            }
        }

        #region
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var gastoEncabezados = await _unidadTrabajo.GastoEncabezado.ObtenerTodos(incluirPropiedades: "FondoMonetario");
            var gastoDetalle = await _unidadTrabajo.GastoDetalle.ObtenerTodos(incluirPropiedades: "GastoEncabezado,TipoGasto");
            return Json(new { data = gastoDetalle });
        }
        #endregion
    }
}
