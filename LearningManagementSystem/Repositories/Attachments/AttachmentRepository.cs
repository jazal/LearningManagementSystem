using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Attachments.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using LearningManagementSystem.Models.Enums;

namespace LearningManagementSystem.Repositories.Attachments
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AttachmentRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public AttachmentDto Create(CreateAttachmentDto input)
        {
            var attachment = _mapper.Map<CreateAttachmentDto, Attachment>(input);
            var createdAttachment = _context.Attachments.Add(attachment);
            _context.SaveChanges();
            return _mapper.Map<Attachment, AttachmentDto>(createdAttachment);
        }

        public bool Delete(int id)
        {
            var attachmentToDelete = _context.Attachments.FirstOrDefault(c => c.Id == id);
            if (attachmentToDelete != null)
            {
                _context.Attachments.Remove(attachmentToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public AttachmentDto Edit(int id, AttachmentDto updatedValue)
        {
            var existingAttachment = _context.Attachments.FirstOrDefault(c => c.Id == id);
            if (existingAttachment != null)
            {
                existingAttachment.Title = updatedValue.Title;
                existingAttachment.AttachmentType = updatedValue.AttachmentType;
                existingAttachment.DueDate = updatedValue.DueDate;
                existingAttachment.SubjectId = updatedValue.SubjectId;
                existingAttachment.EmployeeId = updatedValue.EmployeeId;
                existingAttachment.Status = updatedValue.Status;
                existingAttachment.AttachmentFileName = updatedValue.AttachmentFileName;

                _context.SaveChanges();

                return _mapper.Map<Attachment, AttachmentDto>(existingAttachment);
            }
            return null;
        }

        public List<AttachmentDto> GetAll()
        {
            var attachments = _context.Attachments.ToList();
            return _mapper.Map<List<Attachment>, List<AttachmentDto>>(attachments);
        }

        public List<AttachmentDto> GetAllByEmployeeId(int employeeId)
        {
            var attachments = _context.Attachments.Include(a => a.Subject).Where(a => a.EmployeeId == employeeId).ToList();
            return _mapper.Map<List<Attachment>, List<AttachmentDto>>(attachments);
        }

        public AttachmentDto GetById(int id)
        {
            var attachment = _context.Attachments.Include(a => a.Employee).FirstOrDefault(a => a.Id == id);
            return _mapper.Map<Attachment, AttachmentDto>(attachment);
        }

        public List<AttachmentDto> GetBySubjectId(int id)
        {
            var attachments = _context.Attachments.Include(a => a.Employee)
                .Where(a => a.SubjectId == id && a.Status != AttachmentStatus.Deleted)
                .ToList();
            return _mapper.Map<List<Attachment>, List<AttachmentDto>>(attachments);
        }
    }
}