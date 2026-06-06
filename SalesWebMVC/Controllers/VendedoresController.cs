using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModel;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exception;
using System.Diagnostics;

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
            var viewModel = new VendedoresFormViewModel
            {
                Vendedores = new Vendedores(),
                Departamentos = listDepartamentos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedores vendedores)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedoresFormViewModel { Vendedores = vendedores, Departamentos = departamentos };
                return View(viewModel);
            }
            _vendedoresServeice.Insert(vendedores);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id veio vazio" });
            }
            var obj = _vendedoresServeice.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedoresServeice.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id veio vazio" });
            }
            var obj = _vendedoresServeice.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id veio vazio" });
            }

            var obj = _vendedoresServeice.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedoresFormViewModel viewModel = new VendedoresFormViewModel { Vendedores = obj, Departamentos = departamentos };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedores vendedores)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedoresFormViewModel { Vendedores = vendedores, Departamentos = departamentos };
                return View(viewModel);
            }
            if (id != vendedores.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id e diferente do vendedor" });
            }
            try
            {
                _vendedoresServeice.Update(vendedores);
                return RedirectToAction(nameof(Index));

            }
            catch (NotFountException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
