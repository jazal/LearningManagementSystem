using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICollection<Subject> Subjects { get; set; }

        public Course()
        {
            Subjects = new Collection<Subject>();
        }
    }
}