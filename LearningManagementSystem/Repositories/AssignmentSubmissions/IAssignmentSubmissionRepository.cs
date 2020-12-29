using LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos;
using System.Collections.Generic;

namespace LearningManagementSystem.Repositories.AssignmentSubmissions
{
    public interface IAssignmentSubmissionRepository
    {
        AssignmentSubmissionDto Create(CreateAssignmentSubmissionDto input);

        bool UpdateGrade(int assignmentSubmissionId, float grade, int employeeId);

        List<AssignmentSubmissionDto> GetAllBySubjectId(int subjectId);
    }
}