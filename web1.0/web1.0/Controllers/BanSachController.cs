using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.Common;
using web1._0.DAO;
using web1._0.Models;

namespace web1._0.Controllers
{
    public class BanSachController : BaseController
    {
        public static string img = null;
        // GET: BanSach
        public ActionResult Index()
        {
            
            UserLogin a = (UserLogin)Session[CommonConstrants.USER_SESSION];
            if (a != null)
            {
                var dao = new DAO.BaiDangDAO();
                return View(dao.getListBaiDang(a.ID));
            }

            return View();
        }
        public ActionResult Xoa(BaiDang bd)
        {

            var dao = new DAO.BaiDangDAO();
            int ID = dao.XoaDonHang(bd.ma);
            return View("Index", dao.getListBaiDang(ID));
        }
        public ActionResult convert(BaiDang bd)
        {
            var dao = new DAO.BaiDangDAO();
            BaiDang bdsua = dao.SuaBaiDang(bd);
            return View("TrangSua", bdsua);
        }

        public ActionResult TrangSua(BaiDang bd)
        {
        if(img!=null)
        {
             bd.hinhanh = img;
        }
       
            convert(bd);
            img = null;
            return View(bd);
        }
        public ActionResult create(BaiDang bd)
        {
            UserLogin a = (UserLogin)Session[CommonConstrants.USER_SESSION];
            var BDsum = new BaiDangDAO();
            bd.hinhanh = img;
            BaiDang bd_temp = new BaiDang();
            bd.mataikhoan = a.ID;
            bd_temp.ten = null;
            if (BDsum.insertBaiDang(bd))
            {
                img = null;
                 return View("Index", BDsum.getListBaiDang(a.ID));
                //bd_temp = null;
                //return View("create", bd_temp);
            }
            else
            {
                img = null;
                return View("create", bd_temp);
            }
        }
        [HttpPost]
        public ActionResult uphinh(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Image"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string s= "/Image/" + Path.GetFileName(file.FileName);

                    ViewBag.Message = "Upload hình ảnh thành công";
                    img = s;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Lỗi:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Hình ảnh không được chọn";
            }
            return View();
        }

    }

}