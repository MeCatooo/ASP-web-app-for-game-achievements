using System;
using Xunit;
using Projekt_ASP.Controllers;
using System.Collections.Generic;
using Projekt_ASP.Models;
using Microsoft.AspNetCore.Mvc;


namespace Projekt_ASP_Test
{
    public class ApiPostControllerTest
    {
        [Fact]
        public void DeleteTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiPostController controller = new(repository);
            var Post = repository.FindPostById(1);
            var result = controller.Delete(1) as OkResult;
            Assert.NotNull(Post);
            Assert.IsType<OkResult>(result);
            Assert.Null(repository.FindPostById(1));
        }
        [Fact]
        public void WrongDeleteTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiPostController controller = new(repository);
            var result = controller.Delete(1) as OkResult;
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void GetTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiPostController controller = new(repository);
            var Post = repository.FindPostById(1);
            var result = controller.GetPost(1) as OkObjectResult;
            Assert.NotNull(Post);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void AddTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiPostController controller = new(repository);
            var Post = new Post()
            {
                Title = "Test",
                Text = "Test",
                AchievementId = 1
            };
            var result = controller.Add(Post) as CreatedResult;
            Post.Id = 2;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal<Post>(Post, repository.FindPostById(2));
        }
        [Fact]
        public void UpdateTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiPostController controller = new(repository);
            var Post = new Post()
            {
                Id = 1,
                Title = "Test",
                Text = "Test",
                AchievementId = 1
            };
            var result = controller.Update(Post) as CreatedResult;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal<Post>(Post, repository.FindPostById(1));
        }
    }
}
