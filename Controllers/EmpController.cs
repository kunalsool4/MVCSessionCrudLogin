using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginCrud.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LoginCrud.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmpController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            //ViewBag.sessionv = HttpContext.Session.GetString("username"); 
            if (sessionvalue == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var student = JsonConvert.DeserializeObject<String>(HttpContext.Session.GetString("username"));
            var displaydata = _db.CrudTable.ToList();
            return View(displaydata);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentClass nec)
        {
            if (ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nec);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null)
            {
                return RedirectToAction("Login", "Account");
            }

             if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.CrudTable.FindAsync(id);
            return View(getempdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentClass nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nc);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.CrudTable.FindAsync(id);
            return View(getempdetails);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.CrudTable.FindAsync(id);
            return View(getempdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getempdetails = await _db.CrudTable.FindAsync(id);
            _db.CrudTable.Remove(getempdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
