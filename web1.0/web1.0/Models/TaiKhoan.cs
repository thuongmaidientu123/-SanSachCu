namespace web1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            BaiDangs = new HashSet<BaiDang>();
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int ma { get; set; }

        [Required]
        [StringLength(50)]
        public string matkhau { get; set; }

        [Required]
        [StringLength(50)]
        public string hoten { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaysinh { get; set; }

        [Required]
        [StringLength(50)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string tendangnhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiDang> BaiDangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }


        
    }
}
