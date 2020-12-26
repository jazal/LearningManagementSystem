using LearningManagementSystem.Models;
using System.Collections.Generic;

namespace LearningManagementSystem.Repositories.Courses
{
    public interface ICourseRepository
    {
        Course Create(Course course);

        List<Course> GetAll();

        Course GetById(int id);

        bool Delete(int id);

        Course Edit(int id, Course course);
    }
}