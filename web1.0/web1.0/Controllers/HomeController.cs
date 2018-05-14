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
            var dao = new DAO.SachDAO();
            return View(dao.getListSaleBook());
        }



        public ActionResult BaiTap()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult HistoryTransaction()
        {
            SachDAO dao = new SachDAO();
            
            return PartialView(dao.getListHistoryTransaction());
        }

        
    }
}