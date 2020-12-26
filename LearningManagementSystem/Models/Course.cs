using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}