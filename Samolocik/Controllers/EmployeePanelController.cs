using Microsoft.AspNetCore.Mvc;
using Samolocik.Models;

namespace Samolocik.Controllers
{
    public class EmployeePanelController : Controller
    {
        
        public IActionResult HR()
        {
            return View();
        }
        public IActionResult Koordynator()
        {
            return View();
        }
        public IActionResult Przewoznik()
        {
            return View();
        }
    }
}
