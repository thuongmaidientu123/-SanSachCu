using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.DAO;
namespace web1._0.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult BookInList()
        {
            var dao = new Models.SanSachCu();
            return PartialView("BooKinList",dao.TaiKhoans);



            
        }

        public ActionResult BanSach()
        {
            return View();
        }

        public ActionResult BaiTap()
        {
            return View();
        }
    }
}