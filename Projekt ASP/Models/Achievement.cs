using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Achievement
    {

        public string Name { get; set; }
        public string Game { get; set; }
        public int Achieved_By_Amount { get; protected set; } = 10; //To do
        public int Id { get; set; }
        public IList<Comment> Comments { get; set; }
        
    }
}

