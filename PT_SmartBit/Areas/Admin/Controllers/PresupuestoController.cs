using Microsoft.AspNetCore.Mvc;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;
using PT_SmartBit.Modelos.ViewModels;
using PT_SmartBit.Utilidades;

namespace PT_SmartBit.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PresupuestoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public PresupuestoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            PresupuestoVM presupuestoVM = new PresupuestoVM()
            {
                Presupuesto = new Presupuesto(),
                TipoGastoLista = _unidadTrabajo.Presupuesto.ObtenerTodosDropdownList("TipoGasto")
            };
            //Crear un registro
            if(Id == null)
            {
                presupuestoVM.Presupuesto.Mes = DateTime.Now;
                presupuestoVM.Presupuesto.FechaCreacion = DateTime.Now;
                return View(presupuestoVM);
            }
            //Actualizar el registro
            else
            {
                presupuestoVM.Presupuesto = await _unidadTrabajo.Presupuesto.Obtener(Id.GetValueOrDefault());
                if(presupuestoVM.Presupuesto == null)
                {
                    return NotFound();
                }
                return View(presupuestoVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PresupuestoVM presupuestoVM)
        {
           if(ModelState.IsValid)
           {
                //Crear un registro
                if(presupuestoVM.Presupuesto.Id == 0)
                {
                    await _unidadTrabajo.Presupuesto.Agregar(presupuestoVM.Presupuesto);
                    TempData[DS.Exito] = "¡Registro creado con exito!";
                }
                else //Actualizar un registro
                {
                    _unidadTrabajo.Presupuesto.Actualizar(presupuestoVM.Presupuesto);
                    TempData[DS.Exito] = "¡Registro actualizado con exito!";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
           }
            presupuestoVM.TipoGastoLista = _unidadTrabajo.Presupuesto.ObtenerTodosDropdownList("TipoGasto");
            TempData[DS.Error] = "¡Error en la transacción!";
            return View(presupuestoVM);
        }

        #region API       
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Presupuesto.ObtenerTodos(incluirPropiedades:"TipoGasto");
            return Json(new { data = todos });
        }        

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var presupuestoDb = await _unidadTrabajo.Presupuesto.Obtener(Id);
            if(presupuestoDb == null)
            {
                return Json(new { success = false, message = "¡Error al eliminar el registro!" });
            }
            _unidadTrabajo.Presupuesto.Remover(presupuestoDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "¡Registro eliminado correctamente!" });
        }
        #endregion
    }
}
