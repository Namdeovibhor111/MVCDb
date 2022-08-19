using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDb.Controllers
{
    public class EmpController : Controller
    {
        DB1045Context db = new DB1045Context();

        public IActionResult List()
        {
            var empdata = db.Emps.Include("Dept").ToList();
            return View(empdata);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Depid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var empdata = db.Emps.Find(id);
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(empdata);
        }
        [HttpPost]
        public IActionResult Edit(Emp emp)
        {
            if(ModelState.IsValid)
            {
                var odata = db.Emps.Find(emp.Id);
                odata.Name = emp.Name;
                odata.Salary = emp.Salary;
                odata.Email = emp.Email;    
                odata.Deptid = emp.Deptid;
                odata.Dob = emp.Dob;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
        public JsonResult EmailCheck(string Email)
        {
            bool yesno = db.Emps.Any(x => x.Email == Email);
            return Json(!yesno);
        }
    }
}
