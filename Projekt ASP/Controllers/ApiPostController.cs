using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_ASP.Models;

namespace Projekt_ASP.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class ApiPostController : ControllerBase
    {
        private ICRUDAchievementRepository repository;
        public ApiPostController(ICRUDAchievementRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetPost(int id)
        {
            var post = repository.FindPostById(id);
            if (post != null)
            {
                return new OkObjectResult(post);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                Post Post = repository.Add(post);
                return new CreatedResult($"/api/post/{Post.Id}", post);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("{id?}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.DeletePost(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                if (repository.FindAchievementById(post.Id) != null)
                {
                    repository.Update(post);
                    return new CreatedResult($"/api/achievement/{post.Id}", post);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
