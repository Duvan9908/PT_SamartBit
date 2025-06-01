using Microsoft.AspNetCore.Mvc;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;
using PT_SmartBit.Modelos.ViewModels;
using PT_SmartBit.Utilidades;

namespace PT_SmartBit.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepositoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public DepositoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            DepositoVM depositoVM = new DepositoVM()
            {
                Deposito = new Deposito(),
                FondoMonetarioLista = _unidadTrabajo.Deposito.ObtenerTodosDropdownList("FondoMonetario")
            };
            //Crear un registro
            if(Id == null)
            {
                depositoVM.Deposito.Fecha = DateTime.Now;
                return View(depositoVM);
            }
            //Actualizar el registro
            else
            {
                depositoVM.Deposito = await _unidadTrabajo.Deposito.Obtener(Id.GetValueOrDefault());
                if(depositoVM.Deposito == null)
                {
                    return NotFound();
                }
                return View(depositoVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(DepositoVM depositoVM)
        {
           if(ModelState.IsValid)
           {
                //Crear un registro
                if(depositoVM.Deposito.Id == 0)
                {
                    await _unidadTrabajo.Deposito.Agregar(depositoVM.Deposito);
                    TempData[DS.Exito] = "¡Registro creado con exito!";
                }
                else //Actualizar un registro
                {
                    _unidadTrabajo.Deposito.Actualizar(depositoVM.Deposito);
                    TempData[DS.Exito] = "¡Registro actualizado con exito!";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
           }
            depositoVM.FondoMonetarioLista = _unidadTrabajo.Deposito.ObtenerTodosDropdownList("FondoMonetario");
            TempData[DS.Error] = "¡Error en la transacción!";
            return View(depositoVM);
        }

        #region API       
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Deposito.ObtenerTodos(incluirPropiedades:"FondoMonetario");
            return Json(new { data = todos });
        }        

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var depositoDb = await _unidadTrabajo.Deposito.Obtener(Id);
            if(depositoDb == null)
            {
                return Json(new { success = false, message = "¡Error al eliminar el registro!" });
            }
            _unidadTrabajo.Deposito.Remover(depositoDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "¡Registro eliminado correctamente!" });
        }
        #endregion
    }
}
