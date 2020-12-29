using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos
{
    public class AssignmentSubmissionDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int AttachmentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public float? Grade { get; set; }
    }
}