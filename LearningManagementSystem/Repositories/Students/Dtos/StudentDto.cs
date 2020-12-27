using LearningManagementSystem.Models.Enums;
using LearningManagementSystem.Repositories.Courses;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.Students.Dtos
{
    public class StudentDto
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
        public string Address { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int CourseId { get; set; }

        public DateTime EnrolledDate { get; set; }
    }
}