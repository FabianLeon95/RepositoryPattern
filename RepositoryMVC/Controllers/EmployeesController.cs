using RepositoryMVC.Models;
using RepositoryMVC.Repositories;
using System.Web.Mvc;

namespace RepositoryMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _repository;

        public EmployeesController()
        {
            _repository = new EmployeeRepository();
        }

        public EmployeesController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>A view containing the list of employees.</returns>
        public ActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }

        /// <summary>
        /// Gets the list of all employees by their gender.
        /// </summary>
        /// <param name="id">Gender name.</param>
        /// <returns>A view containing the list of employees.</returns>
        public ActionResult Gender(string id)
        {
            var employees = _repository.GetByGender(id);
            return View("Index", employees);
        }

        public ActionResult Department(string id)
        {
            var employees = _repository.GetByDepartment(id);
            return View("Index", employees);
        }

        public ActionResult Details(int id)
        {
            var employee = _repository.GetById(id);
            if (employee != null)
            {
                return View(employee);
            }

            return HttpNotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _repository.Insert(employee);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee = _repository.GetById(id);
            if (employee != null)
            {
                return View(employee);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _repository.Update(employee);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var employee = _repository.GetById(id);
            if (employee != null)
            {
                return View(employee);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}