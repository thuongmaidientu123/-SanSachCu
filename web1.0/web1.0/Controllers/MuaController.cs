using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.Models;
using web1._0.DAO;

namespace web1._0.Controllers
{
    public class MuaController : BaseController
    {
        SanSachCu db = new SanSachCu();
        public static DonHang donhang = null;
        // GET: Mua
        public ActionResult Index()
        {
            UserLogin user =(UserLogin) Session[Common.CommonConstrants.USER_SESSION];
            if(user != null)
            {
                int idbook =Int32.Parse(Request["ma"]);
                donhang = new Models.DonHang();
                donhang.Sach = db.Saches.SingleOrDefault(x => x.ma == idbook ? true : false);
                donhang.masach = donhang.Sach.ma;
                donhang.TaiKhoan = db.TaiKhoans.SingleOrDefault(x => x.ma == user.ID ? true : false);
                donhang.mataikhoan = donhang.TaiKhoan.ma;
                donhang.tinhtrang = false;
                donhang.ngaygiao = DateTime.Today.AddDays(2);
                return View(donhang);
            }
            

            
            return View();
        }
        public ActionResult dathang()
        {
            var DAO = new DonHangDAO();
            var dao1 = new SachDAO();
            DonHang newDH = new DonHang();
            newDH.masach = donhang.masach;
            newDH.mataikhoan = donhang.mataikhoan;
            newDH.ngaygiao = donhang.ngaygiao;
            newDH.tinhtrang = donhang.tinhtrang;
            if(donhang == null)
            {
                return View("Index");
            }
            DAO.Insert(newDH);
            dao1.SaledBook(donhang.masach);
            return View("quanlydonhang");
        }

        public ActionResult quanlydonhang()
        {

            return View();
        }

    }
}