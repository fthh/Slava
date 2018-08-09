using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Post : DAL.Entities.Entity
    {
        public User Author { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }
    }
}
