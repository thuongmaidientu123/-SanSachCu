using System;
using System.Collections.Generic;
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
        public IEnumerable<Sach> getListSaleBook()
        {
            IEnumerable<Sach> listSach = from book in db.Saches where book.tinhtrang == false orderby book.ngaydang select book;
            return listSach;
        }
        public IEnumerable<Sach> getForeignLiteratureBooks()
        {
            IEnumerable<Sach> listsach = from book in db.Saches where book.matheloai == 1 orderby book.ngaydang select book;
            return listsach;
        }
        public IEnumerable<Sach> getLiteratureBooks()
        {
            IEnumerable<Sach> listsach = from book in db.Saches where book.matheloai == 2 orderby book.ngaydang select book;
            return listsach;
        }
        public IEnumerable<Sach> getEconomicBooks()
        {
            IEnumerable<Sach> listsach = from book in db.Saches where book.matheloai == 3 orderby book.ngaydang select book;
            return listsach;
        }
        public IEnumerable<Sach> getRomanceNovelBooks()
        {
            IEnumerable<Sach> listsach = from book in db.Saches where book.matheloai == 4 orderby book.ngaydang select book;
            return listsach;
        }
        public IEnumerable<Sach> getMemoirBooks()
        {
            IEnumerable<Sach> listsach = from book in db.Saches where book.matheloai == 5 orderby book.ngaydang select book;
            return listsach;
        }
        public IEnumerable<Sach> Tim(string searchTerm)
        {
            IEnumerable<Sach> books = from b in db.Saches select b;

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



    }
}