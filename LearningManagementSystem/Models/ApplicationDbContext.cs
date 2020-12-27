using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LearningManagementSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }
        
        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext()
            : base("Default", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}