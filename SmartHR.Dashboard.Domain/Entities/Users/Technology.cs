using SmartHR.Dashboard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Domain.Entities.Users
{
    public class Technology : BaseEntity
    {
        public string Name { get; set; }

        public User User { get; }

        public long UserId { get; set; }
    }
}
