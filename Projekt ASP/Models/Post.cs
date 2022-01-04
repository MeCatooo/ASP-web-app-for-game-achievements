using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Achievement Achievement { get; set; }
        public int AchievementId { get; set; }
        public IList<Comment> Comments { get; set; }
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; } = 0;
        public DateTime PostTime { get; set; }
    }
}
