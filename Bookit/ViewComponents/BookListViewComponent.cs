using Bookit.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookit.ViewComponents
{
    public class BookListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public BookListViewComponent(ApplicationDbContext db, ILogger<BookListViewComponent> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("Reading database...");
            var model = await _db.Books.Take(4).ToListAsync();
            return View(model);
        }
    }
}
