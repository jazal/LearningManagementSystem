using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Courses;
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


                
        }
    }
}