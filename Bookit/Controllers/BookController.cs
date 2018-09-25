using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookit.Data;
using Bookit.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookit.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.Books;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            _db.Books.Add(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }
    }
}