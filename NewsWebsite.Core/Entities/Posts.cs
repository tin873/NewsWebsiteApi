using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebsite.Core.Entities
{
    [Table("Category")]
    public class Posts : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        [Required(ErrorMessage = "Tiêu đề bài viết không được để trống!")]
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
    }
}
