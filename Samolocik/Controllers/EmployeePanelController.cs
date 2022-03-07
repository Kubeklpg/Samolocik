using Microsoft.AspNetCore.Mvc;

namespace Samolocik.Controllers
{
    public class EmployeePanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
