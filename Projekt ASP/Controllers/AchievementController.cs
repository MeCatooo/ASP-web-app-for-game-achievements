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
        private AchievementRepositoryInterface repository;
        static List<Achievement> achievements = new();
        public AchievementController (AchievementRepositoryInterface repository)
        {
            this.repository = repository;
        }
        public ViewResult Index()
        {
            return View(repository.Achievements);
        }
        //public IActionResult Index()
        //{
        //    return View(achievements);
        //}
        public IActionResult AddAchievement()
        {
            return View();
        }
        public IActionResult Add(Achievement achievement)
        {
            
            achievements.Add(achievement);
            return View("Index", repository.Achievements);
        }
        public IActionResult View(Achievement achievement)
        {
            return View("Index");
        }
    }
}
