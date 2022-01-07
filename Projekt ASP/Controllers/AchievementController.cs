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
        private ICRUDEAchievementRepository repository;
        //private ICRUDCommentRepository commentRepository;
        //private ICRUDPostRepository postRepository;
        public AchievementController(ICRUDEAchievementRepository achievementRepository)
        {
            this.repository = achievementRepository;
            //this.commentRepository = commentRepository;
            //this.postRepository = postRepository;
        }
        public ViewResult Index()
        {
            return View(repository.FindAll());
        }
        public IActionResult AddAchievement()
        {
            return View();
        }
        public IActionResult Add(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                repository.Add(achievement);
                return LocalRedirect("/Achievement/Index");
            }
            else
            {
                return View("AddAchievement");
            }
        }
        public IActionResult ViewPost(int id) 
        {
            var post = repository.FindPostById(id);
            post.Comments = repository.FindComments(post.Id);
            post.Achievement = repository.FindAchievementById(post.AchievementId);
            return View(post);
        }
        [Authorize]
        public IActionResult EditForm(int id)
        {
            return View(repository.FindAchievementById(id));
        }
        [Authorize]
        public IActionResult Edit(Achievement edited)
        {
            repository.Update(edited);
            return View("Index", repository.FindAll());
        }
        [Authorize]
        public IActionResult DeleteForm(int id)
        {
            return View(repository.FindAchievementById(id));
        }
        [Authorize]
        public IActionResult Delete(Achievement achievement)
        {
            repository.Delete(achievement.Id);
            return View("Index", repository.FindAll());
        }
        public IActionResult AddCommentForm(int id)
        {
            ViewBag.PostId = id;
            return View();
        }
        public IActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.PostTime = DateTime.Now;
                repository.Add(comment);
                repository.AddCommentToPost(comment.Id, comment.PostId);
                return LocalRedirect("/Achievement/ViewPost/" + comment.PostId);
            }
            else
            {
                return View("AddCommentForm");
            }
        }
        public IActionResult ViewPosts(int id)
        {
            Achievement achievement = repository.FindAchievementById(id);
            achievement.Posts = repository.FindPosts(id);
            return View(achievement);
        }
        public IActionResult AddPostForm(int id)
        {
            ViewBag.AchievemntId = id;
            return View();
        }
        public IActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostTime = DateTime.Now;
                repository.Add(post);
                repository.AddPostToAchievement(post.Id, post.AchievementId);
                return LocalRedirect("/Achievement/ViewPosts/" + post.AchievementId);
            }
            else
            {
                ViewBag.AchievemntId = post.AchievementId;
                return View("AddPostForm");
            }
        }
        [Authorize]
        public IActionResult EditFormPost(int id)
        {
            return View(repository.FindPostById(id));
        }
        [Authorize]
        public IActionResult EditPost(Post edited)
        {
            repository.Update(edited);
            return LocalRedirect("/Achievement/ViewPost/" + edited.Id);
        }
        [Authorize]
        public IActionResult DeleteFormPost(int id)
        {
            return View(repository.FindPostById(id));
        }
        [Authorize]
        public IActionResult DeletePost(Post post)
        {
            repository.Delete(post.Id);
            return LocalRedirect("/Achievement/ViewPosts/" + post.AchievementId);
        }
    }
}
