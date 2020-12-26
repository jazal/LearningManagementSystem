using AutoMapper;
using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories.Courses;

namespace LearningManagementSystem.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseDto>();

            CreateMap<CourseDto, Course>();
        }
    }
}