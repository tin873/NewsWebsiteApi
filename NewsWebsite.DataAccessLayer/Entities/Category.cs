using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebsite.Core.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Tên danh mục không được để trống!")]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
