using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web1._0.Models;

namespace web1._0.DAO
{
    public class BaiDangDAO
    {
        SanSachCu db = null;
        BaiDang donhang = null;
        public BaiDangDAO()
        {
            db = new SanSachCu();
        }
        public void BaiDang(BaiDang donh)
        {
            donhang = donh;
        }

        public IEnumerable<BaiDang> getListBaiDang(int ma)
        {
            IEnumerable<BaiDang> listBD = from bd in db.BaiDangs where bd.mataikhoan == ma select bd;
            return listBD;
        }
        public bool insertBaiDang(BaiDang bd)
        {

            Boolean temp = true;
            if (bd.ten==null)
            {
                temp = false;
                return temp;

            }
            db.BaiDangs.Add(bd);
           
            try
            {
                db.SaveChanges();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                temp = false;
            }

            return temp;
    }
    public BaiDang getbaidang()
    {
            return (BaiDang)(from tg in db.BaiDangs where tg.ma != 0 select tg);
    }
        public IEnumerable<BaiDang> getListBd(ref int total,int PageIndex=1, int PageSezie=2)
        {
            total = db.BaiDangs.Count();
            IEnumerable<BaiDang> listBd = db.BaiDangs.OrderByDescending(x=>x.giodang).Skip((PageIndex - 1) * PageSezie).Take(PageSezie).ToList();
           // IEnumerable<BaiDang> listBd = from book in db.BaiDangs where book.tinhtrang == false orderby book.ngaydang select book;
            return listBd;
        }
        public int XoaDonHang(int ma)
        {
            BaiDang BaiDang_del= db.BaiDangs.Where(p=>p.ma.Equals(ma)).SingleOrDefault();
            int ID= BaiDang_del.mataikhoan;
            db.BaiDangs.Remove(BaiDang_del);
            db.SaveChanges();
            return ID;
        }
        public BaiDang SuaBaiDang(BaiDang Db_New)
        {
            BaiDang BaiDang_old = db.BaiDangs.Where(p => p.ma.Equals(Db_New.ma)).SingleOrDefault();
            BaiDang_old.gioithieu=Db_New.gioithieu;
            BaiDang_old.ten = Db_New.ten;
            BaiDang_old.TacGia = Db_New.TacGia;
            BaiDang_old.matacgia = Db_New.matacgia;
            BaiDang_old.trangthai = Db_New.trangthai;
            BaiDang_old.gia = Db_New.gia;
            BaiDang_old.TheLoai = Db_New.TheLoai;
            if(Db_New.hinhanh!=null)
            {
                BaiDang_old.hinhanh = Db_New.hinhanh;
            }
         
            Db_New = null;
            db.SaveChanges();
            return BaiDang_old;
        }

        public IEnumerable<TacGia> getListTacGia()
        {
            IEnumerable<TacGia> listTG = from tg in db.TacGias select tg;
            return listTG;
        }

    }
}