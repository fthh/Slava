using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Entities
{
    public class Project : Entity
    {
        public User[] Workers { get; set; }
        public User ProjectManager { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string Customer { get; set; }
        public string Performer { get; set; }
    }
}
