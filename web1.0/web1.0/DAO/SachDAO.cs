using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using web1._0.Models;

namespace web1._0.DAO
{
    public class SachDAO
    {
        SanSachCu db = null;
        public SachDAO()
        {
            db = new SanSachCu();
        }
        public IEnumerable<Sach> getListHistoryTransaction()
        {
            IEnumerable<Sach> listSach = from book in db.Saches where book.tinhtrang == true orderby book.ngaydang select book ;
            return listSach;
        }
        public IEnumerable<Sach> getListSaleBook(ref int total, int PageIndex = 1, int PageSezie = 2)
        {
            total = db.Saches.Count();
            IEnumerable<Sach> listSach = db.Saches.OrderByDescending(x => x.giodang).Skip((PageIndex - 1) * PageSezie).Take(PageSezie).ToList();
            return listSach;          
    }
        public IEnumerable<Sach> getForeignLiteratureBooks(ref int total, int PageIndex = 1, int PageSezie = 2)
        {
            total = db.Saches.Where(x => x.matheloai == 1).Count();
            IEnumerable<Sach> listsach = db.Saches.Where(x => x.matheloai == 1).OrderByDescending(x => x.giodang).Skip((PageIndex - 1) * PageSezie).Take(PageSezie).ToList();
            return listsach;
        }
        public IEnumerable<Sach> getLiteratureBooks()
        {
            IEnumerable<Sach> listsach = from book in db.Saches where book.matheloai == 2 && book.tinhtrang == false orderby book.ngaydang select book;
            return listsach;
        }
        public IEnumerable<Sach> getEconomicBooks(ref int total, int PageIndex = 1, int PageSezie = 2)
        {
            total = db.Saches.Where(x=>x.matheloai==3).Count();
            IEnumerable<Sach> listsach = db.Saches.Where(x=>x.matheloai==3).OrderByDescending(x => x.giodang).Skip((PageIndex - 1) * PageSezie).Take(PageSezie).ToList();
            return listsach;
    }
        public IEnumerable<Sach> getRomanceNovelBooks(ref int total, int PageIndex = 1, int PageSezie = 2)
        {
            total = db.Saches.Where(x => x.matheloai == 4).Count();
            IEnumerable<Sach> listsach = db.Saches.Where(x => x.matheloai == 4).OrderByDescending(x => x.giodang).Skip((PageIndex - 1) * PageSezie).Take(PageSezie).ToList();
            return listsach;
        }
        public IEnumerable<Sach> getMemoirBooks(ref int total, int PageIndex = 1, int PageSezie = 2)
        {

            total = db.Saches.Where(x => x.matheloai == 5).Count();
            IEnumerable<Sach> listsach = db.Saches.Where(x => x.matheloai == 5).OrderByDescending(x => x.giodang).Skip((PageIndex - 1) * PageSezie).Take(PageSezie).ToList();
            return listsach;
        }
        public IEnumerable<Sach> Tim(string searchTerm)
        {
            IEnumerable<Sach> books = from b in db.Saches where b.tinhtrang == false select b;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                books = db.Saches.Where(b => b.ten.Contains(searchTerm));
            } 
            else
            {
                books = from b in db.Saches select b;
            }           
            return books;
        }
        
         public IEnumerable<BaiDang> TimBD(string searchTerm)
        {
            IEnumerable<BaiDang> bdang = from baidang in db.BaiDangs where baidang.tinhtrang == false select baidang;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                bdang = db.BaiDangs.Where(b => b.ten.Contains(searchTerm));
            } 
            else
            {
                bdang = from baidang in db.BaiDangs select baidang;
            }           
            return bdang;
        }
             
        public void SaledBook(int masach)
        {


            try
            {
                Sach book = db.Saches.Where(x => x.ma == masach).Single();
                book.gioithieu = "da ban";
                book.ngaydang = DateTime.Now.Date;
                book.tinhtrang = true;
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                              "Class: {0}, Property: {1}, Error: {2}",
                              validationErrors.Entry.Entity.GetType().FullName,
                              validationError.PropertyName,
                              validationError.ErrorMessage);
                    }
                }
            }



        }
     


    }
}