namespace web1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int ma { get; set; }

        [Required]
        [StringLength(50)]
        public string ten { get; set; }

        [Required]
        [StringLength(200)]
        public string gioithieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaydang { get; set; }

        public TimeSpan giodang { get; set; }

        public int trangthai { get; set; }

        public int gia { get; set; }

        public bool tinhtrang { get; set; }

        public int matacgia { get; set; }

        public int manxb { get; set; }

        public int matheloai { get; set; }

        [StringLength(50)]
        public string hinhanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
