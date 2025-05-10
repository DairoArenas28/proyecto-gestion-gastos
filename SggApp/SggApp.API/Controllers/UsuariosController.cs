using Microsoft.AspNetCore.Mvc;
using SggApp.BLL.Interfaces;
using SggApp.Domain.Entidades;

namespace SggApp.API.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: /Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ObtenerTodosAsync();
            return View(usuarios);
        }

        // GET: /Usuarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var u = await _usuarioService.ObtenerPorIdAsync(id);
            if (u == null) return NotFound();
            return View(u);
        }

        // GET: /Usuarios/Create
        public IActionResult Create() => View();

        // POST: /Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario model)
        {
            if (!ModelState.IsValid) return View(model);
            await _usuarioService.AgregarAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Usuarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var u = await _usuarioService.ObtenerPorIdAsync(id);
            if (u == null) return NotFound();
            return View(u);
        }

        // POST: /Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            await _usuarioService.ActualizarAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Usuarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _usuarioService.ObtenerPorIdAsync(id);
            if (u == null) return NotFound();
            return View(u);
        }

        // POST: /Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioService.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
