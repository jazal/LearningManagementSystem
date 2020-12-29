using LearningManagementSystem.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(15)]
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

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int? SubjectId { get; set; }

        public Subject Subject { get; set; }

    }
}