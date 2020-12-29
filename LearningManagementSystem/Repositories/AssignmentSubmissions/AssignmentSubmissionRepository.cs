using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace LearningManagementSystem.Repositories.AssignmentSubmissions
{
    public class AssignmentSubmissionRepository : IAssignmentSubmissionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AssignmentSubmissionRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public AssignmentSubmissionDto Create(CreateAssignmentSubmissionDto input)
        {
            var assignmentSubmission = _mapper.Map<CreateAssignmentSubmissionDto, AssignmentSubmission>(input);
            var created = _context.AssignmentSubmissions.Add(assignmentSubmission);
            _context.SaveChanges();
            return _mapper.Map<AssignmentSubmission, AssignmentSubmissionDto>(created);
        }

        public List<AssignmentSubmissionDto> GetAllBySubjectId(int subjectId)
        {
            var assignmentSubmissions = _context.AssignmentSubmissions.Include(s => s.Student).Where(a => a.SubjectId == subjectId).ToList();
            return _mapper.Map<List<AssignmentSubmission>, List<AssignmentSubmissionDto>>(assignmentSubmissions);
        }

        public bool UpdateGrade(int assignmentSubmissionId, float grade, int employeeId)
        {
            var existingAssignment = _context.AssignmentSubmissions.FirstOrDefault(a => a.Id == assignmentSubmissionId);
            if (existingAssignment != null)
            {
                existingAssignment.Grade = grade;
                existingAssignment.EmployeeId = employeeId;
                
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        

    }
}