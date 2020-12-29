using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos;

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

    }
}