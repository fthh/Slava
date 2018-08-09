using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
        }

        public DbSet<DAL.Entities.Post> Posts { get; set; }
        public DbSet<DAL.Entities.User> Users { get; set; }
    }
}
