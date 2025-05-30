using Microsoft.AspNetCore.Mvc;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;
using PT_SmartBit.Utilidades;

namespace PT_SmartBit.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FondoMonetarioController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public FondoMonetarioController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            FondoMonetario fondoMonetario = new FondoMonetario();            
            //Identifica si va a crear
            if(Id == null)
            {                
                fondoMonetario.Activo = true;
                return View(fondoMonetario);
            }
            //Si no crea uno lo toma para actualizar
            fondoMonetario = await _unidadTrabajo.FondoMonetario.Obtener(Id.GetValueOrDefault());
            if(fondoMonetario == null)
            {
                return NotFound();
            }
            return View(fondoMonetario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(FondoMonetario fondoMonetario)
        {
            if(ModelState.IsValid)
            {
                if(fondoMonetario.Id == 0)
                {
                    await _unidadTrabajo.FondoMonetario.Agregar(fondoMonetario);
                    TempData[DS.Exito] = "¡Registro creado exitosamente!";
                }
                else
                {
                    _unidadTrabajo.FondoMonetario.Actualizar(fondoMonetario);
                    TempData[DS.Exito] = "¡Registro actualizado exitosamente!";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "¡Error en la transacción!";
            return View(fondoMonetario);
        }

        #region API       
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.FondoMonetario.ObtenerTodos();
            return Json(new { data = todos });
        }        

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var fondoMonDb = await _unidadTrabajo.FondoMonetario.Obtener(Id);
            if(fondoMonDb == null)
            {
                return Json(new { success = false, message = "¡Error al eliminar el registro!" });
            }
            _unidadTrabajo.FondoMonetario.Remover(fondoMonDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "¡Registro eliminado correctamente!" });
        }
        #endregion
    }
}
