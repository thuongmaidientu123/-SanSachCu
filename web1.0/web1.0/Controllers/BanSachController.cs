using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using web1._0.Common;
using web1._0.DAO;
using web1._0.Models;

namespace web1._0.Controllers
{
    public class BanSachController : BaseController
    {
        public static string img_edit = null;
        public static BaiDang bd_edit = new BaiDang();
        // GET: BanSach
        public ActionResult Index(int page = 1, int PageSize = 3)
        {

            UserLogin a = (UserLogin)Session[CommonConstrants.USER_SESSION];
            if (a != null)
            {
                var dao = new DAO.BaiDangDAO();
                int totalRecord = 0;
                var model = dao.getListBaiDang(a.ID,ref totalRecord, page, PageSize);
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

            return View();
        }

        public ActionResult Xoa(BaiDang bd)
        {

            var dao = new DAO.BaiDangDAO();
            int ID = dao.XoaDonHang(bd.ma);
            return View("Index", dao.getListBaiDang2(ID));
        }
        public ActionResult convert(BaiDang bd)
        {
            var dao = new DAO.BaiDangDAO();
            BaiDang bdsua = dao.SuaBaiDang(bd);
            return View("TrangSua",bd);
        }

        public ActionResult TrangSua(BaiDang bd)
        {
            //if (bd != null)
            //    bd_edit = bd;
            //if (img_edit != null)
            //{
            //    bd.hinhanh = img_edit;
            //}

            convert(bd);
            return View(bd);
        }

        public ActionResult create(BaiDang bd)
        {
            UserLogin a = (UserLogin)Session[CommonConstrants.USER_SESSION];
            //bd_create = bd;
            var BDsum = new BaiDangDAO();
            BaiDang bd_temp = new BaiDang();
            bd.mataikhoan = a.ID;
            bd_temp.ten = null;
            string TacGia = Request.Form["TacGia"];
            string NXB = Request.Form["NXB"];
            string tenTheLoai = Request.Form["TheLoai"];
            if (BDsum.insertBaiDang(bd))
            {
                Response.Write("<script type=\"text/javascript\">alert('Tạo Bài đăng thành công !!! ');</script>");
                return View("create", bd_temp);
            }
            else
            {
                // img_create = null;
                return View("create", bd_temp);
            }
        }

               [HttpPost]
        public ActionResult UploadH(BaiDang viewModel, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = Path.Combine(Server.MapPath("~/Image"),
                                             Path.GetFileName(file.FileName));
                file.SaveAs(path);
                string s = "/Image/" + Path.GetFileName(file.FileName);
                viewModel.hinhanh = s;
            }
            UserLogin a = (UserLogin)Session[CommonConstrants.USER_SESSION];
            var BDsum = new BaiDangDAO();
            viewModel.mataikhoan = a.ID;
            string TacGia = Request.Form["TacGia"];
            string NXB = Request.Form["NXB"];
            string tenTheLoai = Request.Form["TheLoai"];
            if (TacGia != null)
            {
                TacGia tempTG = new TacGia();
                tempTG = BDsum.getTacGiabyTen(TacGia);
                if (tempTG != null)
                    viewModel.setTG(tempTG);
                else
                {
                    if (BDsum.insertTacGia(TacGia))
                    {
                        tempTG = BDsum.getTacGiabyTen(TacGia);
                        viewModel.setTG(tempTG);
                    }
                    else
                        Response.Write("<script type=\"text/javascript\">alert('Insert tác giả không thành công!!! ');</script>");
                }


            }
            if (NXB != null)
            {
                NhaXuatBan tempTG = new NhaXuatBan();
                tempTG = BDsum.getNXBbyTen(NXB);
                if (tempTG != null)
                    viewModel.NhaXuatBan = tempTG;
                else
                {
                    if (BDsum.insertNXB(NXB))
                    {
                        tempTG = BDsum.getNXBbyTen(NXB);
                        viewModel.NhaXuatBan = tempTG;
                    }
                    else
                        Response.Write("<script type=\"text/javascript\">alert('Insert NXB không thành công!!! ');</script>");
                }


            }
            if (tenTheLoai != null)
            {
                TheLoai tempTG = new TheLoai();
                tempTG = BDsum.getTheloaibyTen(tenTheLoai);
                if (tempTG != null)
                    viewModel.TheLoai = tempTG;
                else
                {
                    if (BDsum.insertTheLoai(tenTheLoai))
                    {
                        tempTG = BDsum.getTheloaibyTen(tenTheLoai);
                        viewModel.TheLoai = tempTG;
                    }
                    else
                        Response.Write("<script type=\"text/javascript\">alert('Insert TheLoai không thành công!!! ');</script>");
                }


            }
            if (BDsum.insertBaiDang(viewModel))
            {

                Response.Write("<script type=\"text/javascript\">alert('Tạo Bài đăng thành công !!! ');</script>");
       
                return View("Index", BDsum.getListBaiDang2(a.ID));
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Tạo Bài đăng ko thành công !!! ');</script>");

                return View("create", viewModel);
            }
        }


        [HttpPost]
        public ActionResult UploadH2(BaiDang viewModel, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = Path.Combine(Server.MapPath("~/Image"),
                                             Path.GetFileName(file.FileName));
                file.SaveAs(path);
                string s = "/Image/" + Path.GetFileName(file.FileName);
                viewModel.hinhanh = s;
            }
            UserLogin a = (UserLogin)Session[CommonConstrants.USER_SESSION];
            var BDsum = new BaiDangDAO();
            viewModel.mataikhoan = a.ID; 
            convert(viewModel);
            return View("TrangSua",viewModel);
            }
        }
    }