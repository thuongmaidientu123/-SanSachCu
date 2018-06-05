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

        public IEnumerable<BaiDang> getListBaiDang(int ma, ref int total, int PageIndex = 1, int PageSezie = 2)
        {
            total = db.BaiDangs.Where(x => x.mataikhoan == ma).Count();
            IEnumerable<BaiDang> listBD = db.BaiDangs.Where(x => x.mataikhoan == ma).OrderByDescending(x => x.giodang).Skip((PageIndex - 1) * PageSezie).Take(PageSezie).ToList();
            return listBD;
        }
        public IEnumerable<BaiDang> getListBaiDang2(int ma)
        {
            IEnumerable<BaiDang> listBD = from bd in db.BaiDangs where bd.mataikhoan == ma orderby bd.ngaydang select bd ;
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
                db.SaveChangesAsync();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                temp = false;
            }

            return temp;
    }
        public bool insertTacGia(string tenTG)
        {
            Boolean temp = true;
            TacGia TG = new TacGia();
            TG.tentacgia = tenTG;
            db.TacGias.Add(TG);

            try
            {
                db.SaveChanges();
                db.SaveChangesAsync();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                temp = false;
            }

            return temp;
        }
        public bool insertNXB(string tenTG)
        {
            Boolean temp = true;
            NhaXuatBan TG = new NhaXuatBan();
            TG.tennhaxuatban = tenTG;
            db.NhaXuatBans.Add(TG);

            try
            {
                db.SaveChanges();
                db.SaveChangesAsync();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                temp = false;
            }

            return temp;
        }
        public bool insertTheLoai(string tenTG)
        {
            Boolean temp = true;
            TheLoai TG = new TheLoai();
            TG.tenloaisach = tenTG;
            db.TheLoais.Add(TG);

            try
            {
                db.SaveChanges();
                db.SaveChangesAsync();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                temp = false;
            }

            return temp;
        }
        public TacGia getTacGia(int bd)
        {
            return (TacGia)(from tg in db.TacGias where tg.ma == bd select tg);
        }

        public TacGia getTacGiabyTen(string bd)
        {
            //return (TacGia)(from tg in db.TacGias where tg.tentacgia == bd select tg);
            return (TacGia)db.TacGias.Where(p => p.tentacgia.Equals(bd)).SingleOrDefault();
        }
        public NhaXuatBan getNXBbyTen(string bd)
        {
            //return (TacGia)(from tg in db.TacGias where tg.tentacgia == bd select tg);
            return (NhaXuatBan)db.NhaXuatBans.Where(p => p.tennhaxuatban.Equals(bd)).SingleOrDefault();
        }
        public TheLoai getTheloaibyTen(string bd)
        {
            //return (TacGia)(from tg in db.TacGias where tg.tentacgia == bd select tg);
            return (TheLoai)db.TheLoais.Where(p => p.tenloaisach.Equals(bd)).SingleOrDefault();
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
            BaiDang_old.manxb = Db_New.manxb;
            BaiDang_old.trangthai = Db_New.trangthai;
            BaiDang_old.gia = Db_New.gia;
            BaiDang_old.matheloai = Db_New.matheloai;
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