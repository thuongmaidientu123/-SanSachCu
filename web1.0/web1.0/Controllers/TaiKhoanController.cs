using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.Models;
using web1._0.DAO;

namespace web1._0.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                int result = dao.Insert(taikhoan);
                if(result > 0)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Thong bao loi");
                }
            }
            

            return View("DangKy");
        }


    }
}