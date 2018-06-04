using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.Models;
using web1._0.DAO;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace web1._0.Controllers
{
    public class MuaController : BaseController
    {
        SanSachCu db = new SanSachCu();
        public static DonHang donhang = null;
        // GET: Mua
        public ActionResult Index()
        {
            UserLogin user = (UserLogin)Session[Common.CommonConstrants.USER_SESSION];
            if (user != null)
            {
                int idbook = Int32.Parse(Request["ma"]);
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
            if (donhang == null)
            {
                return View("Index");
            }
            DAO.Insert(newDH);

            dao1.SaledBook(donhang.masach);

            return View();
        }
        public ActionResult kiemtradonhang()
        {
            TaiKhoan tk = null;
            UserLogin user = (UserLogin)Session[Common.CommonConstrants.USER_SESSION];
            if (user != null)
            {
                tk = db.TaiKhoans.SingleOrDefault(x => x.ma == user.ID ? true : false);
            }

            return View(getdonhang(tk));
        }

        public IEnumerable< Hoa_Don> getHoaDon(TaiKhoan tk,int madh)
        {
            
            Hoa_Don hd = null;
           
            UserLogin user = (UserLogin)Session[Common.CommonConstrants.USER_SESSION];
            if (user != null)
            {

                hd = new Models.Hoa_Don();
                DonHang dh = new DonHang();
                Sach book = new Sach();
                dh = db.DonHangs.SingleOrDefault(x => x.ma == madh ? true : false);
                book = dh.Sach;
                tk = db.TaiKhoans.SingleOrDefault(x => x.ma == user.ID ? true : false);
                hd.tensach = book.ten;
                hd.tentk = tk.hoten;
                hd.ngaygiao = DateTime.Today.AddDays(2);
                hd.gia = book.gia;
                hd.diachi = tk.diachi;

            }
            yield return hd;
        }
        public IEnumerable<DonHang> getdonhang(TaiKhoan tk)
        {
            return (from dh in db.DonHangs where dh.mataikhoan == tk.ma select dh);
        }
        
        public ActionResult donhang1()
        {
            return View(db.DonHangs.ToList());
        }
       
        public ActionResult exreport()
        {
           
            TaiKhoan tk = null;
            UserLogin user = (UserLogin)Session[Common.CommonConstrants.USER_SESSION];
            if (user != null)
            {
                tk = db.TaiKhoans.SingleOrDefault(x => x.ma == user.ID ? true : false);
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Views/Mua/bill.rpt")));
            rd.SetDataSource(getHoaDon(tk, int.Parse((string)RouteData.Values["id"])));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "aplication/pdf", "Don_Hang1.pdf");
            }
            catch
            {
                throw;
            }

        }


        }
    }
