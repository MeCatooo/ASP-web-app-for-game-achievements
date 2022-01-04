using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
        public Post Post { get; set; }
    }
}
