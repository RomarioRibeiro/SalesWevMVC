using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Descricao = "Inovação" });
            list.Add(new Departamento { Id = 2, Descricao = "Sucesso do Cliente" });

            return View(list);
        }
    }
}
