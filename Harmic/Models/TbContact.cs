using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harmic.Models
{
    [Table("tb_Contact")] // ⚠️ Ràng buộc đúng tên bảng trong SQL
    public class TbContact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(150)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

        [StringLength(150)]
        public string? Email { get; set; }

        public string? Message { get; set; }

        public int? IsRead { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}


