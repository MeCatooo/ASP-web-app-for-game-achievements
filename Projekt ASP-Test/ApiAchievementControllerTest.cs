using System;
using Xunit;
using Projekt_ASP.Controllers;
using System.Collections.Generic;
using Projekt_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Projekt_ASP_Test
{
    public class ApiAchievementControllerTest
    {
        [Fact]
        public void DeleteTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiAchievementController controller = new(repository);
            var achievement = repository.FindAchievementById(1);
            var result = controller.Delete(1) as OkResult;
            Assert.NotNull(achievement);
            Assert.IsType<OkResult>(result);
            Assert.Null(repository.FindAchievementById(1));
        }
        [Fact]
        public void WrongDeleteTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiAchievementController controller = new(repository);
            var result = controller.Delete(1) as OkResult;
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void GetTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiAchievementController controller = new(repository);
            var achievement = repository.FindAchievementById(1);
            var result = controller.Get(1) as OkObjectResult;
            Assert.NotNull(achievement);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetAllTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiAchievementController controller = new(repository);
            var achievement = repository.FindAchievementById(1);
            var result = controller.GetAll();
            Assert.NotNull(achievement);
            Assert.IsType<List<Achievement>>(result);
        }
        [Fact]
        public void AddTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiAchievementController controller = new(repository);
            var achievement = new Achievement()
            {
                Game = "Skyrim",
                Name = "Dragon",
            };
            var result = controller.Add(achievement) as CreatedResult;
            achievement.Id = 2;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal<Achievement>(achievement, repository.FindAchievementById(2));
        }
        [Fact]
        public void UpdateTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
            ApiAchievementController controller = new(repository);
            var achievement = new Achievement()
            {
                Id = 1,
                Game = "Skyrim",
                Name = "Dragon",
            };
            var result = controller.Update(achievement) as CreatedResult;
            Assert.IsType<CreatedResult>(result);
            Assert.Equal<Achievement>(achievement, repository.FindAchievementById(1));
        }
    }
}
