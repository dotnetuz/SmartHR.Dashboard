using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Extensions
{
    public static class BaseEntityExtensions
    {
        public static void Update(this BaseEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = HttpContextHelper.UserId;
        }

        public static void Delete(this BaseEntity entity)
        {
            entity.State = ItemState.Deleted;
        }
    }
}
