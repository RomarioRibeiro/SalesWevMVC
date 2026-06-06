using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers
{
    public class VendasRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BuscaSimples()
        {
            return View();
        }
        public IActionResult GroupBusca()
        {
            return View();
        }
    }
}
