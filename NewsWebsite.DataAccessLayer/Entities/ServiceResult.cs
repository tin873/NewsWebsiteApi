using NewsWebsite.Core.Enums;

namespace NewsWebsite.DataAccessLayer.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Message trả về
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Mã lỗi trả về
        /// </summary>
        public CodeResult CodeResult { get; set; }

        /// <summary>
        /// Tổng bản ghi
        /// </summary>
        public int? Total { get; set; }
    }
}
