namespace web1._0.Models
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Drawing;
    using System.Linq;
    using System.Web;

    [Table("BaiDang")]
    public partial class BaiDang
    {
        [Key]
        public int ma { get; set; }

        [Required]
        [StringLength(50)]
        public string ten { get; set; }

        [Required]
        [StringLength(100)]
        public string gioithieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaydang { get; set; }
 

        public TimeSpan giodang { get; set; }

        public int trangthai { get; set; }

        public int gia { get; set; }

        public bool tinhtrang { get; set; }

        public int matacgia { get; set; }

        public int matheloai { get; set; }

        public int manxb { get; set; }

        public int mataikhoan { get; set; }

        [StringLength(50)]
        public string hinhanh { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get;set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual TheLoai TheLoai { get; set; }
        //[Display(Name ="Profile name")]
       // public HttpPostedFileBase  File { get; set; }

        public IEnumerable<TacGia> getListTacGia()
        {
            IEnumerable<TacGia> listTG = BaiDangSUM.getListTC();
            return listTG;
        }
        public IEnumerable<NhaXuatBan> getListNXB()
        {
            IEnumerable<NhaXuatBan> listTG = BaiDangSUM.getlistNXB();
            return listTG;
        }
        public IEnumerable<string> getListTGstring()
        {
            IEnumerable<TacGia> listTG = BaiDangSUM.getListTC();
            List<string> listTGstring = new List<string>() ;
            foreach (TacGia tg in listTG)
            {
                listTGstring.Add(tg.tentacgia);
            }
          
            return listTGstring.AsEnumerable();
        }
        public IEnumerable<string> getListNXBstring()
        {
            IEnumerable<NhaXuatBan> listNXB = BaiDangSUM.getlistNXB();
            List<string> listNXBstring = new List<string>();
            foreach (NhaXuatBan tg in listNXB)
            {
                listNXBstring.Add(tg.tennhaxuatban);
            }

            return listNXBstring.AsEnumerable();
        }
        public IEnumerable<string> getListTheLoaistring()
        {
            IEnumerable<TheLoai> listTheLoai = BaiDangSUM.getTheLoai();
            List<string> listTheLoaistring = new List<string>();
            foreach (TheLoai tg in listTheLoai)
            {
                listTheLoaistring.Add(tg.tenloaisach);
            }

            return listTheLoaistring.AsEnumerable();
        }
        public IEnumerable<TheLoai> getListTheLoai()
        {
            IEnumerable<TheLoai> listTG = BaiDangSUM.getTheLoai();
            return listTG;
        }
        public void setTG(TacGia sex)
        {
            this.TacGia = sex;
        }
    }
}
