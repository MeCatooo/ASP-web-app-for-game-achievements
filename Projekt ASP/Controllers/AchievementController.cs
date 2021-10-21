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
        static readonly List<Achievement> achievements = new();
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
        public IActionResult View(Achievement achievement)
        {
            return View("Index");
        }
    }
}
