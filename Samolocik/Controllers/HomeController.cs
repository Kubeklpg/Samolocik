using Microsoft.AspNetCore.Mvc;
using Samolocik.Models;
using System.Diagnostics;

namespace Samolocik.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitAction(IFormCollection collection)
        {
            //Pobieranie danych z formularza
            string login = collection["login"];
            string pass = collection["pass"];

            //Sprawdzanie poprawności danych logowania i przydzielania roli użytkownikowi
            //Jeśli login zaczyna się od 'admin' i hasło to 'admin' zaloguje jako administrator
            bool admin= login.StartsWith("admin") && pass.Equals("admin");
            //Jeśli nie jest adminem, hasło to 'haslo' i login zawiera "hr", "koordynator" lub "przewoznik" - zaloguje jako pracownik
            bool employee = !admin && pass.Equals("haslo") && (login.Contains("hr") || login.Contains("koordynator") || login.Contains("przewoznik"));
            string employeeType = "";
            if (employee)
            {
                employeeType = login.Contains("hr") ? "HR" : login.Contains("koordynator") ? "Koordynator" : login.Contains("przewoznik") ? "Przewoznik" : "";
                ViewData["Title"] = employeeType;
            }
            //Jeśli nic z powyższych to zostanie na stronie

            //Przekierowywanie w zależności od roli użytkownika
            if (admin) return RedirectToAction("Index", "AdminPanel");
            else if (employee && employeeType.Length>1) return RedirectToAction(employeeType, "EmployeePanel");
            else return RedirectToAction("Index");
        }
    }
}