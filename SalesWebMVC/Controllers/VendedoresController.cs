using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedoresServeice _vendedoresServeice;
    
        public VendedoresController(VendedoresServeice vendedoresServeice)
        {
            _vendedoresServeice = vendedoresServeice;
        }

        public IActionResult Index()
        {
            var list = _vendedoresServeice.FindAll();
            return View(list);
        }




    }
}
