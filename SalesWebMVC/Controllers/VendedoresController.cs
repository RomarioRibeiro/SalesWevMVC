using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresServeice _vendedoresServeice;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedoresServeice vendedoresServeice, DepartamentoService departamentoService)
        {
            _vendedoresServeice = vendedoresServeice;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedoresServeice.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var listDepartamentos = _departamentoService.FindAll();
            ViewBag.Departamentos = new SelectList(listDepartamentos, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedores vendedores)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Departamentos = new SelectList(_departamentoService.FindAll(), "Id", "Descricao");
            //    return View(vendedores);
            //}

            _vendedoresServeice.Insert(vendedores);
            return RedirectToAction(nameof(Index));
        }
    }
}
