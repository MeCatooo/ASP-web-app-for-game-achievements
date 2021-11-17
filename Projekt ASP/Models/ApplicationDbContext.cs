using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Projekt_ASP.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<Achievement> Achievements { get; set; }
    }
    public class EFAchievementRepository : AchievementRepositoryInterface
    {
        private ApplicationDbContext _applicationDbContext;
        public EFAchievementRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Achievement> Achievements => _applicationDbContext.Achievements;
    }

}
