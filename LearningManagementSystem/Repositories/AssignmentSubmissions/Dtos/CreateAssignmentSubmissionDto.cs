using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos
{
    public class CreateAssignmentSubmissionDto
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int AttachmentId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public float? Grade { get; set; }
    }
}