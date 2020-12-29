using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class AssignmentSubmission
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required]
        public int AttachmentId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public float? Grade { get; set; }
    }
}