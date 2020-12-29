using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.ApplicationUsers.Dtos;
using LearningManagementSystem.Repositories.AssignmentSubmissions.Dtos;
using LearningManagementSystem.Repositories.Attachments.Dtos;
using LearningManagementSystem.Repositories.Courses;
using LearningManagementSystem.Repositories.Employees.Dtos;
using LearningManagementSystem.Repositories.Students.Dtos;
using LearningManagementSystem.Repositories.Subjects.Dtos;

namespace LearningManagementSystem.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Course
            CreateMap<Course, CourseDto>();
            
            CreateMap<CourseDto, Course>();

            // Subject
            CreateMap<Subject, SubjectDto>()
                .ForMember(sd => sd.CourseTitle, config => config.MapFrom(s => s.Course.Title));

            CreateMap<SubjectDto, Subject>();

            // Student
            CreateMap<CreateStudentDto, Student>();
            
            CreateMap<Student, StudentDto>();

            // Employee
            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeDto, Employee>();

            // Attachment
            CreateMap<CreateAttachmentDto, Attachment>();
            
            CreateMap<Attachment, AttachmentDto>();
            
            CreateMap<AttachmentDto, Attachment>();

            // Application Users
            CreateMap<ApplicationUser, UserDto>();
            
            CreateMap<UserDto, ApplicationUser>();

            // Attachment Submission
            CreateMap<CreateAssignmentSubmissionDto, AssignmentSubmission> ();

            CreateMap<AssignmentSubmission, AssignmentSubmissionDto>();

            CreateMap<AssignmentSubmissionDto, AssignmentSubmission>();
        }
    }
}