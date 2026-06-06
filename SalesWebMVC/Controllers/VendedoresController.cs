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

        public async Task<IActionResult> Index()
        {
            var list = await _vendedoresServeice.FindAllAsyn();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var listDepartamentos = await _departamentoService.FindAllAsync();
            var viewModel = new VendedoresFormViewModel
            {
                Departamentos = listDepartamentos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendedoresFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departamentos = await _departamentoService.FindAllAsync();
                return View(viewModel);
            }

            var departamento = await _departamentoService.FindByIdAsync(viewModel.Vendedores.DepartamentoId);
            if (departamento == null)
            {
                ModelState.AddModelError("Vendedores.DepartamentoId", "Departamento inválido");
                viewModel.Departamentos = await _departamentoService.FindAllAsync();
                return View(viewModel);
            }

            viewModel.Vendedores.Departamento = departamento;

            await _vendedoresServeice.InsertAsync(viewModel.Vendedores);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id veio vazio" });
            }
            var obj = await _vendedoresServeice.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendedoresServeice.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id veio vazio" });
            }
            var obj = await _vendedoresServeice.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id veio vazio" });
            }

            var obj = await _vendedoresServeice.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            VendedoresFormViewModel viewModel = new VendedoresFormViewModel { Vendedores = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VendedoresFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departamentos = await _departamentoService.FindAllAsync();
                return View(viewModel);
            }

            var departamento = await _departamentoService.FindByIdAsync(viewModel.Vendedores.DepartamentoId);
            if (departamento == null)
            {
                ModelState.AddModelError("Vendedores.DepartamentoId", "Departamento inválido");
                viewModel.Departamentos = await _departamentoService.FindAllAsync();
                return View(viewModel);
            }

            viewModel.Vendedores.Departamento = departamento;

            if (id != viewModel.Vendedores.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id e diferente do vendedor" });
            }

            try
            {
                await _vendedoresServeice.UpdateAsync(viewModel.Vendedores);
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
