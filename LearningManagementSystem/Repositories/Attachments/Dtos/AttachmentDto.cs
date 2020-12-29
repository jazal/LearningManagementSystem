using LearningManagementSystem.Models.Enums;
using LearningManagementSystem.Repositories.Employees.Dtos;
using LearningManagementSystem.Repositories.Subjects.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.Attachments.Dtos
{
    public class AttachmentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public AttachmentType AttachmentType { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public SubjectDto Subject { get; set; }

        [Required]
        public int EmployeeId { get; set; } // Course Coordinator

        public EmployeeDto Employee { get; set; }

        [Required]
        public AttachmentStatus Status { get; set; }

        public string AttachmentFileName { get; set; }
    }
}