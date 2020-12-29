using LearningManagementSystem.Repositories.Attachments.Dtos;
using LearningManagementSystem.Repositories.Students.Dtos;
using LearningManagementSystem.Repositories.Subjects.Dtos;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LearningManagementSystem.ViewModels
{
    public class ViewAttachmentsForStudentVM
    {
        public StudentDto Student { get; set; }

        public SubjectDto Subject { get; set; }

        public ICollection<AttachmentDto> Attachments { get; set; }

        public ViewAttachmentsForStudentVM()
        {
            Attachments = new Collection<AttachmentDto>();
        }
    }
}