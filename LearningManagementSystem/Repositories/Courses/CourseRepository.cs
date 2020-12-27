using LearningManagementSystem.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LearningManagementSystem.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Course Create(Course course)
        {
            var createdCourse = _context.Courses.Add(course);
            _context.SaveChanges();
            return createdCourse;
        }

        public bool Delete(int id)
        {
            var courseToDelete = _context.Courses.FirstOrDefault(c => c.Id == id);
            if(courseToDelete != null)
            {
                _context.Courses.Remove(courseToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Course Edit(int id, Course course)
        {
            var existingCourse = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (existingCourse != null)
            {
                existingCourse.Title = course.Title;
                _context.SaveChanges();
                return existingCourse;
            }
            return null;
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Include(c => c.Subjects).FirstOrDefault(c => c.Id == id);
        }
    }
}