using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDb.Models;

namespace MVCDb.Controllers
{
    public class DeptController : Controller
    {
        IDept repos;
        public DeptController(IDept _repost)
        {
            repos = _repost;
        }

        public IActionResult List()
        {
            var data = repos.GetDepts();
            return View(data);
        }
        public IActionResult Display(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dept dept)//remain on that screen or will save the data
        {
            if (ModelState.IsValid)
            {
                repos.AddDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Dept dept)
        {
            if (ModelState.IsValid)
            {
                repos.EditDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
        [HttpGet]
        public IActionResult Deleted(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Deleted(Dept dept)
        {
            repos.DeleteDept(dept.Id);
            return RedirectToAction("List");
        }
    }
}
