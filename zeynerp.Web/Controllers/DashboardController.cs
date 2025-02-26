using Microsoft.AspNetCore.Mvc;

namespace zeynerp.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}