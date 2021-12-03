using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Projekt_ASP.Models
{
    public interface ICRUDAchievementRepository
    {
        Achievement Add(Achievement achievement);

        void Delete(int id);

        Achievement Update(Achievement achievement);

        Achievement FindById(int id);

        IList<Achievement> FindAll();

        IList<Achievement> FindPage(int page, int size);
    }

    public class EFCRUDEAchievementRepository : ICRUDAchievementRepository
    {
        private ApplicationDbContext _context;

        public EFCRUDEAchievementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Achievement Add(Achievement achievement)
        {
            EntityEntry<Achievement> entityEntry = _context.Achievements.Add(achievement);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            _context.Achievements.Remove(_context.Achievements.Find(id));
            _context.SaveChanges();
        }

        public IList<Achievement> FindAll()
        {
            return _context.Achievements.ToList();
        }

        public Achievement FindById(int id)
        {
            return _context.Achievements.Find(id);
        }

        public IList<Achievement> FindPage(int page, int size)
        {
            return (from achievement in _context.Achievements orderby achievement.Name select achievement).Skip(page*size).Take(size).ToList();
        }

        public Achievement Update(Achievement achievement)
        {
            EntityEntry<Achievement> entity = _context.Achievements.Update(achievement);
            _context.SaveChanges();
            return entity.Entity;

        }
    }

}
