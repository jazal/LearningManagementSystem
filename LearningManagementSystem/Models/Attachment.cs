using LearningManagementSystem.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class Attachment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public AttachmentType AttachmentType { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public int EmployeeId { get; set; } // Course Coordinator

        public Employee Employee { get; set; }

        [Required]
        public AttachmentStatus Status { get; set; }

        public string AttachmentFileName { get; set; }

    }
}