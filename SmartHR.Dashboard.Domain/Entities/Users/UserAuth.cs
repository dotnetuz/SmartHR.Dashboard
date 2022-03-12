using System;

namespace SmartHR.Dashboard.Domain.Entities.Users
{
    public class UserAuth
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
