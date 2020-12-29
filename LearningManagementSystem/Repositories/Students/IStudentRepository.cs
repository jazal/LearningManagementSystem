using LearningManagementSystem.Repositories.Students.Dtos;
using System.Collections.Generic;

namespace LearningManagementSystem.Repositories.Students
{
    public interface IStudentRepository
    {
        StudentDto Create(CreateStudentDto input);

        List<StudentDto> GetAll();

        StudentDto GetById(int id);

        bool Delete(int id);

        StudentDto Edit(int id, StudentDto subject);

        StudentDto GetStudentByCurrentUserId(string currentUserId);
    }
}