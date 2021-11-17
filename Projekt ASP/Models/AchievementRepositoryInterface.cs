using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public interface AchievementRepositoryInterface
    {
        IQueryable<Achievement> Achievements { get; }
    }
}
