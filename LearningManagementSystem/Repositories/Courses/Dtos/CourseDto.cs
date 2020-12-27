using LearningManagementSystem.Repositories.Subjects.Dtos;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<SubjectDto> Subjects { get; set; }

        public CourseDto()
        {
            Subjects = new Collection<SubjectDto>();
        }
    }
}