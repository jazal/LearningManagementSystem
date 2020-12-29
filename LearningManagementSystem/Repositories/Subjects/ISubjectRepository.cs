using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Subjects.Dtos;
using System.Collections.Generic;

namespace LearningManagementSystem.Repositories.Subjects
{
    public interface ISubjectRepository
    {
        Subject Create(Subject subject);

        List<Subject> GetAll();

        SubjectDto GetById(int id);

        bool Delete(int id);

        Subject Edit(int id, Subject subject);

        List<SubjectDto> GetSubjectsByCourseId(int courseId);
    }
}