namespace NewsWebsite.Core.Enums
{
    public enum EntityState
    {
        AddNew = 1,
        Update = 2,
        Delete = 3
    }
    public enum CodeResult
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        NotValid = 400,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Lỗi
        /// </summary>
        Exeption = 500,

        /// <summary>
        /// không tìm thấy
        /// </summary>
        NotFound = 404,
    }
}
