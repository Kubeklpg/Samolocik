using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samolocik.Models;

namespace Samolocik.Controllers
{
    public class EmployeeManagementPanelController : Controller
    {
        private static IList<EmployeeModel> GetEmployees()
        {
            //POBIERANIE LISTY PRACOWNIKÓW Z BAZY - na razie rozwiązanie na sztywno
            return new List<EmployeeModel>()
                        {
                            new EmployeeModel()
                            {
                                Id = 0,
                                FirstName = "Paweł",
                                LastName = "Brandt",
                                Login = "admin",
                                Password = "admin",
                                JobTitle = "Administrator",
                                CreatedDate  = DateTime.Now,
                                CanAddEmployees  = true,
                                CanAddUsers  = true,
                                CanAddFlights  = true,
                                CanAddAirports  = true,
                                CanAddPlanes  = true,
                                CanAddAirLines  = true
                            }
                        };
        }
        // GET: ManagementPanelController
        public ActionResult Index()
        {
            return View(GetEmployees());
        }

        // GET: ManagementPanelController/Details/5
        public ActionResult Details(int id)
        {
            return View(GetEmployees()[id]);
        }

        // GET: ManagementPanelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //INSERT DO BAZY Z NOWYM PRACOWNIKIEM  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagementPanelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetEmployees()[id]);
        }

        // POST: ManagementPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                //UPDATE PRACOWNIKA O ID Z PARAMETRU
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagementPanelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetEmployees()[id]);
        }

        // POST: ManagementPanelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                //DELETE PRACOWNIKA O ID Z PARAMETRU
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
