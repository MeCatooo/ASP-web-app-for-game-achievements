using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAchievementController : ControllerBase
    {
        private ICRUDEAchievementRepository repository;

        public ApiAchievementController(ICRUDEAchievementRepository repository)
        {
            this.repository = repository;
        }


    }
}
