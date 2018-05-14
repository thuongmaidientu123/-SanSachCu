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

        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(50)]
        public string tendangnhap { get; set; }

        [Required(ErrorMessage ="Nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        public string matkhau { get; set; }

        [Required(ErrorMessage = "Nhập họ và tên")]
        [Display(Name = "Họ và tên")]
        [StringLength(50)]
        public string hoten { get; set; }


        
        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh (1/1/2001)")]
        public DateTime ngaysinh { get; set; }

        [Required(ErrorMessage = "Nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        [StringLength(50)]
        public string diachi { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiDang> BaiDangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
