using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsNDishesContext dbContext;

        public HomeController(ChefsNDishesContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(d => d.DishesMade).ToList();
            return View(AllChefs);
        }
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(c => c.Chef).ToList();
            return View("dishes", AllDishes);
        }
        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("newChef");
        }
        [HttpPost("NewChef")]
        public IActionResult CreateChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Chefs.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("newChef");
        }
        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.AllChef = dbContext.Chefs.ToList();
            return View("newDish");
        }
        [HttpPost("NewDish")]
        public IActionResult CreateDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("dishes");
            }
            else
                ViewBag.AllChef = dbContext.Chefs.ToList();
                return View("newDish");

        }

    }
}
