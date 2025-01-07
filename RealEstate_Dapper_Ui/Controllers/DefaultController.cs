using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_Ui.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
