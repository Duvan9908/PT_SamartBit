using Microsoft.AspNetCore.Mvc;
using PT_SmartBit.AccesoDatos.Repositorio.IRepositorio;
using PT_SmartBit.Modelos;
using PT_SmartBit.Utilidades;

namespace PT_SmartBit.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipoGastoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public TipoGastoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            TipoGasto tipoGasto = new TipoGasto();
            var idReg = await _unidadTrabajo.TipoGasto.ObtenerTodos();
            var codReg = idReg.LastOrDefault();
            var codigo = codReg.Codigo.Substring(2, 3);
            //Identifica si va a crear
            if(Id == null)
            {
                tipoGasto.Codigo = "TG00" + (Convert.ToInt32(codigo) + 1);
                tipoGasto.Activo = true;
                return View(tipoGasto);
            }
            //Si no crea uno lo toma para actualizar
            tipoGasto = await _unidadTrabajo.TipoGasto.Obtener(Id.GetValueOrDefault());
            if(tipoGasto == null)
            {
                return NotFound();
            }
            return View(tipoGasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TipoGasto tipoGasto)
        {
            if(ModelState.IsValid)
            {
                if(tipoGasto.Id == 0)
                {
                    await _unidadTrabajo.TipoGasto.Agregar(tipoGasto);
                    TempData[DS.Exito] = "¡Registro creado exitosamente!";
                }
                else
                {
                    _unidadTrabajo.TipoGasto.Actualizar(tipoGasto);
                    TempData[DS.Exito] = "¡Registro actualizado exitosamente!";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "¡Error en la transacción!";
            return View(tipoGasto);
        }

        #region API       
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.TipoGasto.ObtenerTodos();
            return Json(new { data = todos });
        }        

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var tipoGastoDB = await _unidadTrabajo.TipoGasto.Obtener(Id);
            if(tipoGastoDB == null)
            {
                return Json(new { success = false, message = "¡Error al eliminar el registro!" });
            }
            _unidadTrabajo.TipoGasto.Remover(tipoGastoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "¡Registro eliminado correctamente!" });
        }
        #endregion
    }
}
