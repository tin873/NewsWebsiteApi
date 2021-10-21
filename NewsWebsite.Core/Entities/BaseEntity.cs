using NewsWebsite.Core.Enums;
using System;

namespace NewsWebsite.Core.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Xác định trạng thái thêm hay cập nhật
        /// </summary>
        public EntityState EntityState { get; set; } = EntityState.AddNew;

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
