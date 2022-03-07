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
            //Jeśli nie admin i hasło to 'haslo' zaloguje jako pracownik
            bool employee = !admin && pass.Equals("haslo");
            //Jeśli nic z powyższych to zostanie na stronie

            //Przekierowywanie w zależności od roli użytkownika
            if (admin) return RedirectToAction("Index", "AdminPanel");
            else if (employee) return RedirectToAction("Index", "EmployeePanel");
            else return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}