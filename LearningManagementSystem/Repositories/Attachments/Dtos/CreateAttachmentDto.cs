﻿using LearningManagementSystem.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.Attachments.Dtos
{
    public class CreateAttachmentDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public AttachmentType AttachmentType { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int EmployeeId { get; set; } // Course Coordinator

        [Required]
        public AttachmentStatus Status { get; set; }

        public string AttachmentFileName { get; set; }
    }
}