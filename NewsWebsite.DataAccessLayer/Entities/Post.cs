using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebsite.Core.Entities
{
    public class Post : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        [Required(ErrorMessage = "Tiêu đề bài viết không được để trống!")]
        public string Title { get; set; }

        public string Image { get; set; }
        [Required(ErrorMessage = "Nội dung bài viết không được để trống!")]
        public string Content { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
