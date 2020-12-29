using LearningManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Repositories.ApplicationUsers.Dtos
{
    public class UserDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsStudent { get; set; }

        public Designation? Designation { get; set; }

    }
}