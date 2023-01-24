using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePAYrollMVC.Controllers
{
    public class EmployeePayrollController : Controller
    {
        
        private readonly IUserBL UserBL;
        public EmployeePayrollController(IUserBL userBL)
        {
            UserBL = userBL;
        }
        public IActionResult Index()
        {
            List<EmployeePModel> lstEmployee = new List<EmployeePModel>();
            lstEmployee = UserBL.GetAllEmployeesDetails().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] EmployeePModel employee)
        {
            if (ModelState.IsValid)
            {
                UserBL.AddEmployees(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeePModel employee = UserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EmployeePModel employee)
        {
            if (id != employee.Emplooyeeid)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                UserBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
