using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Achievement
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Game { get; set; }
        public int Id { get; set; }
        public IList<Post> Posts { get; set; }
    }
}

