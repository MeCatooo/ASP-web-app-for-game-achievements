using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
        public Post Post { get; set; }
    }
}
