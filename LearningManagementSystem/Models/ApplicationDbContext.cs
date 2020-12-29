using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LearningManagementSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }
        
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<Attachment> Attachments { get; set; }
        
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }

        public ApplicationDbContext()
            : base("Default", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AssignmentSubmission>()
            //    .HasRequired(s => s.Student)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            
        }
    }
}