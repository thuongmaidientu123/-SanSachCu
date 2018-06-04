using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web1._0.Controllers
{
    public class ShowBDController : Controller
    {
        // GET: ShowBD
        public ActionResult Index(int page=1,int PageSize=3)
        {
            var dao = new DAO.BaiDangDAO();
            int totalRecord = 0;
          var model = dao.getListBd(ref totalRecord, page, PageSize);
            ViewBag.total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling( (double)(totalRecord / PageSize))+1;
            ViewBag.totalPage = totalPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}