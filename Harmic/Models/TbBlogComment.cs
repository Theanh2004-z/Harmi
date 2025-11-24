using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  // ⭐ BẮT BUỘC

namespace Harmic.Models
{
    [Table("tb_BlogComment")]   // ⭐ MAP ĐÚNG TÊN BẢNG TRONG SQL
    public partial class TbBlogComment
    {
        [Key]
        public int CommentId { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? Detail { get; set; }

        public int? BlogId { get; set; }

        public bool IsActive { get; set; }

        public virtual TbBlog? Blog { get; set; }
    }
}

