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
        //danh muc sản phảm
        public ActionResult Vanhoc()
        {
            var dao = new DAO.SachDAO();
            int n = dao.getLiteratureBooks().Count();
            ViewBag.NumberBookShow = n;
            return View(dao.getLiteratureBooks());
        }
        public ActionResult KinhTe()
        {
            var dao = new DAO.SachDAO();
            int n = dao.getEconomicBooks().Count();
            ViewBag.NumberBookShow = n;
            return View(dao.getEconomicBooks());
        }
        public ActionResult TieuThuyet()
        {
            var dao = new DAO.SachDAO();
            int n = dao.getRomanceNovelBooks().Count();
            ViewBag.NumberBookShow = n;
            return View(dao.getRomanceNovelBooks());
        }
        public ActionResult VanHocNuocNgoai()
        {
            var dao = new DAO.SachDAO();
            int n = dao.getForeignLiteratureBooks().Count();
            ViewBag.NumberBookShow = n;
            return View(dao.getForeignLiteratureBooks());
        }
        public ActionResult HoiKi()
        {
            var dao = new DAO.SachDAO();
            int n = dao.getMemoirBooks().Count();
            ViewBag.NumberBookShow = n;           
            return View(dao.getMemoirBooks());
        }
        public ActionResult ThamKhao()
        {
            return View();
        }

        public ActionResult KQTimKiem(string searchTerm)
        {
            var dao = new DAO.SachDAO();
            int n = dao.Tim(searchTerm).Count();
            ViewBag.NumberBookShow = n;            
            ViewBag.SearchTerm = searchTerm;
            return View(dao.Tim(searchTerm));
        }


       

    }
}