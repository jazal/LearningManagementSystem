using LearningManagementSystem.Models;
using LearningManagementSystem.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.Employees.Dtos
{
    public class EmployeeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Designation Designation { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int? CourseId { get; set; } // Only applicable for Designation = CourseCoordinator

        public Course Course { get; set; }

        public int? SubjectId { get; set; } // Only applicable for Designation = Lecturer
    }
}