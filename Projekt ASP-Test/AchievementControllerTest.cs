using System;
using Xunit;
using Projekt_ASP.Controllers;
using System.Collections.Generic;
using Projekt_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Projekt_ASP_Test
{
    public class AchievementControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            ActionResult actionResult = controller.Index();
            Assert.IsType<ViewResult>(actionResult);
        }
        [Fact]
        public void AddAchievementTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            IActionResult actionResult = controller.AddAchievement();
            Assert.IsType<ViewResult>(actionResult);
        }
        [Fact]
        public void AddTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var achievement = new Achievement()
            {
                Game = "Skyrim",
                Name = "Dragon",
            };
            var createdResponse = controller.Add(achievement);
            Assert.IsType<LocalRedirectResult>(createdResponse);
            achievement.Id = 2;
            var achievementFromRep = repository.FindAchievementById(2);
            Assert.Equal(achievementFromRep, achievement);
        }
        //[Fact]                                        //ModelState.IsValid niepoprawnie dzia³a na samym kontrolerze
        //public void AddNullTest()
        //{
        //    ICRUDAchievementRepository repository = new MemoryAchievementRepository();
        //    AchievementController controller = new AchievementController(repository);
        //    var achievement = new Achievement();
        //    var createdResponse = controller.Add(achievement);
        //    Assert.IsType<ViewResult>(createdResponse);
        //}
        [Fact]
        public void ViewPostTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var createdResponse = controller.ViewPost(1) as ViewResult;
            var post = createdResponse.Model as Post;
            Assert.IsType<ViewResult>(createdResponse);
            Assert.IsType<Post>(post);
            Assert.Equal(1, post.Id);
            Assert.Equal(1, post.AchievementId);
            Assert.Equal("First time to the game", post.Title);
            Assert.Equal("It's very hard", post.Text);
            Assert.NotNull(post.Comments);
        }
        [Fact]
        public void EditFormTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var createdResponse = controller.EditForm(1) as ViewResult;
            var achievemt = createdResponse.Model as Achievement;
            Assert.IsType<ViewResult>(createdResponse);
            Assert.IsType<Achievement>(achievemt);
            Assert.NotNull(achievemt);
        }
        [Fact]
        public void EditTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var achievement = repository.FindAchievementById(1);
            achievement.Name = "Test";
            controller.Edit(achievement);
            var edited = repository.FindAchievementById(1);
            Assert.Equal(achievement, edited);
        }
        [Fact]
        public void DeleteFormTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var createdResponse = controller.DeleteForm(1) as ViewResult;
            var achievemt = createdResponse.Model as Achievement;
            Assert.IsType<ViewResult>(createdResponse);
            Assert.IsType<Achievement>(achievemt);
            Assert.NotNull(achievemt);
        }
        [Fact]
        public void DeleteTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var achievement = repository.FindAchievementById(1);
            controller.Delete(achievement);
            var deleted = repository.FindAchievementById(1);
            Assert.Null(deleted);
        }
        [Fact]
        public void AddCommentFormTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            IActionResult actionResult = controller.AddCommentForm(1);
            Assert.IsType<ViewResult>(actionResult);
        }
        [Fact]
        public void AddCommentTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var comment = new Comment()
            {
                PostId = 1,
                Text = "Test"
            };
            var createdResponse = controller.AddComment(comment);
            comment.Id = 2;
            Assert.IsType<LocalRedirectResult>(createdResponse);
            List<Comment> commentsFromRep = repository.FindComments(1);
            Assert.Contains<Comment>(comment, commentsFromRep);
        }
        [Fact]
        public void ViewPosts()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var createdResponse = controller.ViewPosts(1) as ViewResult;
            var posts = createdResponse.Model as Achievement;
            Assert.NotNull(posts.Posts);
            Assert.IsType<List<Post>>(posts.Posts);
        }
        [Fact]
        public void AddPostFormTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            IActionResult actionResult = controller.AddPostForm(1);
            Assert.IsType<ViewResult>(actionResult);
        }
        [Fact]
        public void AddPostTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var post = new Post()
            {
                AchievementId = 1,
                Text = "Test",
                Title = "Test"
            };
            var createdResponse = controller.AddPost(post);
            post.Id = 2;
            Assert.IsType<LocalRedirectResult>(createdResponse);
            var postFromRep = repository.FindPostById(2);
            Assert.Equal(post, postFromRep);
        }
        [Fact]
        public void EditFormPostTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var createdResponse = controller.EditFormPost(1) as ViewResult;
            var post = createdResponse.Model as Post;
            Assert.IsType<ViewResult>(createdResponse);
            Assert.IsType<Post>(post);
            Assert.NotNull(post);
        }
        [Fact]
        public void EditPostTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var post = repository.FindPostById(1);
            post.Title = "Test";
            controller.EditPost(post);
            var edited = repository.FindPostById(1);
            Assert.Equal(post, edited);
        }
        [Fact]
        public void DeleteFormPostTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var createdResponse = controller.DeleteFormPost(1) as ViewResult;
            var post = createdResponse.Model as Post;
            Assert.IsType<ViewResult>(createdResponse);
            Assert.IsType<Post>(post);
            Assert.NotNull(post);
        }
        [Fact]
        public void DeletePostTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var post = repository.FindPostById(1);
            controller.DeletePost(post);
            var deleted = repository.FindPostById(1);
            Assert.Null(deleted);
        }
        [Fact]
        public void DeleteFormCommentTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var createdResponse = controller.DeleteFormComment(1) as ViewResult;
            var comment = createdResponse.Model as Comment;
            Assert.IsType<ViewResult>(createdResponse);
            Assert.IsType<Comment>(comment);
            Assert.NotNull(comment);
        }
        [Fact]
        public void DeleteCommentTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            AchievementController controller = new AchievementController(repository);
            var comment = repository.FindCommnetById(1);
            controller.DeleteComment(comment);
            var deleted = repository.FindCommnetById(1);
            Assert.Null(deleted);
        }
    }
}
