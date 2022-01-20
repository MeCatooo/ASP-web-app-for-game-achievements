using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    [Route("api/achievement")]
    [ApiController]
    public class ApiAchievementController : ControllerBase
    {
        private ICRUDAchievementRepository repository;

        public ApiAchievementController(ICRUDAchievementRepository repository)
        {
            this.repository = repository;
        }
        [HttpDelete]
        [Route("{id?}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteAchievement(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public List<Achievement> GetAll()
        {
            return repository.FindAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult Get(int id)
        {
            var achievement = repository.FindAchievementById(id);
            if (achievement != null)
            {
                return new OkObjectResult(achievement);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                Achievement achievement1 = repository.Add(achievement);
                return new CreatedResult($"/api/achievement/{achievement1.Id}", achievement);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
