using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Models.Enums;
using LearningManagementSystem.Repositories.Employees.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;

namespace LearningManagementSystem.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public EmployeeDto Create(CreateEmployeeDto input)
        {
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(input);
            
            // Only Course Coordinator has the permission to have 1 CourseId
            if(employee.Designation == Designation.CourseCoordinator)
            {
                employee.CourseId = employee.CourseId;
            }
            else
            {
                employee.CourseId = null;
            }

            employee.ApplicationUser = new ApplicationUser
            {
                UserName = input.Email,
                Email = input.Email,
                PasswordHash = Crypto.HashPassword(input.Password),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                LockoutEnabled = true,
                IsStudent = false,
                Designation = input.Designation
            };

            var createdEmployee = _context.Employees.Add(employee);
            _context.SaveChanges();

            return _mapper.Map<Employee, EmployeeDto>(createdEmployee);
        }

        public bool Delete(int id)
        {
            var employeeToDelete = _context.Employees.Include(e => e.ApplicationUser).FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                _context.Users.Remove(employeeToDelete.ApplicationUser);
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public EmployeeDto Edit(int id, EmployeeDto updatedValues)
        {
            var existingEmployee = _context.Employees.Include(s => s.ApplicationUser).FirstOrDefault(c => c.Id == id);
            if (existingEmployee != null)
            {
                // Only Course Coordinator has the permission to have 1 CourseId
                if (updatedValues.Designation == Designation.CourseCoordinator)
                {
                    updatedValues.CourseId = updatedValues.CourseId;
                }
                else
                {
                    updatedValues.CourseId = null;
                }

                existingEmployee.FirstName = updatedValues.FirstName;
                existingEmployee.LastName = updatedValues.LastName;
                existingEmployee.DateOfBirth = updatedValues.DateOfBirth;
                existingEmployee.ContactNo = updatedValues.ContactNo;
                existingEmployee.Gender = updatedValues.Gender;
                existingEmployee.Designation = updatedValues.Designation;
                existingEmployee.Email = updatedValues.Email;
                existingEmployee.Password = updatedValues.Password;
                existingEmployee.CourseId = updatedValues.CourseId;

                var existingUser = existingEmployee.ApplicationUser;
                existingUser.UserName = updatedValues.Email;
                existingUser.Email = updatedValues.Email;
                existingUser.PasswordHash = Crypto.HashPassword(updatedValues.Password);
                existingUser.SecurityStamp = Guid.NewGuid().ToString("D");
                existingUser.LockoutEnabled = true;
                existingUser.IsStudent = false;
                existingUser.Designation = updatedValues.Designation;

                _context.SaveChanges();
                return _mapper.Map<Employee, EmployeeDto>(existingEmployee);
            }
            return null;
        }

        public List<EmployeeDto> GetAll()
        {
            var employees = _context.Employees.ToList();
            return _mapper.Map<List<Employee>, List<EmployeeDto>>(employees);
        }

        public EmployeeDto GetById(int id)
        {
            var student = _context.Employees.Include(e => e.Course).FirstOrDefault(e => e.Id == id);
            return _mapper.Map<Employee, EmployeeDto>(student);
        }
    }
}