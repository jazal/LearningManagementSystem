using LearningManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}