using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Project : Entity
    {
        public virtual User ProjectManager { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string Customer { get; set; }
        public string Performer { get; set; }
        public virtual ICollection<User> Workers { get; set; }
    }
}
