using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web1._0.Models;

namespace web1._0.Common
{
    public class BaiDangSUM
    {
       static SanSachCu db = null;
        
        public BaiDang bd;
          public System.Web.Mvc.SelectList listTacGia2 = null;
        public List<TacGia> listTacGia = null;
        public IEnumerable<NhaXuatBan> listNXB = null;
        public IEnumerable<TheLoai> lisTheLoai = null;
        public BaiDangSUM()
        {
            db = new SanSachCu();
           // //listTacGia= from tg in db.TacGias select tg;
           // listNXB = from cc in db.NhaXuatBans select cc;
           // lisTheLoai=from dd in db.TheLoais select dd;
           //// listTacGia2 = new System.Web.Mvc.SelectList(listTacGia);
        }
        public void setBaiDang(BaiDang bd1)
        {
            bd = bd1;
        }
        public int SuaBaiDang(BaiDang Db_New)
        {
           // BaiDang BaiDang_old = db.BaiDangs.Where(p => p.ma.Equals(Db_New.ma)).SingleOrDefault();
            BaiDang bdold = db.BaiDangs.Where(w => w.ma == Db_New.ma).SingleOrDefault();
            bdold = Db_New;
            db.SaveChanges();
            return 5;
           // return Db_New.mataikhoan;
        }
        public static List<TacGia> getListTC()
        {
            db = new SanSachCu();
            return db.TacGias.Where(x => x.tentacgia != null).ToList();
        }
        public static List<TheLoai> getTheLoai()
        {
            return db.TheLoais.Where(x => x.ma != null).ToList();
        }
        public static List<NhaXuatBan> getlistNXB()
        {
            return db.NhaXuatBans.Where(x => x.ma != null).ToList();
        }
    }
    
}
