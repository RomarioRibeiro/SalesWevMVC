using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class VendasRecordsController : Controller
    {

        private readonly VendasRecordService _vendasRecordService;

        public VendasRecordsController(VendasRecordService vendorRecordService)
        {
            _vendasRecordService = vendorRecordService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public async  Task<IActionResult> BuscaSimples(DateTime? minData, DateTime? maxData)
        {
            if (!minData.HasValue)
            {
                minData = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxData.HasValue)
            {
                maxData = DateTime.Now;
            }

            ViewData["minData"] = minData.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = maxData.Value.ToString("yyyy-MM-dd");
            var result = await _vendasRecordService.FindByDataAsync(minData, maxData);
            return View(result);
        }
        public IActionResult GroupBusca()
        {
            return View();
        }
    }
}
