using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
