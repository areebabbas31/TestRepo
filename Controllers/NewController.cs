using System;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class NewController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NewController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /Test
        public IActionResult Index()
        {
            var news = _db.News.ToList();
            return View(news);
        }

        // GET: /Test/AddRandom
        public IActionResult AddRandom()
        {
            var rnd = new Random();
            var news = new New
            {
                Number = rnd.Next(1, 1000) // random number between 1–999
            };

            _db.News.Add(news);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}


