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
            if (ModelState.IsValid)
            {
                achievementRepository.Add(achievement);
                return View("Index", achievementRepository.FindAll());
            }
            else
            {
                return View("AddAchievement");
            }
        }
        //public IActionResult View(int id) //TODO
        //{
        //    var achievement = achievementRepository.FindById(id);
        //    achievement.Comments = commentRepository.FindComments(achievement.Id);
        //    return View(achievement);
        //}
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
        //public IActionResult AddComment(Comment comment)
        //{
        //    comment.PostTime = DateTime.Now;
        //    commentRepository.Add(comment);
        //    achievementRepository.AddCommentToAchievement(comment.CommentID, comment.AchievementId);
        //    //var achievement = achievementRepository.FindById(comment.AchievementId);
        //    //achievement.Comments = commentRepository.FindComments(comment.AchievementId);
        //    return Redirect("Achievement/View/"+comment.AchievementId);
        //}
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
                achievementRepository.AddPostToAchievement(post.PostId, post.AchievementId);
                return LocalRedirect("/Achievement/ViewPosts/" + post.AchievementId);
            }
            else
            {
                ViewBag.AchievemntId = post.AchievementId;
                return View("AddPostForm");
            }
        }

    }
}
