using LearningManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class Student
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
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime EnrolledDate { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; }

        public Student()
        {
            AssignmentSubmissions = new Collection<AssignmentSubmission>();
        }

    }
}