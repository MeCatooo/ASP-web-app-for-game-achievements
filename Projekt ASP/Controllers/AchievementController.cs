using Microsoft.AspNetCore.Authorization;
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
        private ICRUDAchievementRepository repository;
        static List<Achievement> achievements = new();
        public AchievementController (ICRUDAchievementRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index()
        {
            return View(repository.FindAll());
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

            repository.Add(achievement);
            return View("Index", repository.FindAll());
        }
        public IActionResult View(int id)
        {
            var achievement = repository.FindById(id);
            achievement.Comments = repository.FindComments(achievement.Id);
            return View(achievement);
        }
        [Authorize]
        public IActionResult EditForm(int id)
        {
            return View(repository.FindById(id));
        }
        [Authorize]
        public IActionResult Edit(Achievement edited)
        {
            repository.Update(edited);
            return View("Index",repository.FindAll());
        }
        [Authorize]
        public IActionResult DeleteForm(int id)
        {
            return View(repository.FindById(id));
        }
        [Authorize]
        public IActionResult Delete(Achievement achievement)
        {
            repository.Delete(achievement.Id);
            return View("Index", repository.FindAll());
        }
        public IActionResult AddCommentForm(int id)
        {
            ViewBag.AchievemntId = id;
            return View();
        }
        public IActionResult AddComment(Comment comment)
        {
            repository.Add(comment);
            repository.AddCommentToAchievement(comment.CommentID, comment.AchievementId);
            var achievement = repository.FindById(comment.AchievementId);
            achievement.Comments = repository.FindComments(comment.AchievementId);
            return View("View", achievement);
        }

    }
}
