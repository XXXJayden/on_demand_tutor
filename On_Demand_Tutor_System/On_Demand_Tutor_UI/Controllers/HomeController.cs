using Microsoft.AspNetCore.Mvc;

namespace On_Demand_Tutor_UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
