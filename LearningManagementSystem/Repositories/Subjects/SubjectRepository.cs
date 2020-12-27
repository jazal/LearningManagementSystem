using LearningManagementSystem.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LearningManagementSystem.Repositories.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Subject Create(Subject subject)
        {
            var createdSubject = _context.Subjects.Add(subject);
            _context.SaveChanges();
            return createdSubject;
        }

        public bool Delete(int id)
        {
            var subjectToDelete = _context.Subjects.FirstOrDefault(c => c.Id == id);
            if (subjectToDelete != null)
            {
                _context.Subjects.Remove(subjectToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Subject Edit(int id, Subject subject)
        {
            var existingSubject = _context.Subjects.FirstOrDefault(c => c.Id == id);
            if (existingSubject != null)
            {
                existingSubject.Title = subject.Title;
                existingSubject.Semester = subject.Semester;
                existingSubject.CourseId = subject.CourseId;
                _context.SaveChanges();
                return existingSubject;
            }
            return null;
        }

        public List<Subject> GetAll()
        {
            return _context.Subjects.Include(s => s.Course).ToList();
        }

        public Subject GetById(int id)
        {
            return _context.Subjects.Include(s => s.Course).FirstOrDefault(c => c.Id == id);
        }
    }
}