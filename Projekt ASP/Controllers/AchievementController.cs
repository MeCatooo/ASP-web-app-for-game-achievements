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
        private ICRUDAchievementRepositories achievementRepository;
        private ICRUDCommentRepository commentRepository;
        private ICRUDPostRepository postRepository;
        public AchievementController(ICRUDAchievementRepositories achievementRepository, ICRUDCommentRepository commentRepository, ICRUDPostRepository postRepository)
        {
            this.achievementRepository = achievementRepository;
            this.commentRepository = commentRepository;
            this.postRepository = postRepository;
        }
        public ViewResult Index()
        {
            return View(achievementRepository.FindAll());
        }
        public IActionResult AddAchievement()
        {
            return View();
        }
        public IActionResult Add(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                achievementRepository.Add(achievement);
                return LocalRedirect("/Achievement/Index");
            }
            else
            {
                return View("AddAchievement");
            }
        }
        public IActionResult ViewPost(int id) 
        {
            var post = postRepository.FindById(id);
            post.Comments = commentRepository.FindComments(post.Id);
            post.Achievement = achievementRepository.FindById(post.AchievementId);
            return View(post);
        }
        [Authorize]
        public IActionResult EditForm(int id)
        {
            return View(achievementRepository.FindById(id));
        }
        [Authorize]
        public IActionResult Edit(Achievement edited)
        {
            achievementRepository.Update(edited);
            return View("Index", achievementRepository.FindAll());
        }
        [Authorize]
        public IActionResult DeleteForm(int id)
        {
            return View(achievementRepository.FindById(id));
        }
        [Authorize]
        public IActionResult Delete(Achievement achievement)
        {
            achievementRepository.Delete(achievement.Id);
            return View("Index", achievementRepository.FindAll());
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
                commentRepository.Add(comment);
                postRepository.AddCommentToPost(comment.Id, comment.PostId);
                return LocalRedirect("/Achievement/ViewPost/" + comment.PostId);
            }
            else
            {
                return View("AddCommentForm");
            }
        }
        public IActionResult ViewPosts(int id)
        {
            Achievement achievement = achievementRepository.FindById(id);
            achievement.Posts = postRepository.FindPosts(id);
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
                postRepository.Add(post);
                achievementRepository.AddPostToAchievement(post.Id, post.AchievementId);
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
            return View(postRepository.FindById(id));
        }
        [Authorize]
        public IActionResult EditPost(Post edited)
        {
            postRepository.Update(edited);
            return LocalRedirect("/Achievement/ViewPost/" + edited.Id);
        }
        [Authorize]
        public IActionResult DeleteFormPost(int id)
        {
            return View(postRepository.FindById(id));
        }
        [Authorize]
        public IActionResult DeletePost(Post post)
        {
            postRepository.Delete(post.Id);
            return LocalRedirect("/Achievement/ViewPosts/" + post.AchievementId);
        }
    }
}
