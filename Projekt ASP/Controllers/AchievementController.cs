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
            return View(repository.FindById(id));
        }
        public IActionResult EditForm(int id)
        {
            return View(repository.FindById(id));
        }
        public IActionResult Edit(Achievement edited)
        {
            repository.Update(edited);
            return View("Index",repository.FindAll());
        }
        public IActionResult DeleteForm(int id)
        {
            return View(repository.FindById(id));
        }
        public IActionResult Delete(Achievement achievement)
        {
            repository.Delete(achievement.Id);
            return View("Index", repository.FindAll());
        }
        public IActionResult AddCommentForm(int achievement)
        {
            var commnet = new Comment();
            repository.AddCommentToAchievement(commnet.CommentID,achievement);
            return View(commnet);
        }
        public IActionResult AddComment(Comment comment)
        {
            repository.Update(comment);
            return View("View", comment.Achievement.Id);
        }

    }
}
