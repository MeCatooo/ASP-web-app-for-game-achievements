using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    public class AchievementController : Controller
    {
        static List<Achievement> achievements = new List<Achievement>();
        public IActionResult Index()
        {
            return View(achievements);
        }
        public IActionResult AddAchievement()
        {
            return View();
        }
        public IActionResult Add(Achievement achievement)
        {
            achievements.Add(achievement);
            return View("Index", achievements);
        }
    }
}
