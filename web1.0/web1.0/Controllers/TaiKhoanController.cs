using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.Models;
using web1._0.DAO;
using web1._0.Common;

namespace web1._0.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DAO.TaiKhoanDAO();
                var result = dao.CheckLogin(model.userName,model.passWord);
                if(result)
                {
                    var user = dao.getByUserName(model.userName);
                    var userSeesion = new UserLogin();
                    userSeesion.ID = user.ma;
                    userSeesion.UserName = user.tendangnhap;
                    Session.Add(Common.CommonConstrants.USER_SESSION, userSeesion);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }

            }
            return View();
        }
        public ActionResult DangKy(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                Boolean result = dao.Insert(taikhoan);
                if(result)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
               

            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập đủ các trường");
            }



            return View("DangKy");
        }

        [ChildActionOnly]
        public PartialViewResult CheckSession()
        {
            UserLogin a = (UserLogin)Session[CommonConstrants.USER_SESSION];
            return PartialView(a);
        }



        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}