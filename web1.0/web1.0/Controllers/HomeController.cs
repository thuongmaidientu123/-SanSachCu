using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.DAO;
using web1._0.Common;
using web1._0.Models;

namespace web1._0.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.NumberBookShow = 3;
            var dao = new DAO.SachDAO();
            return View(dao.getListSaleBook());
        }



        public ActionResult BaiTap()
        {
            return View();
        }

        
        public PartialViewResult HistoryTransaction()
        {
            SachDAO dao = new SachDAO();
            
            return PartialView(dao.getListHistoryTransaction());
        }
        
        
        public ViewResult pushBook()
        {
            return View("index");
        }


        
    }
}