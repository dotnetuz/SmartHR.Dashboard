using SmartHR.Dashboard.Domain.Enums;
using System;

namespace SmartHR.Dashboard.Domain.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ItemState State { get; set; } = ItemState.Created;
        public long? UpdatedBy { get; set; }
    }
}
