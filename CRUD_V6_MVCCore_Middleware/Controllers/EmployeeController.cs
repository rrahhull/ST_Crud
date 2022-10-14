using CRUD_V6_MVCCore_Middleware.Data;
using CRUD_V6_MVCCore_Middleware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CRUD_V6_MVCCore_Middleware.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> ObjCatlist = _context.Employees;
            /*if (ObjCatlist == null) 
            {
                return View("Error");  
            }*/
            return View(ObjCatlist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee empobj)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(empobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee Emp)
        {
            try
            {
                var data = _context.Employees.Where(x => x.Id == Emp.Id).FirstOrDefault();
                if (data != null)
                {
                    data.Name = Emp.Name;
                    data.Designation = Emp.Designation;
                    data.Address = Emp.Address;
                    data.RecordCreatedOn = Emp.RecordCreatedOn;
                    _context.Employees.Update(data);
                    _context.SaveChanges();
                    TempData["ResultOk"] = "Data Updated Successfully !";
                }
               // return data;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = _context.Employees.Find(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int? id)
        {
            var deleterecord = _context.Employees.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
