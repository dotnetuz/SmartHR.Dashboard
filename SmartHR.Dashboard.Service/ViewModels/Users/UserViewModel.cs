using System.ComponentModel.DataAnnotations;

namespace SmartHR.Dashboard.Service.ViewModels.Users
{
    public class UserViewModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MinLength(8)]
        public string Password { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Technology { get; set; }
        public string Organization { get; set; }
        public string Level { get; set; }
    }
}
