using LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos;

namespace LearningManagementSystem.Repositories.AssignmentSubmissions
{
    public interface IAssignmentSubmissionRepository
    {
        AssignmentSubmissionDto Create(CreateAssignmentSubmissionDto input);
    }
}