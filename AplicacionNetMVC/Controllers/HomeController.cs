using AplicacionNetMVC.Datos;
using AplicacionNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AplicacionNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContex _contexto;

        public HomeController(ApplicationDBContex contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuario.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //para prevenir ataques de sitios o dominios externos
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
                await _contexto.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se creo correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(usuario);
                await _contexto.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se edito correctamente";
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarRegitro(int? id)
        {   
            var usuario =await _contexto.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _contexto.Usuario.Remove(usuario);
            await _contexto.SaveChangesAsync();
            TempData["Mensaje"] = "Registro borrado correctamente";

            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}