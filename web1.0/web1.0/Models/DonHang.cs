namespace web1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        public int ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaygiao { get; set; }

        public bool tinhtrang { get; set; }

        public int mataikhoan { get; set; }

        public int masach { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
