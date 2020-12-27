using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Students.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace LearningManagementSystem.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public StudentDto Create(CreateStudentDto input)
        {
            var student = _mapper.Map<CreateStudentDto, Student>(input);

            var createdStudent = _context.Students.Add(student);
            _context.SaveChanges();

            return _mapper.Map<Student, StudentDto>(createdStudent);
        }

        public bool Delete(int id)
        {
            var studentToDelete = _context.Students.FirstOrDefault(c => c.Id == id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public StudentDto Edit(int id, StudentDto updatedValues)
        {
            var existingStudent = _context.Students.FirstOrDefault(c => c.Id == id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = updatedValues.FirstName;
                existingStudent.LastName = updatedValues.LastName;
                existingStudent.DateOfBirth = updatedValues.DateOfBirth;
                existingStudent.ContactNo = updatedValues.ContactNo;
                existingStudent.Address = updatedValues.Address;
                existingStudent.Gender = updatedValues.Gender;
                existingStudent.Email = updatedValues.Email;
                existingStudent.Password = updatedValues.Password;
                existingStudent.CourseId = updatedValues.CourseId;
                existingStudent.EnrolledDate = existingStudent.EnrolledDate;
                _context.SaveChanges();

                return _mapper.Map<Student, StudentDto>(existingStudent);
            }
            return null;
        }

        public List<StudentDto> GetAll()
        {
            var students = _context.Students.ToList();
            return _mapper.Map<List<Student>, List<StudentDto>>(students);
        }

        public StudentDto GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(ss => ss.Id == id);
            return _mapper.Map<Student, StudentDto>(student);
        }
    }
}