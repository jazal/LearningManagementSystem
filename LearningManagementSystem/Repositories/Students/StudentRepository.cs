using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;

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

            student.ApplicationUser = new ApplicationUser
            {
                UserName = input.Email,
                Email = input.Email,
                PasswordHash = Crypto.HashPassword(input.Password),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                LockoutEnabled = true,
                IsStudent = true
            };

            var createdStudent = _context.Students.Add(student);
            _context.SaveChanges();

            return _mapper.Map<Student, StudentDto>(createdStudent);
        }

        public bool Delete(int id)
        {
            var studentToDelete = _context.Students.Include(s => s.ApplicationUser).FirstOrDefault(c => c.Id == id);
            if (studentToDelete != null)
            {
                _context.Users.Remove(studentToDelete.ApplicationUser);
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public StudentDto Edit(int id, StudentDto updatedValues)
        {
            var existingStudent = _context.Students.Include(s => s.ApplicationUser).FirstOrDefault(c => c.Id == id);
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

                var existingUser = existingStudent.ApplicationUser;
                existingUser.UserName = updatedValues.Email;
                existingUser.Email = updatedValues.Email;
                existingUser.PasswordHash = Crypto.HashPassword(updatedValues.Password);
                existingUser.SecurityStamp = Guid.NewGuid().ToString("D");
                existingUser.LockoutEnabled = true;
                existingUser.IsStudent = true;

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