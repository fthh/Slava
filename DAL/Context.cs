using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;

namespace DAL
{
    public class Context : DbContext
    {

        public Context() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany<User>(s => s.Workers)
                .WithMany(c => c.Projects)
                .Map(cs =>
                {
                    cs.MapLeftKey("ProjectRefId");
                    cs.MapRightKey("UserRefId");
                    cs.ToTable("ProjectUser");
                });
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
