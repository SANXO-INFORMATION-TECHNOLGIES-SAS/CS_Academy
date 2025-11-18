using Microsoft.AspNetCore.Mvc;
using InscripcionesWebApp.Models;
using InscripcionesWebApp.Services;
using System.Linq;


namespace InscripcionesWebApp.Controllers
{
    public class InscripcionesController : Controller
    {
        private readonly InscripcionService _service;
        public InscripcionesController(InscripcionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Inscripcion model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _service.AgregarInscripcion(model);
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _service.ObtenerInscripciones();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            var item = _service.ObtenerInscripciones().FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Editar(Inscripcion model)
        {
            if (!ModelState.IsValid) return View(model);
            _service.EditarInscripcion(model);
            return RedirectToAction(nameof(Listar));
        }

        [HttpPost]
        public IActionResult Eliminar(string id)
        {
            _service.EliminarInscripcion(id);
            return RedirectToAction(nameof(Listar));
        }
    }
}
