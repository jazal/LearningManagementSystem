using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Enums
{
    public enum Designation : byte
    {
        Lecturer = 1,

        [Display(Name = "Course Coordinator")]
        CourseCoordinator = 2,

        [Display(Name = "General Manager")]
        GeneralManager = 3,
    }
}