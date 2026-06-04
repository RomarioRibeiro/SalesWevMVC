using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModel;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exception;

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
        public IActionResult Create(VendedoresFormViewModel viewModel)
        {
            _vendedoresServeice.Insert(viewModel.Vendedores);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresServeice.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
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
                return NotFound();
            }
            var obj = _vendedoresServeice.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedoresServeice.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedoresFormViewModel viewModel = new VendedoresFormViewModel { Vendedores = obj, Departamentos = departamentos };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedores vendedores)
        {
            if (id != vendedores.Id)
            {
                return BadRequest();
            }
            try
            {
                _vendedoresServeice.Update(vendedores);
                return RedirectToAction(nameof(Index));

            }
            catch (NotFountException e)
            {
                return NotFound();
            }
            catch (DbConcurrencyException e)
            {
                return BadRequest();
            }
        }

    }
}
