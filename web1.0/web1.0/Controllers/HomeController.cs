using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1._0.DAO;
using web1._0.Common;
using web1._0.Models;
using System.Web.UI.WebControls;

namespace web1._0.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page = 1, int PageSize = 3)
        {
            var dao = new DAO.SachDAO();
            int totalRecord = 0;
            var model = dao.getListSaleBook(ref totalRecord, page, PageSize);
            ViewBag.total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / PageSize)) + 1;
            ViewBag.totalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            
            return View(model);
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
        public ActionResult KinhTe(int page = 1, int PageSize = 3)
        {
            var dao = new DAO.SachDAO();
            int totalRecord = 0;
            var model = dao.getEconomicBooks(ref totalRecord, page, PageSize);
            ViewBag.total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / PageSize)) + 1;
            ViewBag.totalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult TieuThuyet(int page = 1, int PageSize = 3)
        {
            var dao = new DAO.SachDAO();
            int totalRecord = 0;
            var model = dao.getRomanceNovelBooks(ref totalRecord, page, PageSize);
            ViewBag.total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / PageSize)) + 1;
            ViewBag.totalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult VanHocNuocNgoai(int page = 1, int PageSize = 3)
        {
            var dao = new DAO.SachDAO();
            int totalRecord = 0;
            var model = dao.getForeignLiteratureBooks(ref totalRecord, page, PageSize);
            ViewBag.total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / PageSize)) + 1;
            ViewBag.totalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult HoiKi(int page = 1, int PageSize = 3)
        {
            var dao = new DAO.SachDAO();
            int totalRecord = 0;
            var model = dao.getMemoirBooks(ref totalRecord, page, PageSize);
            ViewBag.total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / PageSize)) + 1;
            ViewBag.totalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
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
        public PartialViewResult TimKiem()
        {
            var dao = new DAO.BaiDangDAO();
            TheLoai_Gia tlg = new TheLoai_Gia();
            //tlg.lsttacgia = dao.getListTacGia();
            //tlg.lsttheloai = dao.getListTheLoai();
            return PartialView(tlg);
        }

       

    }
}