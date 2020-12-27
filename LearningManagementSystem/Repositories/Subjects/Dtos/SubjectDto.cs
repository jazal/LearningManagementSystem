using LearningManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.Subjects.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public int CourseId { get; set; }

        public string CourseTitle { get; set; }
    }
}