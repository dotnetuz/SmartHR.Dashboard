using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHR.Dashboard.Domain.Entities.Users
{
    public class User : BaseEntity
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

        [Range(0, 100)]
        public int? Score { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public UserType Role { get; set; }

        [ForeignKey(nameof(TechnologyId))]
        public Technology? Technology { get; set; }

        public long? TechnologyId { get; set; }
    }
}
