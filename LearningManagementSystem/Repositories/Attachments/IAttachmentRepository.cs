using LearningManagementSystem.Repositories.Attachments.Dtos;
using System.Collections.Generic;

namespace LearningManagementSystem.Repositories.Attachments
{
    public interface IAttachmentRepository
    {
        AttachmentDto Create(CreateAttachmentDto input);

        List<AttachmentDto> GetAll();

        AttachmentDto GetById(int id);

        bool Delete(int id);

        AttachmentDto Edit(int id, AttachmentDto updateInputs);

        List<AttachmentDto> GetAllByEmployeeId(int employeeId); // Course Coordinator
    }
}