using LearningManagementSystem.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICollection<Employee> Employees { get; set; } // Lecturer only

        public Subject()
        {
            Employees = new Collection<Employee>();
        }

    }
}