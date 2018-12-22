using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookit.Common;
using Bookit.Data;
using Bookit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookit.Controllers
{
    //[Authorize(Roles ="Admin")]
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

        [AllowAnonymous]
        [Route("book/gallery/{year:int:min(2015)}")]
        [Route("book/gallery/{term?}")]
        public IActionResult Gallery(string term="",int? year=null)
        {
            IEnumerable<Book> model;

            if (year.HasValue)
            {
                model = _db.Books.Where(b => b.Year==year);
                return View(model);
            }

            if (string.IsNullOrEmpty(term))
            {
                model = _db.Books;
            }
            else
            {
                model = _db.Books.Where(b => b.Name.Contains(term));
            }
            ViewData["term"] = term;
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet("book/info/{bookId}")]
        public IActionResult More(int bookId)
        {
            var model = _db.Books.Find(bookId);
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
            TempData["message"] = "New book '" + model.Name + "' added.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        public IActionResult Edit(Book model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        public IActionResult Delete(Book model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}