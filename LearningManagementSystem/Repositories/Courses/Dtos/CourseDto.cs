using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}